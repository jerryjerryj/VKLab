using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
namespace VKStats.Base.Transactions
{
    public abstract class BaseQuery<TQueryParams> : Base
    {
        public void Execute(TQueryParams queryParams)
        {
            string login = string.Empty;
            string password = string.Empty;
            var mySqlConnection = CreateConnection("Server=" + "127.0.0.1" + ";Database=" + "vkstats" + ";Uid=" + "root" + ";Pwd=" + "" + ";CharSet=utf8");
            var mySqlTransaction = mySqlConnection.BeginTransaction();
            try
            {
                ExecuteInternal(mySqlTransaction, queryParams);
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
               // Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                    mySqlConnection.Close();
            }
        }

        protected abstract void ExecuteInternal(MySqlTransaction mySqlTransaction, TQueryParams queryParams);      

    }
}
