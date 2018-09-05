using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKStats.Services
{
    public class Service
    {
        public const string dateFormat = "yyyy-MM-dd";

        protected string GetToday()
        {
            return DateTime.Now.Date.ToString(dateFormat);
        }
    }
}
