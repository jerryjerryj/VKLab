using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
namespace VKStats.DataBase
{
 abstract class DBEntity
    {
        protected MySqlConnection connection;
        public DBEntity(MySqlConnection connection)
        {
            this.connection = connection;
        }
    }
}
