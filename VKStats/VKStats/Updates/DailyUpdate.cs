using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VKStats.DataBase.Controllers;
using VKStats.Senders;
using VKStats.DataBase.QueryExecutors;
namespace VKStats.Updates
{
    class DailyUpdate
    {
        // connection
        private const string server = "localhost";
        private const string database = "vkstats";
        private const string login = "root";
        private const string password = ""; // TODO make pass for db!!!

        public void Start()
        {
            // db connection ...
            var connector = new Connector();
            connector.CreateConnection("localhost", "vkstats", "root", "");

            UpdateDataTablesFromApi(connector);

            // TODO functions which make different ratings for current date, put it to other class

            Console.WriteLine("\nDaily update has ended it's work ...");

        }

        private void UpdateDataTablesFromApi(Connector connector)
        {
            // TODO  divide this big function?

            // updating users ...
            Console.Write("Updating users...");
            var userController = new UsersController(connector.mySqlConnection);
            var rateableUsers = userController.GetRateableUsers();
            var friends = new List<string>();
            foreach (string user in rateableUsers)
            {
                userController.FindAndInsertNewFriends(GetFriends(user));
            }
            Console.Write(" [DONE]\n");

            // searching for update...
            var usersForUpdate = userController.GetUsersWithOldUpdate();

            while (usersForUpdate != null)
            {
                break;
                // TODO 1: get for each user Dictionary<artist, number of songs>
                // TODO 1.1: fill "counts" table, if artist appeared for the 1st time, add him to "artists" table
                // TODO 2: check. (GetUsersWithOldUpdate again)
            }
                     

        }
        private List<string> GetFriends(string userId)
        {
            var friendsQuery = new FriendsQuery(userId);
            friendsQuery.UpdateFromApi();
            return friendsQuery.friends;
        }


        
      
    }
}
