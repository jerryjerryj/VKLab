using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using VKStats.Ratings;
using VKStats.Updates;

// TODO parse with XPath or JsonNET
// TODO catch VkApi Errors. 


namespace VKStats
{
    class Program
    {
       
        static void Main(string[] args)
        {
           //    PERMITION FOR ACCESS
            //string url_access = "https://oauth.vk.com/authorize?client_id=" + ApiQuery.AppID + "&display=popup&scope=audio&response_type=token&v=5.37";
            //System.Diagnostics.Process.Start(url_access);
            //return;

            //string userId = "13368791";
            //var audioRatings = new Collector(userId);
            //string report = audioRatings.GetReport(userId, 30);
            //Console.WriteLine(report);

<<<<<<< HEAD
            var dUpdate = new DailyUpdate();
            dUpdate.Start();
=======
            ratings.RateAudio ra = new ratings.RateAudio(new objs.User("1"));
            Console.WriteLine(ra.getReport(10));
            /*
            objs.UserAudio userAudio = new objs.UserAudio("1");
            List<string> str = userAudio.getArtists();*/
            //System.IO.File.WriteAllText("log.html", str);
            /*
            objs.UserFriends userFriends = new objs.UserFriends("1");
            List<string> friends = userFriends.getFriends();
            foreach (string friend_id in friends)
                Console.Write(friend_id + " ");*/
            /*
             if (str != null)
            {
                Console.Write(str);
            }*/
>>>>>>> origin/master
            Console.Read();
        }
    }
}
