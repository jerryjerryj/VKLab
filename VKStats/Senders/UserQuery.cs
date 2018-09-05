using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VKStats.Senders
{
    class UserQuery : ApiQuery
    {
        private const string ApiMethod = "users.get";
        public void UpdateFromApi(string userId)
        {
            //string responce = ApiRequestWithToken(ApiMethod, "uids=" + userId);
            //User user= new User(userId);
            //var xDocument = XDocument.Parse(responce);
            //foreach (var el in xDocument.Root.Elements())
            //{
            //    user.lastName = el.Element("first_name").Value;
            //    user.firstName = el.Element("last_name").Value;
            //}
            //return user;
        }
    }
}
