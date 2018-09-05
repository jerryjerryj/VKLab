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
    class SelectUserLastUpdate : BaseSelect<UserParams, DateTime?>
    {
        protected override DateTime? SelectInternal(MySqlConnection mySqlConnection, UserParams queryParams)
        {
            string query = "SELECT lastUpdate from users where idVk=@Id";
            var dataFromQuery = mySqlConnection.Query<DateTime?>(query, new { Id = queryParams.IdVk }).First();
            return dataFromQuery;
        }
    }
}
