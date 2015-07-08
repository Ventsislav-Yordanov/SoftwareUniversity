namespace LinkedList.Tests
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ImplementALinkedList;
    using SCG = System.Collections.Generic;

    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void CreateEmptyList()
        {
            var list = new LinkedList<int>();

            Assert.IsNotNull(list);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void AddToEmptyList()
        {
            var list = new LinkedList<int>();

            list.Add(5);

            Assert.AreEqual(1, list.Count);
            CollectionAssert.AreEqual(new SCG.List<int>() { 5 }, this.GetLinkedListItems(list));
        }

        [TestMethod]
        public void AddSeveralItems()
        {
            var list = new LinkedList<int>();

            list.Add(5);
            list.Add(25);
            list.Add(35);
            list.Add(31005);
            list.Add(88);
            list.Add(23);

            Assert.AreEqual(6, list.Count);
            CollectionAssert.AreEqual(
                new SCG.List<int>() { 5, 25, 35, 31005, 88, 23 },
                this.GetLinkedListItems(list));
        }

        [TestMethod]
        public void RemoveWhenListHasOneElement()
        {
            var list = new LinkedList<int>();

            list.Add(5);
            list.Remove(0);

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFromEmptyList()
        {
            var list = new LinkedList<int>();

            list.Remove(0);
        }

        [TestMethod]
        public void RemoveAtFirstIndex()
        {
            var list = new LinkedList<int>() { 2, 3, 4, 7, 1 };

            list.Remove(0);
            list.Remove(0);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new SCG.List<int>() { 4, 7, 1 },
                this.GetLinkedListItems(list));
        }

        [TestMethod]
        public void RemoveAtLastIndex()
        {
            var list = new LinkedList<int>() { 2, 3, 4, 7, 1 };

            list.Remove(list.Count - 1);
            list.Remove(list.Count - 1);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new SCG.List<int>() { 2, 3, 4 },
                this.GetLinkedListItems(list));
        }

        [TestMethod]
        public void RemoveAtMiddleIndex()
        {
            var list = new LinkedList<int>() { 2, 3, 4, 7, 1 };

            list.Remove(2);
            list.Remove(3);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(
                new SCG.List<int>() { 2, 3, 7 },
                this.GetLinkedListItems(list));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtNegativeIndex()
        {
            var list = new LinkedList<int>() { 2, 3, 4, 7, 1 };

            list.Remove(-20);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtTooLargeIndex()
        {
            var list = new LinkedList<int>() { 2, 3, 4, 7, 1 };

            list.Remove(20);
        }

        [TestMethod]
        public void EnumeratorWorksForEmptyList()
        {
            var list = new LinkedList<int>();

            var listItems = new SCG.List<int>();
            foreach (var item in list)
            {
                listItems.Add(item);
            }

            Assert.AreEqual(0, listItems.Count);
        }

        [TestMethod]
        public void EnumeratorWorksForSingleElementInList()
        {
            var list = new LinkedList<int>() { 1 };

            var listItems = new SCG.List<int>();
            foreach (var item in list)
            {
                listItems.Add(item);
            }

            Assert.AreEqual(1, listItems.Count);
            CollectionAssert.AreEqual(new SCG.List<int>() { 1 }, listItems);
        }

        [TestMethod]
        public void EnumeratorWorksForManyElementsInList()
        {
            var list = new LinkedList<int>() { 1, 100, 2321, 2, 5 };

            var listItems = new SCG.List<int>();
            foreach (var item in list)
            {
                listItems.Add(item);
            }

            Assert.AreEqual(5, listItems.Count);
            CollectionAssert.AreEqual(new SCG.List<int>() { 1, 100, 2321, 2, 5 }, listItems);
        }

        [TestMethod]
        public void FirstIndexOfExistingElement()
        {
            var list = new LinkedList<int>() { 1, 100, 2321, 2, 5 };

            int index = list.FirstIndexOf(2321);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void FirstIndexOfRepeatedElement()
        {
            var list = new LinkedList<int>() { 2321, 1, 100, 2321, 2321, 2321, 2, 5, 2321 };

            int index = list.FirstIndexOf(2321);

            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void FirstIndexOfNonExistingElement()
        {
            var list = new LinkedList<int>() { 2321, 1, 100, 2321, 2321, 2321, 2, 5, 2321 };

            int index = list.FirstIndexOf(123123123);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void FirstIndexOfEmptyList()
        {
            var list = new LinkedList<int>();

            int index = list.FirstIndexOf(123123123);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void LastIndexOfExistingElement()
        {
            var list = new LinkedList<int>() { 1, 100, 2321, 2, 5 };

            int index = list.LastIndexOf(2321);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void LastIndexOfRepeatedElement()
        {
            var list = new LinkedList<int>() { 2321, 1, 100, 2321, 2321, 2321, 2, 5, 2321 };

            int index = list.LastIndexOf(2321);

            Assert.AreEqual(8, index);
        }

        [TestMethod]
        public void LastIndexOfNonExistingElement()
        {
            var list = new LinkedList<int>() { 2321, 1, 100, 2321, 2321, 2321, 2, 5, 2321 };

            int index = list.LastIndexOf(123123123);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void LastIndexOfEmptyList()
        {
            var list = new LinkedList<int>();

            int index = list.LastIndexOf(123123123);

            Assert.AreEqual(-1, index);
        }

        private SCG.List<int> GetLinkedListItems(LinkedList<int> list)
        {
            return list.Select(x => x).ToList();
        }
    }
}
