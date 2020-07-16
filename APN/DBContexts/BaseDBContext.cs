using MySql.Data.MySqlClient;

namespace APN.DBContexts
{
    public class BaseDBContext
    {
        public string ConnectionString { get; set; }
        public BasicCoordinatesDBContext BasicCoordinatesDBContext { get; set; }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

    }
}
