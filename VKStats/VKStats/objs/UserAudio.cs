using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace VKStats.objs
{
    class UserAudio : GETSender
    {
        string owner_uid;
        public UserAudio(string owner_uid)
        {
            this.owner_uid = owner_uid;
        }
        public List<string> getArtists(){
            string outputStr = APIRequest("audio.get", "user_id=" + owner_uid);
            List<string> artists = new List<string>();

            XDocument xDocument = XDocument.Parse(outputStr);
            try
            {
                foreach (XElement el in xDocument.Root.Elements())
                    artists.Add(el.Element("artist").Value);
            }
            catch (System.NullReferenceException e) { }// last one is empty 
            return artists;
        }
    }
}
