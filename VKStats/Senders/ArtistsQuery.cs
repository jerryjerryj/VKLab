using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace VKStats.Senders
{
    class ArtistsQuery : ApiQuery
    {
        private const string ApiMethod = "audio.get";
        private const int MaxCount = 6000;
        private string MakeNameBetter( string badName)
        {
            string goodName = badName.Trim(); // del extra spaces
            return goodName;
            //TODO split by feat. &amp and other things
            //TODO del extra symbols 
        }

        public List<string> GetArtistsFromApi(string ownerId)
        {
            string outputStr = ApiRequestWithToken(ApiMethod, "user_id=" + ownerId + "&count=");
            var returnable = new List<string>();

            var xDocument = XDocument.Parse(outputStr);
            try
            {
                foreach (var el in xDocument.Root.Elements())
                {
                    string name = MakeNameBetter(el.Element("artist").Value);
                    returnable.Add(name);
                }
            }
            catch (System.NullReferenceException e) {}// last one is empty 
            return returnable;
        }
    }
}
