using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace VKStats.Updates
{
    class Connector
    {
        public MySqlConnection mySqlConnection { get; private set; }

        public void CreateConnection(string server, string database, string login, string password)
        {
            string address = "Server=" + server + ";Database=" + database + ";Uid=" + login + ";Pwd=" + password;
            mySqlConnection = new MySqlConnection(address);
        }
        
       // private string connectionAddr = "Server=localhost;Database=test;Uid=root;Pwd=";
    }
}
