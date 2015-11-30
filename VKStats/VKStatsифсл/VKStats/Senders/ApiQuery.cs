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
        public static string AppID = "5071996";
        private static string _accessToken = "e849cf95e68fedd6fba5bd8b728e1975e4205d397c983f221b650cbcb781da289371db54ae7d113447f55";

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
