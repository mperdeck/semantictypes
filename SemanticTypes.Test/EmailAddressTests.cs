using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticTypes.SemanticTypeExamples;

namespace SemanticTypes.Test
{
    [TestClass]
    public class EmailAddressTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SetToNull_Exception()
        {
            var emailAddress = new EmailAddress(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SetToInvalid_Exception()
        {
            var emailAddress = new EmailAddress("Invalid email address");
        }

        [TestMethod]
        public void SetToValid_NoException()
        {
            var emailAddress = new EmailAddress("test12@test.com.au");
            Assert.AreEqual("test12@test.com.au", emailAddress.Value);
        }

        [TestMethod]
        public void Test_Implicit()
        {
            EmailAddress emailAddress = "example@contoso.com";
            Assert.AreEqual("example@contoso.com", emailAddress.Value);
        }

        [TestMethod]
        public void Test_Explicit()
        {
            EmailAddress emailAddress = new EmailAddress("example@contoso.com");

            string sAddress = (string)emailAddress;
            Assert.AreEqual("example@contoso.com", sAddress);
        }

        [TestMethod]
        public void SetToNull()
        {
            EmailAddress emailAddress = null;
            Assert.AreEqual(emailAddress, null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SetToInvalidImplicit_Exception()
        {
            EmailAddress emailAddress = "Invalid email address";
        }
    }
}
