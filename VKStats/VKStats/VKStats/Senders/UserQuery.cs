using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VKStats.Objs;

namespace VKStats.Senders
{
    class UserQuery : ApiQuery
    {
        public User user { get; private set; }
        private const string ApiMethod = "users.get";
        public UserQuery(string userId) 
        {
            user = new User(userId);
        }
        public void UpdateFromApi()
        {
            string responce = ApiRequestWithToken(ApiMethod, "uids=" + user.id);

            var xDocument = XDocument.Parse(responce);
            foreach (var el in xDocument.Root.Elements())
            {
                user.lastName = el.Element("first_name").Value;
                user.firstName = el.Element("last_name").Value;
            }
        }
    }
}
