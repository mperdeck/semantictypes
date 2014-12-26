using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticTypes.SemanticTypeExamples;

namespace SemanticTypes.Test
{
    [TestClass]
    public class BirthDateTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BirthDateInFuture_Exception()
        {
            var birthDateDT = DateTime.Now + new TimeSpan(1, 0, 0, 0);
            var birthDate = new BirthDate(birthDateDT);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BirthDateTooManyYearsAgo_Exception()
        {
            var birthDateDT = DateTime.Now - new TimeSpan(130 * 365, 0, 0, 0);
            var birthDate = new BirthDate(birthDateDT);
        }

        [TestMethod]
        public void BirthDate30YearsAgo_Succeeds()
        {
            var birthDateDT = DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0);
            var birthDate = new BirthDate(birthDateDT);

            Assert.AreEqual(birthDateDT, birthDate.Value); 
        }

        [TestMethod]
        public void IsValid_BirthDateInFuture_False()
        {
            var birthDateDT = DateTime.Now + new TimeSpan(1, 0, 0, 0);
            Assert.IsFalse(BirthDate.IsValid(birthDateDT));
        }

        [TestMethod]
        public void IsValid_BirthDateTooManyYearsAgo_False()
        {
            var birthDateDT = DateTime.Now - new TimeSpan(130 * 365, 0, 0, 0);
            Assert.IsFalse(BirthDate.IsValid(birthDateDT));
        }

        [TestMethod]
        public void IsValid_BirthDate30YearsAgo_True()
        {
            var birthDateDT = DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0);
            Assert.IsTrue(BirthDate.IsValid(birthDateDT));
        }

        [TestMethod]
        public void Equals_ValuesEqual_True()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            var birthDateDT2 = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            Assert.IsTrue(birthDateDT.Equals(birthDateDT2));
        }

        [TestMethod]
        public void Equals_CompareWithNull_False()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            Assert.IsFalse(birthDateDT.Equals(null));
        }

        [TestMethod]
        public void Equals_ValuesNotEqual_False()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            var birthDateDT2 = new BirthDate(DateTime.Now - new TimeSpan(31 * 365, 0, 0, 0));
            Assert.IsFalse(birthDateDT.Equals(birthDateDT2));
        }

        [TestMethod]
        public void EqualsOperator_ValuesEqual_True()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            var birthDateDT2 = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            Assert.IsTrue(birthDateDT == birthDateDT2);
        }

        [TestMethod]
        public void EqualsOperator_CompareWithNullRhs_False()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            Assert.IsFalse(birthDateDT == null);
        }

        [TestMethod]
        public void EqualsOperator_CompareWithNullLhs_False()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            Assert.IsFalse(null == birthDateDT);
        }

        [TestMethod]
        public void EqualsOperator_ValuesNotEqual_False()
        {
            var birthDateDT = new BirthDate(DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0));
            var birthDateDT2 = new BirthDate(DateTime.Now - new TimeSpan(31 * 365, 0, 0, 0));
            Assert.IsFalse(birthDateDT == birthDateDT2);
        }
    }
}
