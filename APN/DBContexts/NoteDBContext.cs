using APN.Model;
using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
                        var coordinates = new BasicGeoposition( ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLat")),
                                                                ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLng")),
                                                                ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateAlt")));

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
                        var coordinates = new BasicGeoposition(ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("NoteCoordinateAlt")));
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

        public async Task<int> CreateNote(Note newNote)
        {
            int newId = -1;

            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var strSQL = @"INSERT INTO note (
                                                    CategoryId,
                                                    NoteClassification,
                                                    NoteTitle,
                                                    APP_GUID,
                                                    NoteContent,
                                                    NoteCoordinateLat,
                                                    NoteCoordinateLng,
                                                    NoteCoordinateAlt,
                                                    NoteDatetime,
                                                    CreatedBy,
                                                    CreatedAt,
                                                    ModifiedBy,
                                                    ModifiedAt
                                                )
                                                VALUES (
                                                    @CategoryId,
                                                    @NoteClassification,
                                                    @NoteTitle,
                                                    @APP_GUID,
                                                    @NoteContent,
                                                    @NoteCoordinateLat,
                                                    @NoteCoordinateLng,
                                                    @NoteCoordinateAlt,
                                                    @NoteDatetime,
                                                    @CreatedBy,
                                                    NOW(),
                                                    @ModifiedBy,
                                                    NOW()
                                                );
                                                SELECT LAST_INSERT_ID();";

                    var cmd = new MySqlCommand(strSQL, conn);

                    cmd.Parameters.AddWithValue("@CategoryId", newNote.CategoryId);
                    cmd.Parameters.AddWithValue("@NoteClassification", newNote.NoteClassification);
                    cmd.Parameters.AddWithValue("@NoteTitle", newNote.NoteTitle);
                    cmd.Parameters.AddWithValue("@APP_GUID", newNote.APP_GUID);
                    cmd.Parameters.AddWithValue("@NoteContent", newNote.NoteContent);
                    cmd.Parameters.AddWithValue("@NoteCoordinateLat", newNote.NoteCoordinates.Latitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateLng", newNote.NoteCoordinates.Longitude);
                    cmd.Parameters.AddWithValue("@NoteCoordinateAlt", newNote.NoteCoordinates.Altitude);
                    cmd.Parameters.AddWithValue("@NoteDatetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CreatedBy", 100);
                    cmd.Parameters.AddWithValue("@ModifiedBy", 100);

                    cmd.Prepare();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            newId = Convert.ToInt32(reader["LAST_INSERT_ID()"]);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
            return newId;
        }

        public async Task UpdateNote(Note note)
        {

        }
    }
}
