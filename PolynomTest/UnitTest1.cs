using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynomial;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace PolynomTest

{
    [TestClass]
    public class PolynomOperationsTest
    {
        Polynom a = new Polynom(1, 2, 3, 4, 5, 6);
        Polynom b =new Polynom(1,2,3,4);
        Polynom expectedSum = new Polynom(2,4,6,8,5,6);
        private Polynom expectedMinus = new Polynom(0, 0, 0, 0, -5, -6);
        Polynom expextedMulti= new Polynom(1,4,10,20,30,40,43,38,24);

        [TestMethod]
        public void EqualsFunction()
        {
            double[] koeff = new double[a.Degree+1];
            for (int i = 0; i < koeff.Length; i++)
            {
                koeff[i] = a[i];
            }
            Polynom a1 =new Polynom(koeff);
            Assert.IsTrue(a.Equals(a1));
        }
        [TestMethod]
        public void ReferenceEqualsOperation()
        {
            Polynom a1 = a;
            Assert.IsTrue(a==a1);
        }

        [TestMethod]
        public void CloneFunctionTest()
        {
            Polynom a1 =(Polynom) a.Clone();
            Assert.That(a1.Equals(a) && !ReferenceEquals(a1, a));
        }

        [TestMethod]
        public void SumOperation()
        {
            Polynom c = a + b;
            Assert.That(c.ToString()==expectedSum.ToString());
        }

        [TestMethod]
        public void MinusOperation()
        {
            Polynom c = b - a;
            Assert.That(c.ToString() == expectedMinus.ToString());
        }

        [TestMethod]
        public void MultiOperation()
        {
            Polynom c = a*b;
            Assert.That(c.ToString() == expextedMulti.ToString());
        }

    }
}
