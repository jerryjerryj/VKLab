using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKStats.Base.Params
{
    internal class UserWithFriendsParams : UserParams
    {
        public List<string> Friends { get; set; }
    }
}
