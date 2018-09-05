using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using MySql.Data.MySqlClient;
using VKStats.Base.Params;
namespace VKStats.Base.Transactions
{
    abstract class BaseUserQuery<TQueryParams> : BaseQuery<TQueryParams> where TQueryParams : UserParams // TODO internal, но недоступен
    {
        protected void Insert(MySqlTransaction mySqlTransaction, string idVk)
        {
            if (IsExists(mySqlTransaction.Connection, idVk))
                return;
            string query = "INSERT INTO users (idVk,lastUpdate) Values(@Vk,@Date)";
            mySqlTransaction.Connection.Execute(query, new {Vk = idVk, Date = "1900-01-01"}, mySqlTransaction);
        }
        protected bool IsExists(MySqlConnection connection, string userId)
        {
            string query = "SELEct * from users where idVk = @User";
            return connection.Query(query, new { User = userId }).Any();
        }
    }
}
