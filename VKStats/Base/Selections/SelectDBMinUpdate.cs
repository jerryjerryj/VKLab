using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MySql.Data.MySqlClient;
using VKStats.Base.Params;
namespace VKStats.Base.Selections
{
    class SelectDBMinUpdate : BaseSelect<UserParams, DateTime?>
    {
        protected override DateTime? SelectInternal(MySqlConnection mySqlConnection, UserParams up)
        {
            string query = "SELECT min(lastUpdate) from users";
            var dataFromQuery = mySqlConnection.Query<DateTime?>(query).First();
            return dataFromQuery;
        }
    }
}
