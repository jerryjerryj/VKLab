using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VKStats.objs
{
    class UserFriends : GETSender
    {
        string user_id;
        public UserFriends(string user_id)
        {
            this.user_id = user_id;
        }
        public List<string> getFriends()
        {
            string outputStr = APIRequest("friends.get", "user_id="+user_id);

            List<string> friends = new List<string>();

            XDocument xDocument = XDocument.Parse(outputStr);
            foreach (XElement el in xDocument.Root.Elements())
                friends.Add(el.Value);        
            
            return friends;
        }
    }
}
