using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using Dapper;
using VKStats.Base.Params;
namespace VKStats.Base.Transactions
{
    class AddCountsQuery : BaseQuery<CountsParams>
    {
        private void Insert(string user, int artistId, string scanDate, int counter, MySqlTransaction mySqlTransaction)
        {
            string query = "INSERT INTO counts (idUser, idArtist, lastScan, counter) Values(@User, @Artist, @Scan, @Counter)";
            mySqlTransaction.Connection.Query<UserParams>(query, new { User = user, Artist = artistId, Scan = scanDate, Counter = counter });
        }
        protected override void ExecuteInternal(MySqlTransaction mySqlTransaction, CountsParams queryParams)
        {
            foreach (var data in queryParams.CountsData)
            {
                Insert(queryParams.IdUser, data.IdArtist, queryParams.Today, data.Counter, mySqlTransaction);
            }
            string query = "UPDATE users SET lastUpdate=@Today WHERE idVk=@User";
            mySqlTransaction.Connection.Execute(query, new {User = queryParams.IdUser, Today = queryParams.Today}, mySqlTransaction);

        }
    }
}
