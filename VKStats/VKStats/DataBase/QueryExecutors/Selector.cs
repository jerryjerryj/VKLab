using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using MySql.Data.MySqlClient;
namespace VKStats.DataBase.QueryExecutors
{
    class Selector : QueryExecutor
    {
        public Selector(MySqlConnection connection) : base(connection) { }
        public List<string[]> SelectMany(string query)
        {
            try
            {
                var reader = StartConnection(query).ExecuteReader();
                var list = new List<string[]>(); // better than string[][]?

                //Maybe, reader has function with action like these?
                while (reader.Read())
                {
                    var row = new string[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; ++i)
                    {
                        row[i] = reader.GetString(i);
                    }
                    list.Add(row);
                }
                return list;
            }
            catch (Exception) { throw; }
            finally
            {
                EndConnection();
            }
        }

        public List<string> SelectOne(string query)
        {
            try
            {
                var reader = StartConnection(query).ExecuteReader();
                var list = new List<string>();

                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
                return list;
            }
            catch (Exception) { throw; }
            finally
            {
                EndConnection();               
            }
        }

    
    }
}
