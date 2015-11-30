using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

using VKStats.DataBase.Models;
using VKStats.DataBase.QueryExecutors;
namespace VKStats.DataBase.Controllers
{
    class UsersController : DBEntity
    {
        // fields
        // чтобы лишний раз не проверять/вспоминать
        private static string Id = "id";
        private static string VkId = "idVk";
        private static string LastUpdate = "lastUpdate";
        private static string RateableUser = "isRateable";
        private static string dateFormat = "yyyy-MM-dd";
        private string today;
        private Selector selector;

        public UsersController(MySqlConnection mySqlConnection): base(mySqlConnection)
        {
           // tableName = "users";
            today = DateTime.Now.Date.ToString(dateFormat);
            selector = new Selector(mySqlConnection);
        }
        public List<string> GetRateableUsers()
        {            
            string query = "SELECT " + VkId + " FROM users WHERE " + RateableUser + " = 1";
            return selector.SelectOne(query);
        }
        public List<string> GetUsersWithOldUpdate()
        {
            // вот так запросы гораздо удобнее писать, чем сборные. Зато, в том варианте труднее забыть/сделать ошибку. Скажите пожалуйста, как лучше?
            string query = "SELECT idVk FROM users WHERE lastUpdate IS NULL OR lastUpdate != " + today; 
            return selector.SelectOne(query); 
        }
      
        public void FindAndInsertNewFriends(List<string> allFriendsIds)
        {
            foreach (string friendId in allFriendsIds)
            {
                string query = "SELECT * FROM users WHERE " + VkId + " = '" + friendId + "'";
                if (selector.SelectOne(query).Count == 0) // friend is NEW
                    InsertFriend(friendId);
            }
        }
        private void InsertFriend(string vkId)
        {
            var friend = new UserModel(connection);
            friend.idVk = vkId;
            friend.isRateable = false;
            friend.Insert();
        }

    }
}
