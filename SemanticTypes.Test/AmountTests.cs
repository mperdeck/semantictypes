using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SemanticTypes.SemanticTypeQualifiedByValueExamples;

namespace SemanticTypes.Test
{
    [TestClass]
    public class AmountTests
    {
        [TestMethod]
        public void AllAmountTests()
        {
            Amount usd5Amount = new Amount(5, "USD");
            Amount usd5Amount2 = new Amount(5, "USD");
            Amount usd10Amount = new Amount(10, "USD");
            Amount eur5Amount = new Amount(5, "EUR");
            Amount eur2Amount = new Amount(2, "EUR");
            Amount eur3Amount = new Amount(3, "EUR");
            Amount nullAmount = null;

            Assert.AreEqual(eur5Amount, eur2Amount + eur3Amount);
            Assert.AreEqual(eur2Amount, eur5Amount - eur3Amount);
            Assert.AreEqual(usd5Amount, usd5Amount2);
            Assert.AreEqual(usd5Amount, usd10Amount / 2);
            Assert.AreEqual(usd10Amount, usd5Amount * 2);
            Assert.AreEqual(usd10Amount, 2 * usd5Amount);
            Assert.AreEqual(-1 * usd5Amount, -usd5Amount2);

            Assert.IsNull(eur2Amount + nullAmount);
            Assert.IsNull(nullAmount + eur2Amount);
            Assert.IsNull(nullAmount + nullAmount);

            // Amounts with different currencies
            Assert.IsNull(eur2Amount + usd5Amount);

            // -----------------------------------------------

            Assert.IsTrue(eur2Amount < eur3Amount);
            Assert.IsFalse(eur2Amount > eur3Amount);
            Assert.IsTrue(eur2Amount <= eur3Amount);
            Assert.IsFalse(eur2Amount >= eur3Amount);

            Assert.IsTrue(eur3Amount > eur2Amount);
            Assert.IsFalse(eur3Amount < eur2Amount);
            Assert.IsTrue(eur3Amount >= eur2Amount);
            Assert.IsFalse(eur3Amount <= eur2Amount);

            Assert.IsTrue(usd5Amount == usd5Amount2);
            Assert.IsFalse(eur3Amount == eur2Amount);
            Assert.IsTrue(eur3Amount != eur2Amount);
            Assert.IsFalse(usd5Amount != usd5Amount2);

            Assert.IsFalse(eur5Amount == usd5Amount);
            Assert.IsTrue(eur5Amount != usd5Amount);



        }
    }
}
