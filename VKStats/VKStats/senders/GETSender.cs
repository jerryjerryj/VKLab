﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKStats
{
    class GETSender
    {
        public static string AppID = "";
        private static string access_token = "";
        private string makeURLForAPI(string method_name, string parameters)
        {
            return "https://api.vk.com/method/" + method_name + ".xml?" + parameters + "&access_token="+access_token;
        }
        public static string GETRequest(string url)
        {
            try
            {
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.Stream stream = resp.GetResponseStream();
                System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                string Out = sr.ReadToEnd();
                sr.Close();
                return Out;
            }
            catch (Exception e)
            {
                /* Console.Write(ufe.ToString());
                  return null;*/
                return e.ToString();
            }

        }
        protected string APIRequest(string method_name, string parameters){
            return GETRequest(makeURLForAPI(method_name, parameters));
        }
    }
}
