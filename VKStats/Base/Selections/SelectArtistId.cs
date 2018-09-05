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
    class SelectArtistId : BaseSelect<ArtistParams, int?>
    {
        protected override int? SelectInternal(MySqlConnection mySqlConnection, ArtistParams queryParams)
        {
            string query = "SELECT id from artists where name = @Artist";
            return mySqlConnection.Query<int?>(query, new { Artist = queryParams.Name}).SingleOrDefault();
        }
    }
}
