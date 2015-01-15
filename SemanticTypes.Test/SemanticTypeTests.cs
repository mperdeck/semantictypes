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

        private class CompareTest1SemanticType: UncomparableSemanticType<CompareTest1>
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

        private class CompareTest2ComparableSemanticType : SemanticType<CompareTest2>
        {
            public CompareTest2ComparableSemanticType(CompareTest2 compareTest2) : base(null, compareTest2) { }
        }

        private class CompareTest2SemanticType : UncomparableSemanticType<CompareTest2>
        {
            public CompareTest2SemanticType(CompareTest2 compareTest2) : base(null, compareTest2) { }
        }

        // Does not implement IComparable or IComparable<T>
        private class CompareTest3
        {
            public int MyValue { get; set; }
        }

        private class CompareTest3SemanticType : UncomparableSemanticType<CompareTest3>
        {
            public CompareTest3SemanticType(CompareTest3 compareTest3) : base(null, compareTest3) { }
        }

        [TestMethod]
        public void TestIComparableT()
        {
            CompareTest2ComparableSemanticType[] arr = 
            {
                new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 5 }),
                new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 3 }),
                null,
                new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 7 })
            };

            Array.Sort(arr);

            Assert.AreEqual(arr[0], null);
            Assert.AreEqual(arr[1].Value.MyValue, 3);
            Assert.AreEqual(arr[2].Value.MyValue, 5);
            Assert.AreEqual(arr[3].Value.MyValue, 7);
        }

        [TestMethod]
        public void Compare_Equal()
        {
            CompareTest2ComparableSemanticType t2a = new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 5 });
            CompareTest2ComparableSemanticType t2b = new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 5 });

            int equal = t2a.CompareTo(t2b);
            Assert.AreEqual(equal, 0);
        }

        [TestMethod]
        public void Compare_Less()
        {
            CompareTest2ComparableSemanticType t2a = new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 2 });
            CompareTest2ComparableSemanticType t2b = new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 5 });

            int equal = t2a.CompareTo(t2b);
            Assert.IsTrue(equal < 0);
        }

        [TestMethod]
        public void Compare_Greater()
        {
            CompareTest2ComparableSemanticType t2a = new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 8 });
            CompareTest2ComparableSemanticType t2b = new CompareTest2ComparableSemanticType(new CompareTest2 { MyValue = 5 });

            int equal = t2a.CompareTo(t2b);
            Assert.IsTrue(equal > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void BasingSemanticTypeOnIComparableT()
        {
            // If you try to use a UncomparableSemanticType (rather than a SemanticType) with an underlying
            // value that implements IComparable or IComparable<T>, it throws an exception.
            // This prevents sorting problems when someone converts from naked types to Semantic Types.

            CompareTest2SemanticType t2 = new CompareTest2SemanticType(new CompareTest2 { MyValue = 5 });
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void BasingSemanticTypeOnIComparable()
        {
            // If you try to use a UncomparableSemanticType (rather than a SemanticType) with an underlying
            // value that implements IComparable or IComparable<T>, it throws an exception.
            // This prevents sorting problems when someone converts from naked types to Semantic Types.

            CompareTest1SemanticType t1 = new CompareTest1SemanticType(new CompareTest1 { MyValue = 5 });
        }

        [TestMethod]
        public void BasingSemanticTypeOnNotIComparable()
        {
            // If you try to use a UncomparableSemanticType (rather than a SemanticType) with an underlying
            // value that implements IComparable or IComparable<T>, it throws an exception.
            // This prevents sorting problems when someone converts from naked types to Semantic Types.

            // CompareTest3 does not implement IComparable or IComparable<T>, so should be fine.
            CompareTest3SemanticType t3 = new CompareTest3SemanticType(new CompareTest3 { MyValue = 5 });

            Assert.IsNotNull(t3);
            Assert.AreEqual(t3.Value.MyValue, 5);
        }
    }
}
