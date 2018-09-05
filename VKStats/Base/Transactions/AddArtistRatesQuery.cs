using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using VKStats.Base.Params;

namespace VKStats.Base.Transactions
{
    class AddArtistRatesQuery : BaseQuery<ArtistDateParams>
    {
        private int? GetCount(string date, int artistId, MySqlConnection connection)
        {
            string query = "SELECT sum(counter) result FROM counts WHERE idArtist=@Artist and lastScan=@Day";
            return connection.Query<int?>(query, new { Artist = artistId, Day = date }).Single();
        }
        protected override void ExecuteInternal(MySqlTransaction mySqlTransaction, ArtistDateParams queryParams)
        {

                int? countForArtist = GetCount(queryParams.Date, queryParams.Id, mySqlTransaction.Connection);
                if (countForArtist != null)
                {
                    string queryInsert = "Insert into rates_of_all_users(artistId, count, date) Values (@Artist, @Count, @Date)";
                    var param = new { Artist = queryParams.Id, Count = countForArtist, Date = queryParams.Date };
                    mySqlTransaction.Connection.Execute(queryInsert, param, mySqlTransaction);
                }
           
        }
    }
}

/*
  //берём кол-во
            var size = mySqlTransaction.Connection.Query<long>("Select count(*) result From artists").Single();
            // проходим по  всем
            for (int i = 1; i <= size; ++i)
            {
                //Console.WriteLine(i);
                int? countForArtist = GetCount(queryParams.Date, i, mySqlTransaction.Connection);
                if (countForArtist != null)
                {
                    string queryInsert = "Insert into rates_of_all_users(artistId, count, date) Values (@Artist, @Count, @Date)";
                    var param = new { Artist = i, Count = countForArtist, Date = queryParams.Date };
                    mySqlTransaction.Connection.Execute(queryInsert, param, mySqlTransaction);
                }
            }*/