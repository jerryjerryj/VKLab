using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKStats.ratings
{
    class Counter
    {
        Dictionary<string, int> result;
        public Counter(List<string> rate_this)
        {
            rate_this.Sort(); 
            result = new Dictionary<string, int>();
            int counter = 1;
            string current_artist = "";
            foreach (string el in rate_this)
            {
                if (current_artist.Equals("") == true)
                    current_artist = el;
                else  if (current_artist.Equals(el) != true)
                {
                    result.Add(current_artist, counter);
                    counter = 1;
                    current_artist = el;
                }
                else counter++;
            }

        }
        public string getReport(){
            var items = from pair in result
                        orderby pair.Value descending
                        select pair;

            int i = 0;
            foreach (KeyValuePair<string, int> pair in items)
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value); // TODO in returning string 
                i++;
              if (i == 20) return "end of rep";
           }
           return "nullable report";
        }
    }
}
