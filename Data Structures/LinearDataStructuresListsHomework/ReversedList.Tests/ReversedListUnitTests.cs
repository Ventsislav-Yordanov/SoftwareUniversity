namespace ReversedList.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ImplementTheDataStructureReversedList;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    [TestClass]
    public class ReversedListUnitTests
    {
        [TestMethod]
        public void CreateEmptyList()
        {
            var list = new ReversedList<int>();

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(4, list.Capacity);
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void AddElementToEmptyList()
        {
            var list = new ReversedList<int>();

            list.Add(12);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(4, list.Capacity);
            CollectionAssert.AreEqual(new List<int>() { 12 }, GetReversedListItems(list));
        }

        [TestMethod]
        public void CreateListWithElements()
        {
            var list = new ReversedList<int>() { 6, 17, 8 };

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        public void CreateListWithManyElements()
        {
            var list = new ReversedList<int>() { 6, 17, 8, 8, 25 };

            Assert.AreEqual(5, list.Count);
            Assert.AreEqual(8, list.Capacity);
            CollectionAssert.AreEqual(
                new List<int>() { 25, 8, 8, 17, 6 },
                GetReversedListItems(list));
        }

        [TestMethod]
        public void AddElementsWitDoubleCapacityDoubling()
        {
            var list = new ReversedList<int>() { 6, 4, 10, 24, 232 };

            list.Add(4);
            list.Add(534);
            list.Add(5324);
            list.Add(521);

            Assert.AreEqual(9, list.Count);
            Assert.AreEqual(16, list.Capacity);
            CollectionAssert.AreEqual(
                new List<int>() { 521, 5324, 534, 4, 232, 24, 10, 4, 6 },
                GetReversedListItems(list));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteZeroIndexFromEmptyCollection()
        {
            var list = new ReversedList<int>();

            list.Delete(0);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(1, list.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteBiggerIndexFromEmptyCollection()
        {
            var list = new ReversedList<int>();

            list.Delete(1);

            Assert.AreEqual(0, list.Count);
            Assert.AreEqual(4, list.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteWrongIndexFromCollection()
        {
            var list = new ReversedList<int>() { 2, 20, 123, 20, 1634 };

            list.Delete(100);
        }

        [TestMethod]
        public void DeleteAtFirstIndex()
        {
            var list = new ReversedList<int>() { 20, 10, 123, 4, 423, 666 };

            list.Delete(0);

            CollectionAssert.AreEqual(
                new List<int>() { 423, 4, 123, 10, 20 },
                GetReversedListItems(list));
        }

        [TestMethod]
        public void DeleteAtLastIndex()
        {
            var list = new ReversedList<int>() { 20, 10, 123, 4, 423, 666 };

            list.Delete(list.Count - 1);

            CollectionAssert.AreEqual(
                new List<int>() { 666, 423, 4, 123, 10 },
                GetReversedListItems(list));
        }

        [TestMethod]
        public void DeleteAtMiddleIndex()
        {
            var list = new ReversedList<int>() { 20, 10, 123, 4, 423, 666 };

            list.Delete(3);

            CollectionAssert.AreEqual(
                new List<int>() { 666, 423, 4, 10, 20 },
                GetReversedListItems(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteAtNegativeIndex()
        {
            var list = new ReversedList<int>() { 20, 10, 123, 4, 423, 666 };

            list.Delete(-3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetElementAtNonExistingIndexFromEmptyList()
        {
            var list = new ReversedList<int>();

            var element = list[2];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetElementAtNonExistingIndexFromNonEmptyList()
        {
            var list = new ReversedList<int>() { 1, 2, 33 };

            var element = list[4];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetElementAtNegativeIndexFromNonEmptyList()
        {
            var list = new ReversedList<int>() { 1, 2, 33 };

            var element = list[-544];
        }

        [TestMethod]
        public void GetElementAtValidIndexFromNonEmptyList()
        {
            var list = new ReversedList<int>() { 1, 2, 33 };

            var element = list[2];

            Assert.AreEqual(1, element);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementAtNonExistingIndexFromEmptyList()
        {
            var list = new ReversedList<int>();

            list[55] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementAtNonExistingIndexFromNonEmptyList()
        {
            var list = new ReversedList<int>() { 1, 2, 33 };

            list[4] = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetElementAtNegativeIndexFromNonEmptyList()
        {
            var list = new ReversedList<int>() { 1, 2, 33 };

            list[-544] = 10;
        }

        [TestMethod]
        public void SetElementAtValidIndexFromNonEmptyList()
        {
            var list = new ReversedList<int>() { 1, 2, 33 };

            list[2] = 5;

            CollectionAssert.AreEqual(new List<int>() { 33, 2, 5 }, GetReversedListItems(list));
        }

        private List<int> GetReversedListItems(ReversedList<int> list)
        {
            return list.Select(x => x).ToList();
        }
    }
}
