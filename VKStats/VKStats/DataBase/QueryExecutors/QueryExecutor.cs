using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
namespace VKStats.DataBase.QueryExecutors
{
    abstract class QueryExecutor : DBEntity
    {
        public QueryExecutor(MySqlConnection connection) : base(connection) { }
        protected MySqlCommand StartConnection(string command)
        {
            var cmd = new MySqlCommand(command, connection);
            connection.Open();
            return cmd;
        }
        protected void EndConnection()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
