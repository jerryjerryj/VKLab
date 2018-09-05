using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VKStats.Base.Params;
using Dapper;
using MySql.Data.MySqlClient;

namespace VKStats.Base.Selections
{
    class SelectUpdatableUsers :BaseSelect<DateParams, List<string>>
    {
        protected override List<string> SelectInternal(MySqlConnection mySqlConnection, DateParams queryParams)
        {
            string query = "SELECT idVk FROM users WHERE lastUpdate IS NULL OR lastUpdate != @Today";
            var dataFromQuery = mySqlConnection.Query<string>(query, new { Today = queryParams.Date }).ToList();
            return dataFromQuery;
        }
    }
}
