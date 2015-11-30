using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace VKStats
{
    class ApiQuery
    {
        public static string AppID = "5168319";  //"5071996";
        private static string _accessToken = "2f4ebb3f21a9c6f865af0c782b6e9b3fda24a26b18c98f8573239dd417939123bfe25b2680c8ddea8a296";

        private string MakeUrlForApi(string methodName, string parameters)
        {
            return "https://api.vk.com/method/" + methodName + ".xml?" + parameters;
        }


        // так или просто добавить токен в APWT ?
        // или старый вариант + флаг
        private string MakeUrlForApiWithToken(string methodName, string parameters)
        {
            return MakeUrlForApi(methodName,parameters) + "&access_token=" + _accessToken;
        }

        public static string GetRequest(string url)
        {            
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }

        protected string ApiRequest(string methodName, string parameters)
        {
            return GetRequest(MakeUrlForApi(methodName, parameters));
        }
        protected string ApiRequestWithToken(string methodName, string parameters){

            return GetRequest(MakeUrlForApiWithToken(methodName, parameters));

        }
    }
}
