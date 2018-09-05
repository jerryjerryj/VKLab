using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Threading.Tasks;
using VKStats.Services;

// TODO parse with XPath or JsonNET
// TODO catch VkApi Errors. 

 
using VKStats.Base.Params;
using VKStats.Base.Selections;
using VKStats.Base.Transactions;
namespace VKStats
{
    class Program
    {
       
        static void Main(string[] args)
        {
           //    PERMITION FOR ACCESS
            //string url_access = "https://oauth.vk.com/authorize?client_id=" + ApiQuery.AppID + "&display=popup&scope=audio,offline&response_type=token&v=5.37";
            //System.Diagnostics.Process.Start(url_access);
            //return;

            
            Console.WriteLine("1: server\n2: userService\n3: artistService\n4: Web\n");
            string res = Console.ReadLine();
            Console.Clear();
            if (res == "1")
                new MainServer();
            else if (res == "2")
                new UserService();
            else if (res == "3")
                new ArtistService();
            else if (res == "4")
                new WebServer();

            Console.Read();
        }
    }
}
