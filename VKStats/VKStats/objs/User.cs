using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VKStats.objs
{
    class User :  GETSender
    {
        private string uid; //id или screen_name
        public string status; // on off
        public string first_name;
        public string last_name;
        public User(string uid)
        {
            string fields = "online";
            string responce = APIRequest("users.get", "uids=" + uid + "&fields=" + fields);
            XDocument xDocument = XDocument.Parse(responce);
            foreach (XElement el in xDocument.Root.Elements()){
                this.uid = el.Element("uid").Value;
                first_name = el.Element("first_name").Value;
                last_name = el.Element("last_name").Value;
                if (el.Element("online").Value == "0")
                    status = "offline";
                status = "online";
            }
            this.uid = uid;
        }
        public string getId(){
            return uid;
        }
        public string getStatus()
        {
            return status;
        }
        public string getFirstName()
        {
            return first_name;
        }
        public string getLastName()
        {
            return last_name;
        }
    }
}
