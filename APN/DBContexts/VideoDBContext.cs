﻿using APN.Model;
using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APN.DBContexts
{
    /// <summary>
    /// Database context class for the Video Class
    /// </summary>
    public class VideoDBContext : BaseDBContext
    {
        public VideoDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        /// <summary>
        /// Retrieves the whole list of Video Records from the database
        /// </summary>
        public async Task<List<Video>> GetVideos()
        {
            var list = new List<Video>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM video", conn);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("VideoCoordinateDescription")));

                        list.Add(new Video()
                        {
                            VideoId = Convert.ToUInt32(reader["VideoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            VideoNo = reader["VideoNo"].ToString(),
                            VideoName = reader["VideoName"].ToString(),
                            VideoDescription = reader["VideoDescription"].ToString(),
                            VideoPath = reader["VideoPath"].ToString(),
                            VideoCoordinates = coordinates,
                            VideoDatetime = Convert.ToDateTime(reader["VideoDatetime"]),
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
        /// Retrieves a single Video Record from the database
        /// </summary>
        public async Task<Video> GetVideo(int id)
        {
            Video videoRecord = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM Video WHERE VideoId = @videoId", conn);
                cmd.Parameters.AddWithValue("@noteId", id);
                cmd.Parameters.AddWithValue("@videoId", id);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        var coordinates = new BasicGeoposition(ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLat")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateLng")),
                                                               ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("VideoCoordinateAlt")),
                                                               ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("VideoCoordinateDescription")));

                        videoRecord = new Video()
                        {
                            VideoId = Convert.ToUInt32(reader["VideoId"]),
                            NoteId = Convert.ToUInt32(reader["NoteId"]),
                            VideoNo = reader["VideoNo"].ToString(),
                            VideoName = reader["VideoName"].ToString(),
                            VideoDescription = reader["VideoDescription"].ToString(),
                            VideoPath = reader["VideoPath"].ToString(),
                            VideoCoordinates = coordinates,
                            VideoDatetime = Convert.ToDateTime(reader["VideoDatetime"]),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            CreatedBy = Convert.ToUInt32(reader["CreatedBy"]),
                            ModifiedAt = Convert.ToDateTime(reader["ModifiedAt"]),
                            ModifiedBy = Convert.ToUInt32(reader["ModifiedBy"]),
                        };
                    }
                }
            }
            return videoRecord;
        }
    }
}
