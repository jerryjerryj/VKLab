using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
 
using VKStats.Base.Params;
using VKStats.Base.Selections;
using VKStats.Base.Transactions;
using VKStats.Senders;


namespace VKStats.Services
{
    class UserService : Service
    {
        private List<CountsData> GenerateRatings(List<int> artistIds)
        {
            var rawRate = artistIds.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            
            var items = from pair in rawRate
                        orderby pair.Value descending
                        select pair;
            var rates = new List<CountsData>();
            foreach (KeyValuePair<int, int> pair in items)
            {
                var rate = new CountsData();
                rate.IdArtist = pair.Key;
                rate.Counter = pair.Value;
                rates.Add(rate);
            }
            return rates;
        }

        public UserService() // TODO classes like with db
        {
            Console.WriteLine("☼☼☼ UserService ☼☼☼\nWorking in passive mode.");
            var queue = new MessageQueue(@".\private$\users");
            queue.Formatter = new XmlMessageFormatter(new String[] { "System.String" });
            while (true)
            {
                var transaction = new MessageQueueTransaction();
                try
                {
                    transaction.Begin();
                    string user = queue.Receive(transaction).Body.ToString();
                    Console.Write("Recieved : user " + user + " ... ");
                    UpdateTodayCounts(user);
                    Console.WriteLine("DONE");
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Abort();
                }
            }            
        }
      private bool IsNeedUpdate(string userId)
        {
            var userParams = new UserParams();
            userParams.IdVk = userId;
            var dateTime = new SelectUserLastUpdate().Execute(userParams);

            if (dateTime == null || dateTime.Value.Date != DateTime.Today)
                return true;
            return false;
        }
        public void UpdateTodayCounts(string userId) // REFACTOR ME, PLEASE
        {
            // TODO одинаковые записи. пусть будет так пока.
            
             if(IsNeedUpdate(userId)  == false)
                return;

            var artists = new ArtistsQuery().GetArtistsFromApi(userId);

            // finding artists in DB, changing NAMES to IDS
            var artistIds = new List<int>();
            foreach (var artist in artists)
            {
                var artistParams = new ArtistParams
                {
                    Name = artist
                };

                var idSelector = new SelectArtistId();
                var id = idSelector.Execute(artistParams);

                // inserting artists to DB
                if (id == null)
                {
                    new AddArtistQuery().Execute(artistParams);
                    id = idSelector.Execute(artistParams);
                }
                artistIds.Add(id.Value); //names to ids
            }

            var rates = GenerateRatings(artistIds);

            // ratings to DB
            var countsParams = new CountsParams
            {
                Today = GetToday(),
                IdUser = userId,
                CountsData = rates
            };
            new AddCountsQuery().Execute(countsParams);

        }
    }
}
