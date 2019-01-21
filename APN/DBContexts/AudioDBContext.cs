using APN.Model;
using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APN.DBContexts
{
    /// <summary>
    /// Database context class for the Audio Class
    /// </summary>
    public class AudioDBContext : BaseDBContext
    {
        public AudioDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Audio Records from the database
        /// </summary>
        public async Task<List<Audio>> GetAudios()
        {
            var list = new List<Audio>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM audio", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToDouble(reader["AudioCoordinateLat"]), Convert.ToDouble(reader["AudioCoordinateLng"]), Convert.ToDouble(reader["AudioCoordinateAlt"]));
                        list.Add(new Audio()
                        {
                            AudioId = Convert.ToUInt32(reader["AudioId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            AudioNo = reader["AudioNo"].ToString(),
                            AudioName = reader["AudioName"].ToString(),
                            AudioDescription = reader["AudioDescription"].ToString(),
                            AudioPath = reader["AudioPath"].ToString(),
                            AudioCoordinates = coordinates,
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

        /// <summary>
        /// Retrieves a single Audio Record from the database
        /// </summary>
        public async Task<Audio> GetAudio(int id)
        {
            Audio audioRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM audio WHERE AudioId = @audioId", conn);
                cmd.Parameters.AddWithValue("@audioId", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var coordinates = new BasicGeoposition(Convert.ToDouble(reader["AudioCoordinateLat"]), Convert.ToDouble(reader["AudioCoordinateLng"]), Convert.ToDouble(reader["AudioCoordinateAlt"]));
                    while (reader.Read())
                    {
                        audioRecord = new Audio()
                        {
                            AudioId = Convert.ToUInt32(reader["AudioId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            AudioNo = reader["AudioNo"].ToString(),
                            AudioName = reader["AudioName"].ToString(),
                            AudioDescription = reader["AudioDescription"].ToString(),
                            AudioPath = reader["AudioPath"].ToString(),
                            AudioCoordinates = coordinates,
                            AudioDatetime = Convert.ToDateTime(reader["AudioDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return audioRecord;
        }
    }
}
