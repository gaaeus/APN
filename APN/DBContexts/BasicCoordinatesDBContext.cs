using APN.Models;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using static APN.Common;

namespace APN.DBContexts
{
    public class BasicCoordinatesDBContext : BaseDBContext
    {
        public async Task SaveGeoposition(BasicGeoposition geoposition)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var strSQL = @"INSERT INTO geoposition (
                                                    ParentId,
                                                    ParentType,
                                                    Latitude,
                                                    Longitude,
                                                    Altitude,
                                                    Description,
                                                    CreatedBy,
                                                    CreatedAt,
                                                    ModifiedBy,
                                                    ModifiedAt
                                                )
                                                VALUES (
                                                    @ParentId,
                                                    @ParentType,
                                                    @Latitude,
                                                    @Longitude,
                                                    @Altitude,
                                                    @Description,
                                                    @CreatedBy,
                                                    NOW(),
                                                    @ModifiedBy,
                                                    NOW()
                                                );";

                    var cmd = new MySqlCommand(strSQL, conn);

                    cmd.Parameters.AddWithValue("@ParentId", geoposition.ParentId);
                    cmd.Parameters.AddWithValue("@ParentType", geoposition.ParentType);
                    cmd.Parameters.AddWithValue("@Latitude", geoposition.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", geoposition.Longitude);
                    cmd.Parameters.AddWithValue("@Altitude", geoposition.Altitude);
                    cmd.Parameters.AddWithValue("@Description", geoposition.Description);
                    cmd.Parameters.AddWithValue("@CreatedBy", 100);
                    cmd.Parameters.AddWithValue("@ModifiedBy", 100);

                    cmd.Prepare();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BasicGeoposition> GetGeoposition(uint parentId, CoordinatesParentType parentType)
        {
            BasicGeoposition geoposition = null;

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(@"SELECT * 
FROM BasicGeoposition 
WHERE ParentId = @parentId 
AND ParentType = @parentType", conn);
                cmd.Parameters.AddWithValue("@parentId", parentId);
                cmd.Parameters.AddWithValue("@parentType", parentType);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        geoposition = new BasicGeoposition()
                        {
                            ParentId = Convert.ToUInt32(reader["ParentId"]),
                            ParentType = (CoordinatesParentType)Convert.ToUInt32(reader["ParentType"]),
                            Latitude = ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("Latitude")),
                            Longitude = ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("Longitude")),
                            Altitude = ConversionHelpers.SafeGetDouble(reader, reader.GetOrdinal("Altitude")),
                            Description = ConversionHelpers.SafeGetString(reader, reader.GetOrdinal("Description"))
                        };
                    }
                }
            }

            return geoposition;
        }


        public async Task DeleteGeoposition(BasicGeoposition geoposition)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();

                    var strSQL = @"DELETE
                                    FROM geoposition
                                    WHERE   ParentId = @ParentId,
                                    AND     ParentType = @ParentType";

                    var cmd = new MySqlCommand(strSQL, conn);

                    cmd.Parameters.AddWithValue("@ParentId", geoposition.ParentId);
                    cmd.Parameters.AddWithValue("@ParentType", geoposition.ParentType);

                    cmd.Prepare();

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
