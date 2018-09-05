using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VKStats.Senders
{
    class FriendsQuery : ApiQuery
    {
        private const string ApiMethod = "friends.get";
        public List<string> UpdateFromApi(string ownerId)
        {
            string outputStr = ApiRequestWithToken(ApiMethod, "user_id=" + ownerId);

            var friends = new List<string>();

            var xDocument = XDocument.Parse(outputStr);
            foreach (var el in xDocument.Root.Elements())
                friends.Add(el.Value);
            return friends;   
        }
    }
}
