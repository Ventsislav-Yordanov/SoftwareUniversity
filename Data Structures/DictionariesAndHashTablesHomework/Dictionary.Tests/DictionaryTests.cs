namespace Dictionary.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void EmptyConstructor_ShouldCreateEmptyDictionary()
        {
            var peopleAndGrades = new Dictionary<string, int>();

            Assert.IsNotNull(peopleAndGrades);
            Assert.AreEqual(0, peopleAndGrades.Count);
        }

        [TestMethod]
        public void AddElement_ShouldIncreaseCount()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Pesho", 2);

            Assert.AreEqual(1, peopleAndGrades.Count);
        }

        [TestMethod]
        public void RemoveElement_ShouldDecreaseCount()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            peopleAndGrades.Remove("Pesho");

            Assert.AreEqual(2, peopleAndGrades.Count);
        }

        [TestMethod]
        public void RemoveExistingElement_ShouldDecreaseCountAndReturnTrue()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isDeleted = peopleAndGrades.Remove("Pesho");

            Assert.AreEqual(true, isDeleted);
            Assert.AreEqual(2, peopleAndGrades.Count);
        }

        [TestMethod]
        public void RemoveNonExistingElement_ShouldDecreaseCountAndReturnFalse()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isDeleted = peopleAndGrades.Remove("NonExistingElement");

            Assert.AreEqual(false, isDeleted);
            Assert.AreEqual(3, peopleAndGrades.Count);
        }

        [TestMethod]
        public void ContainsKey_ShouldReturnTrueWhenKeyExists()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isExistsKey = peopleAndGrades.ContainsKey("Pesho");

            Assert.AreEqual(true, isExistsKey);
        }

        [TestMethod]
        public void ContainsKey_ShouldReturnFalseWhenKeyNonExists()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isExistsKey = peopleAndGrades.ContainsKey("Agar");

            Assert.AreEqual(false, isExistsKey);
        }

        [TestMethod]
        public void ContainsValue_ShouldReturnTrueWhenValueExists()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isExistsValue = peopleAndGrades.ContainsValue(5);

            Assert.AreEqual(true, isExistsValue);
        }

        [TestMethod]
        public void ContainsValue_ShouldReturnFalseWhenValueExists()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isExistsValue = peopleAndGrades.ContainsValue(90);

            Assert.AreEqual(false, isExistsValue);
        }

        [TestMethod]
        public void RemoveElement_ShouldReturnTrueWhenKeyExists()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isDeleted = peopleAndGrades.Remove("Marto");

            Assert.AreEqual(true, isDeleted);
        }

        [TestMethod]
        public void RemoveElement_ShouldReturnFalseWhenKeyExists()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            var isDeleted = peopleAndGrades.Remove("Marto###");

            Assert.AreEqual(false, isDeleted);
        }

        [TestMethod]
        public void Clear_ShouldRemoveAllElements()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);
            peopleAndGrades.Clear();

            Assert.AreEqual(0, peopleAndGrades.Count);

            peopleAndGrades.Add("Pavkata", 4);
            peopleAndGrades.Add("Mario", 6);

            Assert.AreEqual(2, peopleAndGrades.Count);

            peopleAndGrades.Clear();

            Assert.AreEqual(0, peopleAndGrades.Count);
        }

        [TestMethod]
        public void SetterAndGetter_ShouldWorkCorrectly()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades["Gosho"] = 2;
            peopleAndGrades["Pesho"] = 3;
            peopleAndGrades["Marto"] = 5;
            var martoGrade = peopleAndGrades["Marto"];

            Assert.AreEqual(5, martoGrade);
        }

        [TestMethod]
        public void Keys_ShouldWorkCorrectly()
        {
            // Arrange
            var peopleAndGrades = new Dictionary<string, int>();

            // Assert
            CollectionAssert.AreEquivalent(new string[0], peopleAndGrades.Keys.ToArray());

            // Arrange
            peopleAndGrades.Add("Peter", 5);
            peopleAndGrades.Add("Maria", 3);
            peopleAndGrades["Peter"] = 2;

            // Act
            var keys = peopleAndGrades.Keys;

            // Assert
            var expectedKeys = new string[] { "Peter", "Maria" };
            CollectionAssert.AreEquivalent(expectedKeys, keys.ToArray());
        }

        [TestMethod]
        public void Values_ShouldWorkCorrectly()
        {
            // Arrange
            var peopleAndGrades = new Dictionary<string, int>();

            // Assert
            CollectionAssert.AreEquivalent(new string[0], peopleAndGrades.Values.ToArray());

            // Arrange
            peopleAndGrades.Add("Peter", 5);
            peopleAndGrades.Add("Maria", 3);
            peopleAndGrades["Peter"] = 2;

            // Act
            var values = peopleAndGrades.Values;

            // Assert
            var expectedValues = new int[] { 3, 2 };
            CollectionAssert.AreEquivalent(expectedValues, values.ToArray());
        }

        [TestMethod]
        public void TryGetValue_ShouldWorkCorrectly()
        {
            var peopleAndGrades = new Dictionary<string, int>();
            peopleAndGrades.Add("Gosho", 2);
            peopleAndGrades.Add("Pesho", 3);
            peopleAndGrades.Add("Marto", 5);

            int mitkoGrade;
            var HasMitkoGrade = peopleAndGrades.TryGetValue("Mitko", out mitkoGrade);

            Assert.AreEqual(false, HasMitkoGrade);
            Assert.AreEqual(0, mitkoGrade);

            int martoGrade;
            var HasMartoGrade = peopleAndGrades.TryGetValue("Marto", out martoGrade);

            Assert.AreEqual(true, HasMartoGrade);
            Assert.AreEqual(5, martoGrade);
        }
    }
}
