using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKStats.Senders;

namespace VKStats.Ratings
{
    class Collector 
    {
        private Reporter reporter;
        private string userId;

        public Collector(string userId)
        {
            this.userId = userId;
        }
        private List<string> AppendArtists(string userId)
        {
            var artistsQuery = new ArtistsQuery(userId);
            artistsQuery.UpdateFromApi();
            return artistsQuery.artists;

        }
        private List<string> AppendFriendsArtists(string userId)
        {
            var friendsQuery = new FriendsQuery(userId);
            friendsQuery.UpdateFromApi();

            var friends = friendsQuery.friends;

            var friendsArtists = new List<string>();
            foreach (string friend in friends)
            {
                friendsArtists.AddRange(AppendArtists(friend));
                System.Threading.Thread.Sleep(350);
            }
            return friendsArtists;
        }

        public Dictionary<string, int> MakeRate(string userId)
        {
            var allArtists = new List<string>();
            allArtists.AddRange(AppendArtists(userId));
            allArtists.AddRange(AppendFriendsArtists(userId));
            reporter = new Reporter();
            return reporter.GenerateRatings(allArtists);
        }
        public string GetReport(string userId, int size){
            var rate = MakeRate(userId);
            return reporter.GetReport(rate, size, userId);
        }
    }
}
