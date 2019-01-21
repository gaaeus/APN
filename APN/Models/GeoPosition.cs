namespace APN.Models
{
    public class BasicGeoposition
    {
        /// <summary>
        /// The latitude of the geographic position.
        /// </summary>
        double Latitude;

        /// <summary>
        /// The longitude of the geographic position.
        /// </summary>
        double Longitude;

        /// <summary>
        /// The altitude of the geographic position.
        /// </summary>
        double Altitude;

        public BasicGeoposition() {}

        public BasicGeoposition(double latitude, double longitude, double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }
    }
}
