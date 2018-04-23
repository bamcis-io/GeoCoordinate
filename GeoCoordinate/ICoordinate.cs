namespace BAMCIS.GIS
{
    /// <summary>
    /// Provides standard methods for a coordinate
    /// </summary>
    public interface ICoordinate
    {
        /// <summary>
        /// Gets the latitude
        /// </summary>
        /// <returns>The latitude</returns>
        Latitude GetLatitude();

        // <summary>
        /// Gets the longitude
        /// </summary>
        /// <returns>The longitude</returns>
        Longitude GetLongitude();

        /// <summary>
        /// Gets the initial bearing in degrees to another geographic point from this 
        /// geographic coordinate based on the Haversine formula
        /// </summary>
        /// <param name="destination">The geographic coordinate of the destination</param>
        /// <returns>The bearing from source to destination in degrees</returns>
        double InitialBearingTo(ICoordinate destination);

        /// <summary>
        /// Gets the bearing in degrees to another geographic point from this 
        /// geographic coordinate based on the Rhumb formula
        /// </summary>
        /// <param name="destination">The geographic coordinate of the destination</param>
        /// <returns>The bearing from source to destination in degrees</returns>
        double RhumbBearingTo(ICoordinate destination);

        /// <summary>
        /// Gets the distance from this coordinate to another geocoordinate using the Haversine formula
        /// </summary>
        /// <param name="destination">The destination</param>
        /// <param name="distanceType">The distance type the results will be returned in, i.e. kilometers</param>
        /// <returns>The distance to the destination</returns>
        double DistanceTo(ICoordinate destination, DistanceType distanceType);

        /// <summary>
        /// Gets the distance from this coordinate to another geocoordinate using a rhumb line
        /// </summary>
        /// <param name="destination">The destination coordinate</param>
        /// <param name="distanceType">The distance type the results will be returned in, i.e. kilometers</param>
        /// <returns>The distance to the destination</returns>
        double RhumbDistanceTo(ICoordinate destination, DistanceType distanceType);

        /// <summary>
        /// Finds the destination geocoordinate using the bearing and distance travelled from this coordinate
        /// </summary>
        /// <param name="bearing">The direction of travel from the source in degrees</param>
        /// <param name="distance">The distance traveled</param>
        /// <param name="distanceType">The unit of measure that the distance is provided in</param>
        /// <returns>The destination geocoordinate</returns>
        ICoordinate FindDestination(double bearing, double distance, DistanceType distanceType);

        /// <summary>
        /// Finds the destination from this coordinate using a rhumb line
        /// </summary>
        /// <param name="bearing">The bearing to the destination in degrees</param>
        /// <param name="distance">The distance away from the source</param>
        /// <param name="distanceType">The unit of measure that the distance is provided in</param>
        /// <returns>The destination</returns>
        ICoordinate FindRhumbDestination(double bearing, double distance, DistanceType distanceType);
    }
}
