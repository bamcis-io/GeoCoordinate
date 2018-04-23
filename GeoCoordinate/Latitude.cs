using System;

namespace BAMCIS.GIS
{
    /// <summary>
    /// A latitude object represented in degrees, minutes, seconds
    /// </summary>
    public sealed class Latitude : Coordinate
    {
        #region Constructors

        /// <summary>
        /// Creates a new latitude coordinate
        /// </summary>
        /// <param name="degrees">The degrees in the coordinate</param>
        /// <param name="minutes">The minutes in the coordinate</param>
        /// <param name="seconds">The seconds in the coordinate</param>
        public Latitude(int degrees, int minutes, int seconds) : base(degrees, minutes, seconds, CoordinateType.LATITUDE)
        { }

        public Latitude(double decimalDegrees) : base(decimalDegrees, CoordinateType.LATITUDE)
        { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Creates a new latitude from degrees minutes seconds
        /// </summary>
        /// <param name="decimalDegrees">The decimal degrees of the coordinate</param>
        /// <returns>Latitude</returns>
        public static Latitude FromDecimalDegrees(double decimalDegrees)
        {
            // The constructor will provide the error checking
            return new Latitude(decimalDegrees);
        }

        /// <summary>
        /// Creates a new latitude from degrees, minutes, seconds
        /// </summary>
        /// <param name="degrees">The degrees of the coordinate</param>
        /// <param name="minutes">The minutes of the coordinate</param>
        /// <param name="seconds">The seconds of the coordinate</param>
        /// <returns>Latitude</returns>
        public static Latitude FromDms(int degrees, int minutes, int seconds)
        {
            // The constructor will provide the error checking
            return new Latitude(degrees, minutes, seconds);
        }

        #endregion
    }
}
