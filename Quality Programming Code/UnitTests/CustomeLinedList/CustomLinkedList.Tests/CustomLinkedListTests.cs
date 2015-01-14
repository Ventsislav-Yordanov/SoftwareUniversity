using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomLinkedList.Tests
{
    [TestClass]
    public class CustomLinkedListTests
    {
        private DynamicList<string> myList;

        [TestInitialize]
        public void MethodInitialize()
        {
            myList = new DynamicList<string>();
            myList.Add("firstItem");
            myList.Add("secondItem");
            myList.Add("thirdItem");
            myList.Add("fourthItem");
            myList.Add("fifthItem");
            myList.Add("sixthItem");
            myList.Add("seventhItem");
        }

        [TestMethod]
        public void AddMethodShoulcIncreaseTheElementsCount()
        {
            Assert.AreEqual(7, myList.Count,
                "Expected element Count: {0}, Actual Elements count: {1}", 7, myList.Count);
        }

        [TestMethod]
        public void AddMethodShouldAddNullWhenArgumentIsNull()
        {
            myList.Add(null);
            var lastPosition = myList.Count - 1;
            Assert.AreEqual(null, myList[lastPosition]);
        }

        [TestMethod]
        public void AddMethodShoulAddItemOnLastPosition()
        {
            myList.Add("NewItem");
            var lastPosition = myList.Count - 1;
            Assert.AreEqual("NewItem", myList[lastPosition]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerShouldReturnExceptionWhenInvalidIndexIsRequested()
        {
            Console.WriteLine(myList[myList.Count]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerShouldReturnExceptionWhenNegativeIndexIsRequested()
        {
            Console.WriteLine(myList[-1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerShouldReturnExceptionSettingElementOnInvalidPosition()
        {
            myList[myList.Count] = "test inserting";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IndexerShouldReturnExceptionSettingElementOnNegitvePosition()
        {
            myList[-1] = "test inserting again";
        }

        [TestMethod]
        public void IndexerShouldAllowInsertingElementOnValidPosition()
        {
            myList[1] = "insertedItem";
            Assert.AreSame("firstItem", myList[0]);
            Assert.AreSame("insertedItem", myList[1]);
            Assert.AreSame("thirdItem", myList[2]);
            Assert.AreSame("fourthItem", myList[3]);
            Assert.AreSame("fifthItem", myList[4]);
            Assert.AreSame("sixthItem", myList[5]);
            Assert.AreSame("seventhItem", myList[6]);
        }

        [TestMethod]
        public void IndexShouldReturnItemWhenValidIndexIsRquest()
        {
            var firstItem = myList[0];
            Assert.AreEqual("firstItem", firstItem);

        }

        [TestMethod]
        public void RemoveAtMethodSHouldRemoveItemOnLastPosition()
        {
            var lastPosition = myList.Count - 1;
            myList.RemoveAt(lastPosition);
            lastPosition = myList.Count - 1;
            Assert.AreEqual("sixthItem", myList[lastPosition]);
        }

        [TestMethod]
        public void RemoveAtMethodSHouldRemoveItemOnFirstPosition()
        {
            myList.RemoveAt(0);
            Assert.AreEqual("secondItem", myList[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtMethodSHouldRemoveItemAtLastPostion()
        {
            var lastPosition = myList.Count - 1;
            myList.RemoveAt(lastPosition);
            Console.WriteLine(myList[lastPosition]);
        }

        [TestMethod]
        public void RemoveAtShoulDecraseCount()
        {
            myList.RemoveAt(3);
            Assert.AreEqual(6, myList.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveAtShoulThrowExceptionWhenIndexIsNegative()
        {
            myList.RemoveAt(-1);
        }

        [TestMethod]
        public void RemoveShouldReturnTheIndexOfRemovedElement()
        {
            int index = myList.Remove("secondItem");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void RemoveShouldReturnMinusOnewhenRemovingElementIsInvalid()
        {
            int index = myList.Remove("noItem");
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void RemoveShouldReorderElementsAfterRemoving()
        {
            myList.Remove("fifthItem");
            Assert.AreSame("sixthItem", myList[4]);
        }

        [TestMethod]
        public void RemoveShouldDecraseCount()
        {
            myList.Remove("sixthItem");
            Assert.AreEqual(6, myList.Count);
        }

        [TestMethod]
        public void IndexOfShoulReturnMinusOneWhenItemIsNonExisting()
        {
            var index = myList.IndexOf("fakeItem");
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void IndexOfShoulReturnIndexOfItemWhenItemIsExisting()
        {
            var index = myList.IndexOf("seventhItem");
            Assert.AreEqual(6, index);
        }

        [TestMethod]
        public void ContainsShouldReturnTrueWhenItemExists()
        {
            var condition = myList.Contains("fifthItem");
            Assert.IsTrue(condition);
        }
        [TestMethod]
        public void ContainsShouldReturnFalseWhenItemNotExists()
        {
            var condition = myList.Contains("megaFakeItem");
            Assert.IsFalse(condition);
        }
    }
}
