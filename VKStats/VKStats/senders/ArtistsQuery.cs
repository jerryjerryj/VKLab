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
        private const string CountMethod = "audio.getCount";
        private const int MaxCount = 6000;
        public string ownerId { get; private set; }
        public List<string> artists { get; private set; }

        private void MakeNamesBetter()
        {

            //TODO split by feat. &amp and other things
            //TODO del extra symbols 
        }

        private List<string> GetArtistsFromApi()
        {
            string outputStr = ApiRequestWithToken(ApiMethod, "user_id=" + ownerId + "&count=");
            var returnable = new List<string>();

            var xDocument = XDocument.Parse(outputStr);
            try
            {
                foreach (var el in xDocument.Root.Elements())
                    returnable.Add(el.Element("artist").Value);
            }
            catch (System.NullReferenceException e) {}// last one is empty 
            return returnable;
        }
        private int GetCountFromApi()
        {
            string count = ApiRequestWithToken(CountMethod, "owner_id=" + ownerId);
            var xDocument = XDocument.Parse(count);
            try
            {
                int counter;
                string number = xDocument.Root.Value;
                Int32.TryParse(number , out counter);
                return counter;
            }
            catch (System.NullReferenceException e) { }
            return 0;
        }

        public ArtistsQuery(string ownerId)
        {
            this.ownerId = ownerId;
        }
        public void UpdateFromApi()
        {
            artists = new List<string>();

            artists.AddRange(GetArtistsFromApi());

        }
    }
}


// doesn't help
//int numberOfAudios = GetCountFromApi();
//while (artists.Count < numberOfAudios)    //at least, one time scan will be
//{
//    artists.AddRange(GetArtistsFromApi());
//}          

//string debug = "";
//foreach (string artist in artists)
//    debug += artist+"\r\n";
//System.IO.File.WriteAllText("F:\\result0.2.txt", debug);
//MakeNamesBetter();

