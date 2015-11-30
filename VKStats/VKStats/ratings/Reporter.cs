using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKStats.Senders;

// Report(string userId) ??????????????????????


namespace VKStats.Ratings
{
    class Reporter
    {
       
        private const string emptyReport = "\nSorry. All playlists are empty.";
        public Dictionary<string, int> GenerateRatings(List<string> artists)
        {
           return artists.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            /*
            var result = new Dictionary<string, int>();
            artists.Sort();

            int counter = 1;
            string currentArtist = "";
            foreach (string el in artists)
            {
                if (currentArtist.Equals("") == true)
                    currentArtist = el;
                else if (currentArtist.Equals(el) != true)
                {
                    result.Add(currentArtist, counter);
                    counter = 1;
                    currentArtist = el;
                }
                else counter++;
            }
            return result;*/
        }

        private string GetUserInfo(string userId)
        {
            var userQuery = new UserQuery(userId);
            userQuery.UpdateFromApi();
            string firstName = userQuery.user.firstName;
            string lastName = userQuery.user.lastName;
            return "\nTop music of " + firstName + " " + lastName +" and his/her friends:\n";
        }

        public string GetReport(Dictionary<string, int> result,int size, string userId)
        {

            string report = GetUserInfo(userId);

            // adding results from Dictionary
            var items = from pair in result
                        orderby pair.Value descending
                        select pair;
            int i = 0;
            foreach (KeyValuePair<string, int> pair in items)
            {
                report += pair.Key + " : " + pair.Value + "\n";
                i++;
                if (i == size) break;
            }
            if(i!= 0)
                return report;
            else return emptyReport;
        }
        /*
        public void ReportToFile(string fileFullPath, Dictionary<string, int> result, int size, string userId)
        {
            string resultToFile = GetReport(result, size,userId);
            System.IO.File.WriteAllText(fileFullPath, resultToFile); //  "F:\\out.txt"               
        }
        */
    }
}
