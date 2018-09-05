using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
using VKStats.Base.Params;
using VKStats.Base.Transactions;
using VKStats.Senders;
namespace VKStats.Services
{
    class UsersToDataBase
    {
        string userId;
        public UsersToDataBase( string userId)
        {
            this.userId = userId;
        }
        public void AddUser()
        {
            var userParams = new UserParams();
            userParams.IdVk = userId;
            var query = new AddUserQuery();
            query.Execute(userParams);
        }
        public void AddUserWithFriends()
        {
            var friends = new FriendsQuery().UpdateFromApi(userId);

            var parameters = new UserWithFriendsParams();
            parameters.IdVk = userId;
            parameters.Friends = friends;

            var query = new AddUserWithFriendsQuery();
            query.Execute(parameters);

        }
    }
}
