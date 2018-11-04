using APN.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APN.DBContexts
{
    public class AudioDBContext
    {
        public string ConnectionString { get; set; }

        public AudioDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Audio> GetAudios()
        {
            List<Audio> list = new List<Audio>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM audio", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Audio()
                        {
                            AudioId = Convert.ToUInt32(reader["AudioId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            AudioNo = reader["AudioNo"].ToString(),
                            AudioName = reader["AudioName"].ToString(),
                            AudioDescription = reader["AudioDescription"].ToString(),
                            AudioPath = reader["AudioPath"].ToString(),
                            AudioCoordinates = new Tuple<double, double, double>(Convert.ToDouble(reader["AudioCoordinateLat"]), Convert.ToDouble(reader["AudioCoordinateLng"]), Convert.ToDouble(reader["AudioCoordinateAlt"])),
                            AudioDatetime = Convert.ToDateTime(reader["AudioDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        });
                    }
                }
            }
            return list;
        }
    }
}
