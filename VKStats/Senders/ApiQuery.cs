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
        public static string AppID = ""; //DELETED
        private static string _accessToken = ""; //DELETED

        private string MakeUrlForApi(string methodName, string parameters)
        {
            string temp ="https://api.vk.com/method/" + methodName + ".xml?" + parameters;
            return temp;
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
                webClient.Encoding = Encoding.UTF8;
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
