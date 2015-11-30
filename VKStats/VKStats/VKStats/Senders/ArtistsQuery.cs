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
        public string ownerId { get; private set; }
        public List<string> artists { get; private set; }

        private void MakeNamesBetter()
        {
            //TODO split by feat. &amp and other things
            //TODO del extra symbols 
        }

        public ArtistsQuery(string ownerId)
        {
            this.ownerId = ownerId;
        }
        public void UpdateFromApi()
        {
            artists = new List<string>();
            string outputStr = ApiRequestWithToken(ApiMethod, "user_id=" + ownerId);


            var xDocument = XDocument.Parse(outputStr);
            try
            {
                foreach (var el in xDocument.Root.Elements())
                    artists.Add(el.Element("artist").Value);
            }
            catch (System.NullReferenceException e) { }// last one is empty 
            MakeNamesBetter();
        }
    }
}
