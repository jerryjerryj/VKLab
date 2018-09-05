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
    class SelectNumberOfArtists : BaseSelect<ArtistParams, int?>
    {
        protected override int? SelectInternal(MySqlConnection mySqlConnection, ArtistParams queryParams)
        {
            string query = "SELECT count(*) result from artists";
            return mySqlConnection.Query<int?>(query).SingleOrDefault();
        }
    }
}
