using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using VKStats.Ratings;

// TODO remove useless usings of classes
// TODO catch errors
// TODO user friendly interface
// TODO parse with XPath or JsonNET

// 1. ?
// 2. MakeURLForAPI or MakeUrlForApi 

namespace VKStats
{
    class Program
    {
       
        static void Main(string[] args)
        {
           //    PERMITION FOR ACCESS
           //string url_access = "https://oauth.vk.com/authorize?client_id=" + ApiQuery.AppID + "&display=popup&scope=audio&response_type=token&v=5.37";
           //System.Diagnostics.Process.Start(url_access); 


            string userId = "13368791";

            var audioRatings = new AudioRatings(userId);

            string report = audioRatings.GetReport(userId, 10);
            Console.WriteLine(report);

            Console.Read();
        }
    }
}
