using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APN.Database
{
    public class DBManager
    {
        private const string connectionString = "Data Source=ROOMPC;Initial Catalog = APN_Default; Integrated security = true";

        SqlConnection sqlConnection { get; set; }

        public DBManager()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}
