using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKStats.objs;

namespace VKStats.ratings
{
    class RateAudio // Couter an be useful for other  different ratings, not only for music artists
    {
        private List<string> artists;

        // TODO 
        private List<string> MakeNamesBetter(List<string> artists)
        {
            //TODO split by feat. &amp and other things
            // TODO del extra symbols 
            return artists;
        }
        public RateAudio(User user) //TODO info abuout this main user
        {
            string user_id = user.getId();

            // getting user's artists
            artists = new UserAudio(user_id).getArtists();

            UserFriends userFriends = new UserFriends(user_id);
            
            
            // getting friends' artists
            List<string> friends = userFriends.getFriends();
            foreach (string friend in friends)
            {
                List<string> artist_temp = new UserAudio(friend).getArtists();
                if(artist_temp!=null)
                    artists.AddRange(artist_temp);
            }

        }
        public string getReport(int number_of_lines){            
            Counter counter = new Counter(artists);
            return "ADD USER INFO HERE "+ counter.getReport();
        }
    }
}
