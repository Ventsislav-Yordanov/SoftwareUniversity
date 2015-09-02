namespace StringEditor.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StringEditorUnitTests
    {
        [TestMethod]
        public void InsertValidStrings_ShouldInsertCorrectly()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            editor.Insert(" is awesome.", 0);
            editor.Insert("C#", 0);

            // Assert
            string expected = "C# is awesome.";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertManyValidStrings_ShouldInsertCorrectly()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            for (int i = 15; i > 0; i--)
            {
                editor.Insert(i.ToString(), 0);
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
                editor.Insert(string.Empty, 0);
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
            editor.Insert(defaultText, 0);

            // Act
            for (int i = 0; i < 3; i++)
            {
                editor.Insert(string.Empty, 0);
            }

            // Assert
            var actual = editor.Print();
            Assert.AreEqual(defaultText, actual);
        }

        [TestMethod]
        public void InsertValidStringsAtTheMiddle_ShouldInsertCorrectly()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "C# awesome";
            editor.Insert(defaultText, 0);

            // Act
            editor.Insert("is ", 3);

            // Assert
            var actual = editor.Print();
            string expected = "C# is awesome";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InsertNullValue_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();

            // Act
            editor.Insert(null, 0);
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
                editor.Insert(string.Empty, 0);
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
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
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
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
        public void Replace_ShouldReplaceSubstringCorrectly()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(3, 1, ".NET ");

            // Assert
            string expected = "ASP.NET MVC";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReplaceAtTheBeginning_ShouldReplaceSubstringCorrectly()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(0, 4, ".");

            // Assert
            string expected = ".NET MVC";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReplaceAtTheEnd_ShouldReplaceSubstringCorrectly()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.NET MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(8, 3, "WebForms");

            // Assert
            string expected = "ASP.NET WebForms";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReplaceZeroSymbols_ShouldInsertSubstring()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(3, 0, ".NET");

            // Assert
            string expected = "ASP.NET MVC";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReplaceWithEmptyString_ShouldReturnTheOriginalSubstring()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP MVC";
            editor.Append(defaultText);

            // Act
            for (int i = 0; i < 5; i++)
            {
                editor.Replace(3, 0, string.Empty);
            }

            // Assert
            string expected = "ASP MVC";
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReplaceWholeStringWithEmpty_ShouldReturnEmptyString()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(0, defaultText.Length, string.Empty);

            // Assert
            string expected = string.Empty;
            var actual = editor.Print();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReplaceAtNegativeIndex_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(-5, 1, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReplaceAtTooLargeIndex_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(50, 1, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReplaceNegativeCount_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(0, -5, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReplaceTooLargeCount_ShouldThrowAnException()
        {
            // Arrange
            var editor = new StringEditor();
            string defaultText = "ASP.MVC";
            editor.Append(defaultText);

            // Act
            editor.Replace(0, 50, string.Empty);
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
                editor.Insert(string.Empty, 0);
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
