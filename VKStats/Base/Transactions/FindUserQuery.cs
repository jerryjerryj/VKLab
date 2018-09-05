using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using VKStats.Base.Queries.Params;

namespace VKStats.Base.Queries
{
    class FindUserQuery : BaseQuery<AddUserParams>
    {        
        public bool isExists  {private set; get;}
        protected override void ExecuteInternal(AddUserParams queryParams)
        {
            string query = "SELECT * FROM users WHERE idVk=@userID";
            var command = new MySqlCommand(query, mySqlConnection);
            command.Parameters.AddWithValue("@userID", queryParams.IdVk);
            command.ExecuteNonQuery();
            var reader = command.ExecuteReader();
            isExists = reader.HasRows;
        
        }
    }
}
