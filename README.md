# BAMCIS GeoCoordinate
An implementation of a Geographic Coordinate System written in .NET Core 2.0. 

The library provides the ability to create latitude and longitude coordinates 
and execute common geometric functions like finding the distance between two
points, finding the bearing from a source to destination, or finding a destination
coordinate given a source, bearing, and distance.

## Usage

### Basic Example 1

     GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
     GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);

     double Distance = Source.DistanceTo(Destination, DistanceType.KILOMETERS);

This calculates the distance between the two points using the Haversine formula.

### Basic Example 2

    GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
    ICoordinate Destination = Source.FindDestination(355, 1967, DistanceType.KILOMETERS);

This example finds the destination if you were to travel on a bearing of 355 degrees for 1967km from
the source geo coordinate using the Haversine formula.

### Basic Example 3

    GeoCoordinate Source = new GeoCoordinate(40.7486, 5.4253);
    GeoCoordinate Destination = new GeoCoordinate(58.3838, 3.01412);
    double Bearing = Source.RhumbBearingTo(Destination);

This example finds the bearing between a source and destination using a rhumb line calculation

## Revision History

### 1.0.0
Initial release of the library.
