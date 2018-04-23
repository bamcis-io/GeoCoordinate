using System;

namespace BAMCIS.GIS
{
    /// <summary>
    /// A longitude object expressed in degrees, minutes, seconds
    /// </summary>
    public sealed class Longitude : Coordinate
    {
        #region Constructors

        /// <summary>
        /// Creates a new longitude coordinate
        /// </summary>
        /// <param name="degrees">The degrees in the coordinate</param>
        /// <param name="minutes">The minutes in the coordinate</param>
        /// <param name="seconds">The seconds in the coordinate</param>
        public Longitude(int degrees, int minutes, int seconds) : base(degrees, minutes, seconds, CoordinateType.LONGITUDE)
        { }

        /// <summary>
        /// Creates a new longitude coordinate
        /// </summary>
        /// <param name="decimalDegrees">The decimal degrees of the coordinate</param>
        public Longitude(double decimalDegrees) : base(decimalDegrees, CoordinateType.LONGITUDE)
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new longitude coordinate
        /// </summary>
        /// <param name="decimalDegrees">The decimal degrees of the coordinate</param>
        /// <returns>Longitude</returns>
        public static Longitude FromDecimalDegrees(double decimalDegrees)
        {
            // The constructor will provide the error checking
            return new Longitude(decimalDegrees);
        }

        /// <summary>
        /// Creates a new longitude from degrees, minutes, seconds
        /// </summary>
        /// <param name="degrees">The degrees of the coordinate</param>
        /// <param name="minutes">The minutes of the coordinate</param>
        /// <param name="seconds">The seconds of the coordinate</param>
        /// <returns>Longitude</returns>
        public static Longitude FromDms(int degrees, int minutes, int seconds)
        {
            // The constructor will provide the error checking
            return new Longitude(degrees, minutes, seconds);
        }

        #endregion
    }
}
