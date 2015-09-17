using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
namespace VKStats
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // PERMITION FOR ACCESS
            /*string url_access = "https://oauth.vk.com/authorize?client_id=" + GETSender.AppID+ "&display=popup&scope=friends&response_type=token&v=5.37";
             System.Diagnostics.Process.Start(url_access); */

            ratings.RateAudio ra = new ratings.RateAudio(new objs.User("13368791"));
            Console.WriteLine(ra.getReport(10));
            /*
            objs.UserAudio userAudio = new objs.UserAudio("13368791");
            List<string> str = userAudio.getArtists();*/
            //System.IO.File.WriteAllText("log.html", str);
            /*
            objs.UserFriends userFriends = new objs.UserFriends("13368791");
            List<string> friends = userFriends.getFriends();
            foreach (string friend_id in friends)
                Console.Write(friend_id + " ");*/
            /*
             if (str != null)
            {
                Console.Write(str);
            }*/
            Console.Read();
        }
    }
}
