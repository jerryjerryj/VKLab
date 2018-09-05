using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using VKStats.Base.Params;

namespace VKStats.Base.Transactions
{
    class AddUserQuery : BaseUserQuery<UserParams>
    {
        protected override void ExecuteInternal(MySqlTransaction mySqlTransaction, UserParams queryParams)
        {
            Insert(mySqlTransaction, queryParams.IdVk);
        }
    }
}
