using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKStats.Base.Params
{
    internal class CountsData
    {
        public int IdArtist { get; set; }
        public int Counter { get; set; }
    }
    internal class CountsParams
    {
        public string IdUser { get; set; }
        public string Today { get; set; }
       public List<CountsData> CountsData { get; set; }
    }
}
