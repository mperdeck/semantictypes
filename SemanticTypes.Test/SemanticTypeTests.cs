using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SemanticTypes.Test
{
    [TestClass]
    public class SemanticTypeTests
    {
        private class CompareTest1 : IComparable
        {
            public int MyValue { get; set; }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;

                if (!(obj is CompareTest1))
                {
                    throw new ArgumentException("Object is not a CompareTest1");
                }

                return (MyValue - ((CompareTest1)obj).MyValue);
            }
        }

        private class CompareTest1SemanticType: SemanticType<CompareTest1>
        {
            public CompareTest1SemanticType(CompareTest1 compareTest1) : base(null, compareTest1) { }
        }

        private class CompareTest2 : IComparable<CompareTest2>
        {
            public int MyValue { get; set; }

            public int CompareTo(CompareTest2 obj)
            {
                if (obj == null) return 1;

                if (!(obj is CompareTest2))
                {
                    throw new ArgumentException("Object is not a CompareTest2");
                }

                return (MyValue - ((CompareTest2)obj).MyValue);
            }
        }

        private class CompareTest2SemanticType : SemanticType<CompareTest2>
        {
            public CompareTest2SemanticType(CompareTest2 compareTest2) : base(null, compareTest2) { }
        }

        // Does not implement IComparable or IComparable<T>
        private class CompareTest3
        {
            public int MyValue { get; set; }
        }

        private class CompareTest3SemanticType : SemanticType<CompareTest3>
        {
            public CompareTest3SemanticType(CompareTest3 compareTest3) : base(null, compareTest3) { }
        }

        [TestMethod]
        public void TestIComparable()
        {
            CompareTest1SemanticType[] arr = 
            {
                new CompareTest1SemanticType(new CompareTest1 { MyValue = 5 }),
                new CompareTest1SemanticType(new CompareTest1 { MyValue = 3 }),
                null,
                new CompareTest1SemanticType(new CompareTest1 { MyValue = 7 })
            };

            Array.Sort(arr);

            Assert.AreEqual(arr[0], null);
            Assert.AreEqual(arr[1].Value.MyValue, 3);
            Assert.AreEqual(arr[2].Value.MyValue, 5);
            Assert.AreEqual(arr[3].Value.MyValue, 7);
        }

        [TestMethod]
        public void TestIComparableT()
        {
            CompareTest2SemanticType[] arr = 
            {
                new CompareTest2SemanticType(new CompareTest2 { MyValue = 5 }),
                new CompareTest2SemanticType(new CompareTest2 { MyValue = 3 }),
                null,
                new CompareTest2SemanticType(new CompareTest2 { MyValue = 7 })
            };

            Array.Sort(arr);

            Assert.AreEqual(arr[0], null);
            Assert.AreEqual(arr[1].Value.MyValue, 3);
            Assert.AreEqual(arr[2].Value.MyValue, 5);
            Assert.AreEqual(arr[3].Value.MyValue, 7);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void IncompatibleCompare_IComparableTWithIComparable()
        {
            CompareTest2SemanticType t2 = new CompareTest2SemanticType(new CompareTest2 { MyValue = 5 });
            CompareTest1SemanticType t1 = new CompareTest1SemanticType(new CompareTest1 { MyValue = 5 });

            int equal = t2.CompareTo(t1);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void IncompatibleCompare_IComparableWithIComparableT()
        {
            CompareTest2SemanticType t2 = new CompareTest2SemanticType(new CompareTest2 { MyValue = 5 });
            CompareTest1SemanticType t1 = new CompareTest1SemanticType(new CompareTest1 { MyValue = 5 });

            int equal = t1.CompareTo(t2);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void IncompatibleCompare_CompareValuesThatDoNotImplementIComparableAtAll()
        {
            CompareTest3SemanticType t3a = new CompareTest3SemanticType(new CompareTest3 { MyValue = 5 });
            CompareTest3SemanticType t3b = new CompareTest3SemanticType(new CompareTest3 { MyValue = 6 });

            int equal = t3a.CompareTo(t3b);
        }
    }
}
