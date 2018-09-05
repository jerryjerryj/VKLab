using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

namespace VKStats.Base.Selections
{
    public abstract class  BaseSelect<TQueryParams, TQueryresult> : Base
    {
        
        public TQueryresult Execute(TQueryParams queryParams)
        {
            var mySqlConnection = CreateConnection("Server=" + "127.0.0.1"+";Database=" + "vkstats" + ";Uid=" + "root" + ";Pwd=" + "" + ";CharSet=utf8");
            try
            {
                return SelectInternal(mySqlConnection, queryParams);
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                if (mySqlConnection.State == ConnectionState.Open)
                    mySqlConnection.Close();
            }
        }

        protected abstract TQueryresult SelectInternal(MySqlConnection mySqlConnection, TQueryParams queryParams);
    }
}
