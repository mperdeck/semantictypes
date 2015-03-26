using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticTypes.MetricTypeSystem;

namespace SemanticTypes.Test
{
    [TestClass]
    public class PhysicsTests
    {
        [TestMethod]
        public void VariousPhysicsTests()
        {
            var distance1m = new Distance(1); // 1 meter
            var distance1m_2 = Distance.FromMeters(1);
            var distance1609m = Distance.FromMeters(1609);
            var distance1mile = Distance.FromMiles(1);
            var distance6m = Distance.FromMeters(6);
            var distance4m = Distance.FromMeters(4);
            var distance2m = Distance.FromMeters(2);
            var distance4i = Distance.FromInches(4);
            var distance2i = Distance.FromInches(2);
            var distance8m2 = distance2m * distance4m;

            Assert.IsTrue(distance1mile > distance1m_2);
            Assert.IsTrue(distance1m == distance1m_2);
            Assert.IsTrue(distance1609m == distance1mile);
            Assert.IsTrue(distance1609m.Meters == 1609);
            Assert.IsTrue(distance6m == distance4m + distance2m);
            Assert.IsTrue(distance6m == 3 * distance2m);
            Assert.IsTrue(distance6m == distance2m * 3);
            Assert.IsTrue(distance2m == distance6m / 3);
            Assert.IsTrue(distance2m == -1* (distance4m - distance6m));

            Distance d = (distance4m + distance6m);

            Assert.IsTrue(distance6m == distance4m + distance2m);

            //Distance distanceMinus2m = (distance4m - distance6m);
            //Assert.IsTrue(distanceMinus2m.Meters == -2);
            //Assert.IsTrue(distance2m == distance6m - distance4m);
            //Assert.IsTrue(distance8m2.Value == 8);
        }
    }
}
