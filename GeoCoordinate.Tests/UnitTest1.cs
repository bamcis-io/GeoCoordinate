using System;
using Xunit;

namespace BAMCIS.GIS.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void GoodGeoCoordinate()
        {
            // ARRANGE
            double Lat = 85.00001;
            double Long = -110.12345;

            // ACT
            GeoCoordinate Coord = new GeoCoordinate(Lat, Long);

            // ASSERT
            Assert.Equal(Lat, Coord.Latitude.DecimalDegrees);
            Assert.Equal(Long, Coord.Longitude.DecimalDegrees);
        }

        [Fact]
        public void BadLatGeoCoordinate()
        {
            // ARRANGE
            double Lat = 95;
            double Long = -110.12345;

            // ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Lat, Long));
        }

        [Fact]
        public void BadLongGeoCoordinate()
        {
            // ARRANGE
            double Lat = 85.00001;
            double Long = -180.12345;

            // ACT & ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => new GeoCoordinate(Lat, Long));
        }

        [Fact]
        public void HaversineDistance()
        {
            // ARRANGE
            GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

            // ACT
            double Distance = Source.DistanceTo(Destination, DistanceType.KILOMETERS);

            // ASSERT
            Assert.Equal(1967.0898177084771, Distance);
        }

        [Fact]
        public void HaversineBearing()
        {
            // ARRANGE
            GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

            // ACT
            double Bearing = Source.InitialBearingTo(Destination);

            // ASSERT
            Assert.Equal(355.84047394177765, Bearing);
        }

        [Fact]
        public void HaversineDestination()
        {
            // ARRANGE
            GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

            // ACT
            ICoordinate CalculatedDestination = Source.FindDestination(355.84047394177765, 1967.0898177084771, DistanceType.KILOMETERS);

            // ASSERT
            Assert.Equal(Math.Round(Destination.Latitude.DecimalDegrees, 2), Math.Round(CalculatedDestination.GetLatitude().DecimalDegrees, 2));
            Assert.Equal(Math.Round(Destination.Longitude.DecimalDegrees, 2), Math.Round(CalculatedDestination.GetLongitude().DecimalDegrees, 2));
        }

        [Fact]
        public void RhumbDistance()
        {
            // ARRANGE
            GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

            // ACT
            double Distance = Source.RhumbDistanceTo(Destination, DistanceType.KILOMETERS);

            // ASSERT
            Assert.Equal(1967.1746504256103, Distance);
        }

        [Fact]
        public void RhumbBearing()
        {
            // ARRANGE
            GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

            // ACT
            double Bearing = Source.RhumbBearingTo(Destination);

            // ASSERT
            Assert.Equal(355.00824242711576, Bearing);
        }

        [Fact]
        public void RhumbDestination()
        {
            // ARRANGE
            GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
            GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

            // ACT
            ICoordinate CalculatedDestination = Source.FindRhumbDestination(355, 1967, DistanceType.KILOMETERS);

            // ASSERT
            Assert.Equal(Math.Round(Destination.GetLatitude().DecimalDegrees, 2), Math.Round(CalculatedDestination.GetLatitude().DecimalDegrees, 2));
            Assert.Equal(Math.Round(Destination.GetLongitude().DecimalDegrees, 2), Math.Round(CalculatedDestination.GetLongitude().DecimalDegrees, 2));
        }
    }
}
