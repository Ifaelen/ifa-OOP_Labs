using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Lab9;
using System;

namespace Lab9UnitTest
{
    [TestClass]
    public class TriangleUnitTest
    {
        [TestMethod]
        public void StaticCountTest()
        {
            int expectedValue = 2;

            Triangle t1 = new Triangle(1, 2, 3);
            Triangle t2 = new Triangle(2, 4, 6);

            int count = Triangle.GetCount();

            Assert.AreEqual(expectedValue, count);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.ThrowsException<Exception>(() => (new Triangle(-1, 2, 3)), "Длина стороны треугольника не может быть меньше или равно 0");
            Assert.ThrowsException<Exception>(() => (new Triangle(1, -2, 3)), "Длина стороны треугольника не может быть меньше или равно 0");
            Assert.ThrowsException<Exception>(() => (new Triangle(1, 2, -3)), "Длина стороны треугольника не может быть меньше или равно 0");
        }

        [TestMethod]
        public void OperatorsOverloadTests()
        {
            //++
            Triangle expectedValue1 = new Triangle(3, 4, 5);

            Triangle t1 = new Triangle(2, 3, 4);

            Assert.AreEqual(expectedValue1, t1);

            //--
            Triangle expectedValue2 = new Triangle(3, 4, 5);

            Triangle t2 = new Triangle(4, 5, 6);

            Assert.AreEqual(expectedValue2, t2);

            //(double)
            double expectedValue3 = 6;

            Triangle t3 = new Triangle(3, 4, 5);

            Assert.AreEqual(expectedValue3, (double)t3);

            //(bool)
            bool expectedValue4 = true;

            Triangle t4 = new Triangle(3, 4, 5);

            Assert.AreEqual(expectedValue4, (bool)t4);

            //>=
            Triangle t51 = new Triangle(3, 4, 5);
            Triangle t52 = new Triangle(6, 8, 10);

            Assert.IsFalse(t51 >= t52);

            //<=
            Triangle t61 = new Triangle(3, 4, 5);
            Triangle t62 = new Triangle(6, 8, 10);

            Assert.IsTrue(t61 <= t62);
        }
    }
}
