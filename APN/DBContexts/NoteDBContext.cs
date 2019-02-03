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
    /// Database context class for the Note Class
    /// </summary>
    public class NoteDBContext : BaseDBContext
    {
        public NoteDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Note Records from the database
        /// </summary>
        public async Task<List<Note>> GetNotes()
        {
            var list = new List<Note>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM note", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToDouble(reader["NoteCoordinateLat"]), Convert.ToDouble(reader["NoteCoordinateLng"]), Convert.ToDouble(reader["NoteCoordinateAlt"]));
                        list.Add(new Note()
                        {
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            CategoryId = Convert.ToUInt32(reader["CategoryId"]),
                            NoteClassification = (NoteClassification)Convert.ToUInt32(reader["NoteClassification"]),
                            NoteTitle = reader["NoteTitle"].ToString(),
                            APP_GUID = reader["APP_GUID"].ToString(),
                            NoteContent = reader["NoteContent"].ToString(),
                            NoteCoordinates = coordinates,
                            NoteDatetime = Convert.ToDateTime(reader["NoteDatetime"]),
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
        /// Retrieves a single Note Record from the database
        /// </summary>
        public async Task<Note> GetNote(int id)
        {
            Note noteRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM note", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(Convert.ToDouble(reader["NoteCoordinateLat"]), Convert.ToDouble(reader["NoteCoordinateLng"]), Convert.ToDouble(reader["NoteCoordinateAlt"]));
                        noteRecord = new Note()
                        {
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            CategoryId = Convert.ToUInt32(reader["CategoryId"]),
                            NoteClassification = (NoteClassification)Convert.ToUInt32(reader["NoteClassification"]),
                            NoteTitle = reader["NoteTitle"].ToString(),
                            APP_GUID = reader["APP_GUID"].ToString(),
                            NoteContent = reader["NoteContent"].ToString(),
                            NoteCoordinates = coordinates,
                            NoteDatetime = Convert.ToDateTime(reader["NoteDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return noteRecord;
        }
    }
}
