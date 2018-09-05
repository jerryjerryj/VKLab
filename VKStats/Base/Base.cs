using MySql.Data.MySqlClient;
namespace VKStats.Base
{
    public abstract class Base
    {
        protected MySqlConnection CreateConnection(string connectionStr)
        {
            var mySqlConnection = new MySqlConnection(connectionStr);
            mySqlConnection.Open();
            return mySqlConnection;
        }
    }
}
