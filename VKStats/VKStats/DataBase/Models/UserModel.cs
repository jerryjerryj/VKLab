using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using VKStats.DataBase.QueryExecutors;
namespace VKStats.DataBase.Models
{
    class UserModel :DBEntity
    {
        public string idVk;
        public string lastUpdate;
        public bool isRateable;
        public UserModel(MySqlConnection mySqlConnection) : base(mySqlConnection) {}
        public void Insert()
        {
            string query = "INSERT INTO users (idVk,lastUpdate,isRateable)Values(@Vk,@Date,@Rateable)";
            var queryParams = new Dictionary<string, object>();
            queryParams.Add("@Vk", idVk);
            queryParams.Add("@Date", lastUpdate);
            queryParams.Add("@Rateable", isRateable);

            var inserter = new Inserter(connection);
            inserter.InsertOne(query, queryParams);
        }
        public void Update()
        {
            // TODO
        }

    }
}
