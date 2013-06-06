using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Polylines.Tests
{

    public class PolylineCoordinateComparer : IComparer, IComparer<PolylineCoordinate>
    {
        public int Compare(object x, object y)
        {
            var lhs = x as PolylineCoordinate;
            var rhs = y as PolylineCoordinate;
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            return Compare(lhs, rhs);
        }

        public int Compare(PolylineCoordinate x, PolylineCoordinate y)
        {
            int temp;
            return (temp = x.Latitude.CompareTo(y.Latitude)) != 0 ? temp : x.Longitude.CompareTo(y.Longitude);
        }
    }

    [TestFixture]
    public class Decoder
    {
        [Test]
        public void ShouldDecodeASinglePoint()
        {
            const string singlePoint = "`~oia@";
            Assert.That(Polyline.Decode(singlePoint), Is.EqualTo(-179.9832104).Within(0.00001));
        }


        [Test]
        public void ShouldDecodePolyline()
        {
            const string polyline = "_p~iF~ps|U_ulLnnqC_mqNvxq`@";
            var multiPoints = new List<PolylineCoordinate>
                                  {
                                      new PolylineCoordinate {Latitude = 38.5, Longitude = -120.2},
                                      new PolylineCoordinate {Latitude = 40.7, Longitude = -120.95},
                                      new PolylineCoordinate {Latitude = 43.252, Longitude = -126.453}
                                  };

            var polylineComparer = new PolylineCoordinateComparer();
            CollectionAssert.AreEqual(multiPoints.ToList(), Polyline.DecodePolyline(polyline).ToList(), polylineComparer);
        }

        [Test]
        public void ShouldDecodePolylineWithPointsThatWereCloseTogether()
        {
            const string polyline = "krk{FdxdlO?e@";
            var multiPoints = new List<PolylineCoordinate>
                                  {
                                      new PolylineCoordinate {Latitude = 41.35222, Longitude = -86.04563},
                                      new PolylineCoordinate {Latitude = 41.35222, Longitude = -86.04544}
                                  };

            var polylineComparer = new PolylineCoordinateComparer();
            CollectionAssert.AreEqual(multiPoints.ToList(), Polyline.DecodePolyline(polyline).ToList(), polylineComparer);
        }

    }
}
