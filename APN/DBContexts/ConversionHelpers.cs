using System;
using System.Data.Common;

namespace APN.DBContexts
{
    public static class ConversionHelpers
    {
        public static string SafeGetString(this DbDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        public static double SafeGetDouble(this DbDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return Convert.ToDouble(reader.GetValue(colIndex));
            return 0.0d;
        }
    }
}
