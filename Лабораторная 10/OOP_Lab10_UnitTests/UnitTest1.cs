using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OOP_Lab10_ClassesLib;

namespace OOP_Lab10_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstQueryTest()
        {
            string expectedString = "ВасилийАлександра";

            Person[] persons = new Person[6] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6), new Engineer("Людмила", 28, 2) };

            string names = "";

            foreach (Person p in persons)
            {
                if(p is Engineer e)
                {
                    if (e.WorkExperience >= 5)
                    {
                        names += e.Name;
                    }
                }
            }

            Assert.AreEqual(expectedString, names);
        }

        [TestMethod]
        public void SecondQueryTest()
        {
            string expectedString = "Борис";

            Person[] persons = new Person[6] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6), new Engineer("Людмила", 28, 2) };

            string names = "";

            foreach (Person p in persons)
            {
                if (p is Administrator)
                {
                    names += p.Name;
                }
            }

            Assert.AreEqual(expectedString, names);
        }

        [TestMethod]
        public void ThirdQueryTest()
        {
            int expectedValue = 2;

            Person[] persons = new Person[6] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6), new Engineer("Людмила", 28, 2) };

            int count = 0;

            foreach (Person p in persons)
            {
                if (p.GetType() == typeof(Worker))
                {
                    count++;
                }
            }

            Assert.AreEqual(expectedValue, count);
        }

        [TestMethod]
        public void NameSortTest()
        {
            Person[] expectedArray = new Person[6] { new Engineer("Александра", 28, 8), new Worker("Алексей", 25, 6), new Administrator("Борис", 37, 12), new Engineer("Василий", 28, 7), new Worker("Евгения", 26, 6), new Engineer("Людмила", 28, 2) };

            Person[] persons = new Person[6] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6), new Engineer("Людмила", 28, 2) };

            Array.Sort(persons);

            bool b = true;

            for (int i = 0; i < 6; i++)
            {
                if (!persons[i].Equals(expectedArray[i]))
                {
                    b = false;
                }
            }

            Assert.IsTrue(b);
        }

        [TestMethod]
        public void AgeSortTest()
        {
            Person[] expectedArray = new Person[6] { new Worker("Алексей", 25, 6), new Worker("Евгения", 26, 6), new Engineer("Василий", 28, 7), new Engineer("Александра", 28, 8), new Engineer("Людмила", 28, 2), new Administrator("Борис", 37, 12) };

            Person[] persons = new Person[6] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6), new Engineer("Людмила", 28, 2) };

            Array.Sort(persons, new SortByAge());

            bool b = true;

            for(int i = 0; i < 6; i++)
            {
                if (!persons[i].Equals(expectedArray[i]))
                {
                    b = false;
                }
            }

            Assert.IsTrue(b);
        }

        [TestMethod]
        public void BinarySearchTest()
        {
            int expectedIndex = 5;

            Person[] persons = new Person[6] { new Worker("Алексей", 25, 6), new Engineer("Василий", 56, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6), new Engineer("Людмила", 29, 2) };

            int ageTarget = 56;
            int index = -1;

            //
            Array.Sort(persons, new SortByAge());

            int left = 0;
            int right = persons.Length - 1;
            int mid;

            while (left <= right)
            {
                mid = (left + right) / 2;

                if (persons[mid].Age == ageTarget)
                {
                    index = mid;
                    break;
                }
                else if (persons[mid].Age > ageTarget)
                {
                    right = mid - 1;
                }
                else if (persons[mid].Age < ageTarget)
                {
                    left = mid + 1;
                }
            }
            //

            Assert.AreEqual(expectedIndex, index);
        }

        [TestMethod]
        public void ShallowCloneTest()
        {
            Person expectedValue = new Engineer("Василий", 28, 7);

            Person[] persons = new Person[5] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6) };

            Worker w = new Worker();

            w = (Worker)persons[1].ShallowCopy();

            Assert.AreEqual(expectedValue, w);
        }

        [TestMethod]
        public void CloneTest()
        {
            Person expectedValue = new Worker("Клон. Василий", 28, 7);

            Person[] persons = new Person[5] { new Worker("Алексей", 25, 6), new Engineer("Василий", 28, 7), new Administrator("Борис", 37, 12), new Engineer("Александра", 28, 8), new Worker("Евгения", 26, 6) };

            Worker w = new Worker();

            w = (Worker)persons[1].Clone();

            Assert.AreEqual(expectedValue, w);
        }


    }
}
