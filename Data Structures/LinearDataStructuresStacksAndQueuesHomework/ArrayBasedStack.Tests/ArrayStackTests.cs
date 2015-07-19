namespace ArrayBasedStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ImplementAnArrayBasedStack;
    using System.Collections.Generic;

    [TestClass]
    public class ArrayStackTests
    {
        [TestMethod]
        public void PopShoulReturnLastElement()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act 
            arrayStack.Push(1);
            arrayStack.Push(76);
            arrayStack.Push(33);
            arrayStack.Push(20);
            var element = arrayStack.Pop();

            // Assert
            Assert.AreEqual(3, arrayStack.Count);
            Assert.AreEqual(20, element);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void PopEmptyArrayStackShoulThrowException()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act
            arrayStack.Pop();
        }

        [TestMethod]
        public void PushSomeElementsShouldWorkAndIncreaseCount()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act
            arrayStack.Push(1);
            arrayStack.Push(76);
            arrayStack.Push(33);
            arrayStack.Push(20);

            var expectedResult = new int[] { 20, 33, 76, 1 };

            // Assert
            Assert.AreEqual(4, arrayStack.Count);
            CollectionAssert.AreEqual(expectedResult, arrayStack.ToArray());
        }

        [TestMethod]
        public void AfterSomePushAndPopCountShouldBeValid()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act 
            arrayStack.Push(1);
            arrayStack.Push(76);
            arrayStack.Pop();
            arrayStack.Push(33);
            arrayStack.Push(20);
            arrayStack.Pop();
            arrayStack.Push(56);


            // Assert
            Assert.AreEqual(3, arrayStack.Count);
        }

        [TestMethod]
        public void AfterSomePushAndPopArrayStackShouldBeValid()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act 
            arrayStack.Push(1);
            arrayStack.Push(76);
            arrayStack.Pop();
            arrayStack.Push(33);
            arrayStack.Push(20);
            arrayStack.Pop();
            arrayStack.Push(56);

            var expectedResult = new int[] { 56, 33, 1 };

            // Assert
            Assert.AreEqual(3, arrayStack.Count);
            CollectionAssert.AreEqual(expectedResult, arrayStack.ToArray());
        }


        [TestMethod]
        public void EmptyArrayStackShouldHaveCountZero()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Assert
            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void ArrayStackWithOneElementShouldHaveCountOne()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act
            arrayStack.Push(50);

            // Assert
            Assert.AreEqual(1, arrayStack.Count);
        }

        [TestMethod]
        public void ArrayStackShouldReturnCorrectlyCount()
        {
            // Arrange
            var arrayStack = new ArrayStack<string>();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                arrayStack.Push(string.Format("Test{0}", i.ToString()));

                // Assert
                Assert.AreEqual(i + 1, arrayStack.Count);
            }

            arrayStack.Pop();

            // Assert
            Assert.AreEqual(999, arrayStack.Count);
        }

        [TestMethod]
        public void ArrayStackWithInitialCapacityShoulReturnCorrectlyCount()
        {
            // Arrange
            var arrayStack = new ArrayStack<string>(1);

            // Assert
            Assert.AreEqual(0, arrayStack.Count);

            // Act
            arrayStack.Push("Pesho");
            arrayStack.Push("Gosho");

            // Assert
            Assert.AreEqual(2, arrayStack.Count);

            // Act
            arrayStack.Pop();

            // Assert
            Assert.AreEqual(1, arrayStack.Count);

            // Act
            arrayStack.Pop();

            // Assert
            Assert.AreEqual(0, arrayStack.Count);
        }

        [TestMethod]
        public void ToArrayMethodShouldReversNumbersOrder()
        {
            // Arrange
            var arrayStack = new ArrayStack<int>();

            // Act
            arrayStack.Push(3);
            arrayStack.Push(5);
            arrayStack.Push(-2);
            arrayStack.Push(7);

            // Assert
            CollectionAssert.AreEqual(
                new int[] { 7, -2, 5, 3 },
                arrayStack.ToArray());
        }

        [TestMethod]
        public void EmptyStackArrayConvertToArrayShouldReturnEmptyArray()
        {
            // Arrange
            var arrayStack = new ArrayStack<DateTime>();

            // Act
            arrayStack.ToArray();

            // Assert
            CollectionAssert.AreEqual(new DateTime[] { }, arrayStack.ToArray());
        }
    }
}
