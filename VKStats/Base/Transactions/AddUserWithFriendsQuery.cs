using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using VKStats.Base.Params;

namespace VKStats.Base.Transactions
{
    class AddUserWithFriendsQuery : BaseUserQuery<UserWithFriendsParams>
    {
        //TODO убрать повторение кода
       
        protected override void ExecuteInternal(MySqlTransaction mySqlTransaction, UserWithFriendsParams queryParams)
        {
            Insert(mySqlTransaction, queryParams.IdVk);
            foreach (string friend in queryParams.Friends)
            {
                Insert(mySqlTransaction,friend);
            }
        }
    }
}
