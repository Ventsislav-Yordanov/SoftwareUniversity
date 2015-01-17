namespace Phonebook
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddPhoneTests
    {
        private PhonebookRepository repository;
        [TestInitialize]
        public void MethodInitialize()
        {
            this.repository = new PhonebookRepository();
        }

        [TestMethod]
        public void TestAddDuplicatedEntry()
        {
            bool isNew = this.repository.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(true, isNew);
            isNew = this.repository.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(false, isNew);
            isNew = this.repository.AddPhone("Nakov", new string[] { "+359887333444" });
            Assert.AreEqual(false, isNew);
            Assert.AreEqual(1, this.repository.EntriesCount);
            Assert.AreEqual(1, this.repository.PhonesCount);
        }

        [TestMethod]
        public void TestAddPhoneShouldReturnTrueWhenNewUnexistingEntryIsAdded()
        {
            var result = this.repository.AddPhone("stanka", new[] { "0883445566" });
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestAddPhoneShouldReturnFalseWhenNewExistingEntryIsAdded()
        {
            this.repository.AddPhone("stanka", new[] { "0889145566" });
            var result = this.repository.AddPhone("stanka", new[] { "0883145566" });
            Assert.AreEqual(false, result, "Expected: {0}, Result: {1}", false, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddPhoneSWithInvalidNameShouldThrownException()
        {
            this.repository.AddPhone("", new[] { "0889145566" });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddPhoneSWithInvalidNameWithValueNullShouldThrownException()
        {
            this.repository.AddPhone("", new[] { "0889145566" });
        }
    }
}
