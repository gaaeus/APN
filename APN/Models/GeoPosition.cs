namespace APN.Models
{
    public class BasicGeoposition
    {
        /// <summary>
        /// The latitude of the geographic position.
        /// </summary>
        public double? Latitude;

        /// <summary>
        /// The longitude of the geographic position.
        /// </summary>
        public double? Longitude;

        /// <summary>
        /// The altitude of the geographic position.
        /// </summary>
        public double? Altitude;

        public BasicGeoposition() {}

        public BasicGeoposition(double latitude, double longitude, double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }
    }
}
