using System;

namespace BAMCIS.GIS
{
    /// <summary>
    /// A latitude or longitude coordinate
    /// </summary>
    public abstract class Coordinate
    {
        #region Public Properties

        /// <summary>
        /// The number of degrees in the coordinate
        /// </summary>
        public int Degrees { get; }

        /// <summary>
        /// The number of minutes in the coordinate
        /// </summary>
        public int Minutes { get; }

        /// <summary>
        /// The number of seconds in the coordinate
        /// </summary>
        public int Seconds { get; }

        /// <summary>
        /// The type of this coordinate
        /// </summary>
        public CoordinateType Type { get; }

        /// <summary>
        /// The max value for degrees for this DMS
        /// </summary>
        public int MaxDegrees { get; }

        /// <summary>
        /// The min value for degrees for this DMS
        /// </summary>
        public int MinDegrees { get; }

        /// <summary>
        /// The coordinate represented as a degree decimal
        /// </summary>
        public double DecimalDegrees { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new Coordinate object
        /// </summary>
        /// <param name="degrees">The degrees in the coordinate</param>
        /// <param name="minutes">The minutes in the coordinate</param>
        /// <param name="seconds">The seconds in the coordinate</param>
        /// <param name="type">The coordinate type</param>
        protected Coordinate(int degrees, int minutes, int seconds, CoordinateType type)
        {
            if (minutes >= 60 || minutes < 0)
            {
                throw new ArgumentOutOfRangeException("minutes", "Minutes must be less than 60 and cannot be negative.");
            }

            if (seconds >= 60 || seconds < 0)
            {
                throw new ArgumentOutOfRangeException("seconds", "Seconds must be less than 60 and cannot be negative.");
            }

            switch (type)
            {
                case CoordinateType.LATITUDE:
                    {
                        if ((degrees > 90 || degrees < -90) ||
                            ((degrees == 90 || degrees == -90) && minutes != 0 && seconds != 0))
                        {
                            throw new ArgumentOutOfRangeException("A latitude must be between -90 and 90 degrees");
                        }

                        this.MaxDegrees = 90;
                        this.MinDegrees = -90;

                        break;
                    }
                case CoordinateType.LONGITUDE:
                    {
                        if ((degrees > 180 || degrees < -180) ||
                           ((degrees == 180 || degrees == -180) && minutes != 0 && seconds != 0))
                        {
                            throw new ArgumentOutOfRangeException("A longitude must be between -180 and 180 degrees");
                        }

                        this.MaxDegrees = 180;
                        this.MinDegrees = -180;

                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"The type {type.ToString()} is unknown.");
                    }
            }

            this.Degrees = degrees;
            this.Minutes = minutes;
            this.Seconds = seconds;
            this.Type = type;
            this.DecimalDegrees = this.Degrees + (this.Minutes / 60) + (this.Seconds / 3600);
        }

        /// <summary>
        /// Creates a new Coordinate object
        /// </summary>
        /// <param name="decimalDegrees">The decimal degrees representation of the coordinate</param>
        /// <param name="type">The coordinate type</param>
        protected Coordinate(double decimalDegrees, CoordinateType type)
        {
            this.DecimalDegrees = decimalDegrees;
            this.Type = type;

            switch (this.Type)
            {
                case CoordinateType.LATITUDE:
                    {
                        if (this.DecimalDegrees > 90 || this.DecimalDegrees < -90)
                        {
                            throw new ArgumentOutOfRangeException("decimalDegrees", "The decimal degrees cannot be greather than 90 or less than -90.");
                        }

                        this.MaxDegrees = 90;
                        this.MinDegrees = -90;

                        break;
                    }
                case CoordinateType.LONGITUDE:
                    {
                        if (this.DecimalDegrees > 180 || this.DecimalDegrees < -180)
                        {
                            throw new ArgumentOutOfRangeException("decimalDegrees", "The decimal degrees cannot be greather than 180 or less than -180.");
                        }

                        this.MaxDegrees = 180;
                        this.MinDegrees = -180;

                        break;
                    }
                default:
                    {
                        throw new ArgumentException($"The type {type.ToString()} is unknown.");
                    }
            }

            this.Degrees = (int)Math.Floor(this.DecimalDegrees);
            this.Minutes = (int)Math.Floor(60 * (this.DecimalDegrees - this.Degrees));
            this.Seconds = (int)((3600 * (this.DecimalDegrees - this.Degrees)) - (60 * this.Minutes));
        }

        #endregion

        #region Public Methods

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Coordinate Other = (Coordinate)obj;

            return this.Degrees.Equals(Other.Degrees) &&
                this.Minutes.Equals(Other.Minutes) &&
                this.Seconds.Equals(Other.Seconds) &&
                this.Type.Equals(Other.Type);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return 17 * (this.Degrees.GetHashCode() + this.Minutes.GetHashCode() + this.Seconds.GetHashCode() + this.Type.GetHashCode());
            }
        }

        public override string ToString()
        {
            char Dir = ' ';

            switch (this.Type)
            {
                case CoordinateType.LATITUDE:
                    {
                        if (this.Degrees >= 0)
                        {
                            Dir = 'N';
                        }
                        else
                        {
                            Dir = 'S';
                        }
                        break;
                    }
                case CoordinateType.LONGITUDE:
                    {
                        if (this.Degrees >= 0)
                        {
                            Dir = 'W';
                        }
                        else
                        {
                            Dir = 'E';
                        }
                        break;
                    }
            }

            return ($"{this.Degrees}° {this.Minutes}' {this.Seconds}\" {Dir}").Trim();
        }

        #endregion 
    }
}
