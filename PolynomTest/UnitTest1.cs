using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynomial;

namespace PolynomTest
{
    [TestClass]
    public class PolynomOperationsTest
    {
        [TestMethod]
        public void EqualsFunction()
        {
            Polynom a =new Polynom(1,2,3,4,5,6);
            Polynom b = new Polynom(1,2,3,4,5,6);
            Assert.IsTrue(a.Equals(b));
        }
    }
}
