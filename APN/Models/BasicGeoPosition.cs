namespace APN.Models
{
    public class BasicGeoposition
    {
        /// <summary>
        /// The latitude of the geographic position.
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        /// The longitude of the geographic position.
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        /// The altitude of the geographic position.
        /// </summary>
        public double? Altitude { get; set; }

        /// <summary>
        /// The optional description for the location
        /// </summary>
        public string Description { get; set; }

        public BasicGeoposition() {}

        public BasicGeoposition(double latitude, double longitude, double altitude, string description)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Description = description;
        }
    }
}
