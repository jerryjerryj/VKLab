using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace VKStats.DataBase.Controllers
{
    class CountsController : DBEntity
    {
        public CountsController(MySqlConnection mySqlConnection): base(mySqlConnection){}
    }
}
