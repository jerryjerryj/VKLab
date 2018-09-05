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
    class AddArtistQuery : BaseQuery<ArtistParams>
    {
        protected override void ExecuteInternal(MySqlTransaction mySqlTransaction, ArtistParams queryParams)
        {
            string query = "INSERT INTO artists (name) Values(@Name)";
            try // TODO в бд name is unique
            {
                mySqlTransaction.Connection.Execute(query, new { Name = queryParams.Name },mySqlTransaction);
            }
            catch (Exception) { }
        }

    }
}
