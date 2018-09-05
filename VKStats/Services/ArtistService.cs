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
    class ArtistService : Service
    {
        public ArtistService() // TODO classes like with db
        {
            Console.WriteLine("☼☼☼ ArtistService ☼☼☼\nWorking in passive mode.");
            var queue = new MessageQueue(@".\private$\artists");
            queue.Formatter = new XmlMessageFormatter(new String[] { "System.String" });
            while (true)
            {
                var transaction = new MessageQueueTransaction();
                try
                {
                    transaction.Begin();
                    string artist = queue.Receive(transaction).Body.ToString();
                    Console.Write("Recieved : artist " + artist + " ... ");

                    var artistParams = new ArtistDateParams();
                    artistParams.Id = Int32.Parse(artist);
                    artistParams.Date = GetToday();
                    new AddArtistRatesQuery().Execute(artistParams);
                    
                    Console.WriteLine("DONE");
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Abort();
                }
            }
        }
    }
}
