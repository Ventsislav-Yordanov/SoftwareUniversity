namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListPhoneTests
    {
        private PhonebookRepository repository;

        [TestInitialize]
        public void MethodInitialize()
        {
            this.repository = new PhonebookRepository();
        }
        
        [TestMethod]
        public void TestListPhoneShouldReturnOnePhoneAndName()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            string expectedResult = "[Nakov: +359887333555]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 1);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestListPhoneShouldReturnTwoPhonesAndOneName()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            this.repository.AddPhone("Nakov", new string[] { "+359887333556" });
            string expectedResult = "[Nakov: +359887333555, +359887333556]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 1);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestListMultipleEntriesWithMergeAndSorting()
        {
            PhonebookRepository phonebook = new PhonebookRepository();
            this.repository.AddPhone("Svetlin Nakov", new string[] { "+359887333555", "+35962445566" });
            this.repository.AddPhone("SVETLIN NAKOV", new string[] { "+3592555444", "+359887333555" });
            this.repository.AddPhone("Niki Kostov", new string[] { "+35989911222", "+35929887744" });
            this.repository.AddPhone("niki kostov", new string[] { "+35929887744", "+35989911222" });
            string expectedResult =
                "[Niki Kostov: +35929887744, +35989911222]; [Svetlin Nakov: +3592555444, +35962445566, +359887333555]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 2);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult); 
        }

        [TestMethod]
        public void TestListMultipleEntriesSubPageWithSorting()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            this.repository.AddPhone("Niki", new string[] { "+35989911222" });
            this.repository.AddPhone("Ani", new string[] { "+359886344544" });
            this.repository.AddPhone("Yana", new string[] { "+3599874456" });
            this.repository.AddPhone("Tanya", new string[] { "+359884222333" });
            string expectedResult =
                "[Nakov: +359887333555]; [Niki: +35989911222]; [Tanya: +359884222333]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(1, 3);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListMultipleEntriesNegativeStart()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            this.repository.ListEntries(-1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListMultipleEntriesInvalidStart()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            this.repository.ListEntries(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListMultipleEntriesInvalidCount()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            this.repository.AddPhone("Jorro", new string[] { "+359888444777" });
            this.repository.ListEntries(1, 2);
        }
    }
}
