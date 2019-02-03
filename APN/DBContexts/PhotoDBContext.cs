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
    /// Database context class for the Photo Class
    /// </summary>
    public class PhotoDBContext : BaseDBContext
    {
        public PhotoDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Photo Records from the database
        /// </summary>
        public async Task<List<Photo>> GetPhotos()
        {
            var list = new List<Photo>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM photo", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToDouble(reader["PhotoCoordinateLat"]), Convert.ToDouble(reader["PhotoCoordinateLng"]), Convert.ToDouble(reader["PhotoCoordinateAlt"]));
                        list.Add(new Photo()
                        {
                            PhotoId = Convert.ToUInt32(reader["PhotoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            PhotoNo = reader["PhotoNo"].ToString(),
                            PhotoName = reader["PhotoName"].ToString(),
                            PhotoDescription = reader["PhotoDescription"].ToString(),
                            PhotoPath = reader["PhotoPath"].ToString(),
                            PhotoCoordinates = coordinates,
                            PhotoDatetime = Convert.ToDateTime(reader["PhotoDatetime"]),
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
        /// Retrieves a single Photo Record from the database
        /// </summary>
        public async Task<Photo> GetPhoto(int id)
        {
            Photo photoRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Photo WHERE PhotoId = @photoId", conn);
                cmd.Parameters.AddWithValue("@photoId", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {                    
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToDouble(reader["PhotoCoordinateLat"]), Convert.ToDouble(reader["PhotoCoordinateLng"]), Convert.ToDouble(reader["PhotoCoordinateAlt"]));
                        photoRecord = new Photo()
                        {
                            PhotoId = Convert.ToUInt32(reader["PhotoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            PhotoNo = reader["PhotoNo"].ToString(),
                            PhotoName = reader["PhotoName"].ToString(),
                            PhotoDescription = reader["PhotoDescription"].ToString(),
                            PhotoPath = reader["PhotoPath"].ToString(),
                            PhotoCoordinates = coordinates,
                            PhotoDatetime = Convert.ToDateTime(reader["PhotoDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return photoRecord;
        }
    }
}
