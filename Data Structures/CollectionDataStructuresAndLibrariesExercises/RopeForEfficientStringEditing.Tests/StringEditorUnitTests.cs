namespace RopeForEfficientStringEditing.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class StringEditorUnitTests
    {
        [TestMethod]
        public void InsertValidStrings_ShouldInsertAtTheBeginning()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            editor.Insert(" is awesome.");
            editor.Insert("C#");

            // Assert
            string expected = "C# is awesome.";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertManyValidStrings_ShouldInsertAtTheBeginning()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            for (int i = 15; i > 0; i--)
            {
                editor.Insert(i.ToString());
            }

            // Assert
            string expected = "123456789101112131415";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertOnlyEmptyStrings_ShouldReturnEmptyString()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            for (int i = 0; i < 3; i++)
            {
                editor.Insert(string.Empty);
            }

            // Assert
            string expected = string.Empty;
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertEmptyStrings_ShouldReturnTheOriginalString()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC";
            editor.Insert(defaultText);

            // Act
            for (int i = 0; i < 3; i++)
            {
                editor.Insert(string.Empty);
            }

            // Assert
            var actual = editor.Print();
            Assert.AreEqual(defaultText, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertNullValue_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            editor.Insert(null);
        }

        [TestMethod]
        public void AppendValidStrings_ShouldAppendAtTheEnd()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            editor.Append("C#");
            editor.Append(" is awesome.");

            // Assert
            string expected = "C# is awesome.";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendManyValidStrings_ShouldAppendAtTheEnd()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            for (int i = 1; i <= 15; i++)
            {
                editor.Append(i.ToString());
            }

            // Assert
            string expected = "123456789101112131415";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendOnlyEmptyStrings_ShouldReturnEmptyString()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            for (int i = 0; i < 3; i++)
            {
                editor.Append(string.Empty);
            }

            // Assert
            string expected = string.Empty;
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AppendEmptyStrings_ShouldReturnTheOriginalString()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC";
            editor.Append(defaultText);

            // Act
            for (int i = 0; i < 3; i++)
            {
                editor.Insert(string.Empty);
            }

            // Assert
            var actual = editor.Print();
            Assert.AreEqual(defaultText, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AppendNullValue_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            editor.Append(null);
        }

        [TestMethod]
        public void Remove_ShouldRemoveSubstring()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC";
            editor.Append(defaultText);

            // Act
            editor.Delete(3, 4);

            // Assert
            string expected = "ASP MVC";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveManyTimes_ShouldRemoveSubstring()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(3, 4);
            editor.Delete(8, 3);

            // Assert
            string expected = "ASP MVC awesome!";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveNothing_ShouldReturnTheSameString()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(8, 0);
            editor.Delete(0, 0);
            editor.Delete(defaultText.Length - 1, 0);

            // Assert
            var actual = editor.Print();
            Assert.AreEqual(defaultText, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNegativeLength_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(8, -3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveTooLargeLength_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(8, 30);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveToEnd_ShouldRemoveTheSubstring()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(11, 12);

            // Assert
            string expected = "ASP.NET MVC";
            string actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveNegativeIndex_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(-3, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveTooLargeIndex_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC is awesome!";
            editor.Append(defaultText);

            // Act
            editor.Delete(80, 1);
        }

        [TestMethod]
        public void PrintNull_ShouldReturnEmptyString()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            string actual = editor.Print();

            // Assert
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintEmpty_ShouldReturnEmptyString()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            for (int i = 0; i < 3; i++)
            {
                editor.Append(string.Empty);
                editor.Insert(string.Empty);
            }

            string actual = editor.Print();

            // Assert
            string expected = string.Empty;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintNonEmpty_ShouldReturnTheCorrectString()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "C# is awesome!";
            editor.Append(defaultText);

            // Act
            string actual = editor.Print();

            // Assert
            Assert.AreEqual(defaultText, actual);
        }
    }
}
