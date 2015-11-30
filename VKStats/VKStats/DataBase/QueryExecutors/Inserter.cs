using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

using VKStats.DataBase.QueryExecutors;
namespace VKStats.DataBase.QueryExecutors
{
    class Inserter : QueryExecutor
    {
        public Inserter(MySqlConnection connection) : base(connection){}
        public void InsertOne(string query, Dictionary<string, object> parameterValues)
        {
            try
            {
                var command = StartConnection(query);
                foreach (KeyValuePair<string, object> pair in parameterValues)
                {
                    command.Parameters.AddWithValue(pair.Key, pair.Value);
                }
                command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                EndConnection();
            }
        }
    }
}
