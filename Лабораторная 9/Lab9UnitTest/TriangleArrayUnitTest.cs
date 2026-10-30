using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP_Lab9;
using System;

namespace Lab9UnitTest
{
    [TestClass]
    public class TriangleArrayUnitTest
    {
        [TestMethod]
        public void ArrayIndexTest()
        {
            TriangleArray tArr = new TriangleArray(new Random(), 5);

            Assert.ThrowsException<ArgumentException>(() => tArr[-1], $"Индекс не входит в диапазон: [0;{tArr.Length - 1}]");
        }

        [TestMethod]
        public void ConstructorArrayTest()
        {
            Assert.ThrowsException<ArgumentException>(() => (new TriangleArray(new Random(), -1)), "Длина массива не может быть меньше или равной 0");
            Assert.ThrowsException<ArgumentException>(() => (new TriangleArray(-1)), "Длина массива не может быть меньше или равной 0");
        }

        [TestMethod]
        public void IndexMinValueTest()
        {
            TriangleArray tArr = new TriangleArray(new Random(), 5);

            int expectedInd = 0;
            double min = 1000000;

            for (int i = 0; i < tArr.Length; i++)
            {
                if (tArr[i].TriangleSquare() < min)
                {
                    expectedInd = i;
                    min = tArr[i].TriangleSquare();
                }
            }

            Assert.AreEqual(expectedInd, tArr.GetIndexMinTriangleSquare());
        }
    }
}
