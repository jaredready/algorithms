using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using QuickSort;

namespace SortTest
{
    [TestClass]
    public class SorterTest
    {
        [TestMethod]
        public void ListIsSortedAscending_SortedListNoDuplicates_ReturnsTrue()
        {
            List<float> sortedList = new List<float>(new float[] { 1.0f, 2.0f, 3.0f, 4.0f, 5.0f });
            Assert.IsTrue(Sorter.ListIsSortedAscending(sortedList));
        }

        [TestMethod]
        public void ListIsSortedAscending_SortedListSomeDuplicates_ReturnsTrue()
        {
            List<float> sortedList = new List<float>(new float[] { 1.0f, 1.0f, 3.0f, 3.0f, 5.0f });
            Assert.IsTrue(Sorter.ListIsSortedAscending(sortedList));
        }

        [TestMethod]
        public void ListIsSortedAscending_AllDuplicates_ReturnsTrue()
        {
            List<float> list = new List<float>(new float[] { 1.1f, 1.1f, 1.1f, 1.1f, 1.1f });
            Assert.IsTrue(Sorter.ListIsSortedAscending(list));
        }

        [TestMethod]
        public void ListIsSortedAscending_UnsortedListNoDuplicates_ReturnsFalse()
        {
            List<float> unsortedList = new List<float>(new float[] { 3.0f, 1.0f, 7.0f, -1.0f });
            Assert.IsFalse(Sorter.ListIsSortedAscending(unsortedList));
        }

        [TestMethod]
        public void ListIsSortedAscending_UnsortedListSomeDuplicates_ReturnsFalse()
        {
            List<float> unsortedList = new List<float>(new float[] { 3.0f, 3.0f, 7.0f, -1.0f, -1.0f });
            Assert.IsFalse(Sorter.ListIsSortedAscending(unsortedList));
        }

        [TestMethod]
        public void ListIsSortedAscending_EmptyList_ReturnsFalse()
        {
            List<float> emptyList = new List<float>();
            Assert.IsFalse(Sorter.ListIsSortedAscending(emptyList));
        }

        [TestMethod]
        public void ListIsSortedAscending_NullList_ReturnsFalse()
        {
            List<float> emptyList = null;
            Assert.IsFalse(Sorter.ListIsSortedAscending(emptyList));
        }

        [TestMethod]
        public void Sort_UnsortedListNoDuplicates_ReturnsSortedList()
        {
            List<float> unsortedList = new List<float>(new float[] { 3.0f, 1.0f, 7.0f, -1.0f });

            Assert.IsTrue(Sorter.ListIsSortedAscending(Sorter.Sort(unsortedList)));
        }

        [TestMethod]
        public void Sort_UnsortedListSomeDuplicates_ReturnsSortedList()
        {
            List<float> unsortedList = new List<float>(new float[] { 3.0f, 1.0f, 7.0f, -1.0f, -1.0f, 3.0f });

            Assert.IsTrue(Sorter.ListIsSortedAscending(Sorter.Sort(unsortedList)));
        }

        [TestMethod]
        public void Sort_UnsortedListRandomValues_ReturnsSortedList()
        {
            List<float> randomList = RandomListOfFloats(10000);

            Assert.IsTrue(Sorter.ListIsSortedAscending(Sorter.Sort(randomList)));
        }

        private List<float> RandomListOfFloats(int size)
        {
            // Referenced http://stackoverflow.com/a/3365388 to generate random floats

            Random random = new Random();
            List<float> randomList = new List<float>(size);
            for(int i = 0; i < size; i++)
            {
                double mantissa = (random.NextDouble() * 2.0) - 1.0;
                double exponent = Math.Pow(2.0, random.Next(-126, 128));
                randomList.Add((float)(mantissa * exponent));
            }

            return randomList;
        }
    }
}
