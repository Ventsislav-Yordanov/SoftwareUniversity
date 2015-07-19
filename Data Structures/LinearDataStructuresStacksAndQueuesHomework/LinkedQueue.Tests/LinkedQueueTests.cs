namespace LinkedQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void DequeueShoulReturnFirstElement()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act 
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(76);
            linkedQueue.Enqueue(33);
            linkedQueue.Enqueue(20);
            var element = linkedQueue.Dequeue();

            // Assert
            Assert.AreEqual(3, linkedQueue.Count);
            Assert.AreEqual(1, element);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void DequeueEmptyArrayStackShoulThrowException()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Dequeue();
        }

        [TestMethod]
        public void EnqueueomeElementsShouldWorkAndIncreaseCount()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(76);
            linkedQueue.Enqueue(33);
            linkedQueue.Enqueue(20);

            var expectedResult = new int[] { 1, 76, 33, 20 };

            // Assert
            Assert.AreEqual(4, linkedQueue.Count);
            CollectionAssert.AreEqual(expectedResult, linkedQueue.ToArray());
        }

        [TestMethod]
        public void AfterSomeEnqueueAndDequeueCountShouldBeValid()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act 
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(76);
            linkedQueue.Dequeue();
            linkedQueue.Enqueue(33);
            linkedQueue.Enqueue(20);
            linkedQueue.Dequeue();
            linkedQueue.Enqueue(56);


            // Assert
            Assert.AreEqual(3, linkedQueue.Count);
        }

        [TestMethod]
        public void AfterSomeEnqueueAndDequeueQueueShouldBeValid()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act 
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(76);
            linkedQueue.Dequeue();
            linkedQueue.Enqueue(33);
            linkedQueue.Enqueue(20);
            linkedQueue.Dequeue();
            linkedQueue.Enqueue(56);

            var expectedResult = new int[] { 33, 20, 56 };

            // Assert
            Assert.AreEqual(3, linkedQueue.Count);
            CollectionAssert.AreEqual(expectedResult, linkedQueue.ToArray());
        }


        [TestMethod]
        public void EmptyQueueShouldHaveCountZero()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Assert
            Assert.AreEqual(0, linkedQueue.Count);
        }

        [TestMethod]
        public void QueueWithOneElementShouldHaveCountOne()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Enqueue(50);

            // Assert
            Assert.AreEqual(1, linkedQueue.Count);
        }

        [TestMethod]
        public void QueueShouldReturnCorrectlyCount()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<string>();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                linkedQueue.Enqueue(string.Format("Test{0}", i.ToString()));

                // Assert
                Assert.AreEqual(i + 1, linkedQueue.Count);
            }

            linkedQueue.Dequeue();

            // Assert
            Assert.AreEqual(999, linkedQueue.Count);
        }

        [TestMethod]
        public void ToArrayMethodShouldWorkCorrectly()
        {
            // Arrange
            var linkedQueue = new LinkedQueue<int>();

            // Act
            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(-2);
            linkedQueue.Enqueue(7);

            // Assert
            CollectionAssert.AreEqual(new int[] { 3, 5, -2, 7 }, linkedQueue.ToArray());
        }

        [TestMethod]
        public void EmptyQueueConvertToArrayShouldReturnEmptyArray()
        {
            // Arrange
            var arrayStack = new LinkedQueue<DateTime>();

            // Act
            arrayStack.ToArray();

            // Assert
            CollectionAssert.AreEqual(new DateTime[] { }, arrayStack.ToArray());
        }
    }
}
