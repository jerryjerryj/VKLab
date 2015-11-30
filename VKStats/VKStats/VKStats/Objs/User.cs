using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKStats.Objs
{
    class User
    {
        public string id { get; private set; } //id или screen_name
        public string lastName { get; set; } // get-set is AWESOME
        public string firstName { get; set; }
        public User(string id)
        {           
            this.id = id;
        }

    }
}
