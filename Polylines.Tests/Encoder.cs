using System.Collections.Generic;
using NUnit.Framework;

namespace Polylines.Tests
{
    [TestFixture]
    public class Encoder
    {
      
        [Test]
        public void ShouldEncodeASinglePoint()
        {
            const double singlePoint = -179.9832104;
            Assert.That(Polyline.Encode(singlePoint), Is.EqualTo("`~oia@"));
        }

        [Test]
        public void ShouldEncodeMultiplePoints()
        {
            var multiPoints = new List<PolylineCoordinate>
                                  {
                                      new PolylineCoordinate {Latitude = 38.5, Longitude = -120.2},
                                      new PolylineCoordinate {Latitude = 40.7, Longitude = -120.95},
                                      new PolylineCoordinate {Latitude = 43.252, Longitude = -126.453}
                                  };

           const string polyline = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";

            Assert.That(Polyline.EncodePoints(multiPoints), Is.EqualTo(polyline));
        }

        [Test]
        public void ShouldEncodeMultiplePointsThatAreVeryCloseTogether()
        {
            var multiPoints = new List<PolylineCoordinate>
                             {
                                 new PolylineCoordinate {Latitude = 41.3522171071184, Longitude = -86.0456299662023},
                                 new PolylineCoordinate {Latitude = 41.3522171071183, Longitude = -86.0454368471533}
                             };

            const string polyline = "krk{FdxdlO?e@";

            Assert.That(Polyline.EncodePoints(multiPoints), Is.EqualTo(polyline));
        }

        [Test]
        public void ShouldEncodeMultiplePointsWithSameResultsAsGooglesApi()
        {
            var multiPoints = new List<PolylineCoordinate>
                             {
                                 new PolylineCoordinate {Latitude = 39.13594499, Longitude = -94.4243478},
                                 new PolylineCoordinate {Latitude = 39.13558757, Longitude = -94.4243471}
                             };

            const string polyline = "svzmFdgi_QdA?";

            Assert.That(Polyline.EncodePoints(multiPoints), Is.EqualTo(polyline));
        }
    }
}
