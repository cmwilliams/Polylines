Polylines
=========

.NET Library to handle Google polylines. This library is heavily inspired by the polylines gem https://github.com/joshuaclayton/polylines

## Install
    Install-Package Polylines

## Usage

To encode latitude/longitude points:

    //Encode Points
    var points = new List<PolylineCoordinate>
      {
        new PolylineCoordinate {Latitude = 38.5, Longitude = -120.2},
        new PolylineCoordinate {Latitude = 40.7, Longitude = -120.95},
        new PolylineCoordinate {Latitude = 43.252, Longitude = -126.453}
      };
    
    var polylineForPoints = Polyline.EncodePoints(points);
    Console.WriteLine(polylineForPoints);
    
    //Output _p~iF~ps|U_ulLnnqC_mqNvxq`@
    

To decode a polyline into latitude/longitude points:

    //Decode Polyline
    var polyline = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
    var decodedPoints = Polyline.DecodePolyline(polyline);
    foreach (var decodedPoint in decodedPoints)
    {
      Console.WriteLine(string.Format("Latitude: {0}, Longitude {1}", decodedPoint.Latitude, decodedPoint.Longitude));
    }
    
    //Output
    Latitude: 38.5, Longitude -120.2
    Latitude: 40.7, Longitude -120.95
    Latitude: 43.252, Longitude -126.453

This follows the steps outlined in http://code.google.com/apis/maps/documentation/utilities/polylinealgorithm.html.


## Author

Written by Mike Williams
