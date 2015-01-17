namespace Phonebook
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class ChangePhoneTests
    {
        private PhonebookRepository repository;

        [TestInitialize]
        public void MethodInitialize()
        {
            this.repository = new PhonebookRepository();
        }

        [TestMethod]
        public void TestChangePhoneShouldReturnOneWhenOnePhoneiIsChanged()
        {
            this.repository.AddPhone("stanka", new[] { "(+359) 899777236", "0889787890" });
            var result = this.repository.ChangePhone("(+359) 899777236", "0883202020");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestChangePhoneShouldReturnTwoWhenTwoPhoneiIsChanged()
        {
            this.repository.AddPhone("stanka", new[] { "(+359) 899777236", "0889787890" });
            this.repository.AddPhone("penka", new[] { "(+359) 899777236", "0889765412" });
            var result = this.repository.ChangePhone("(+359) 899777236", "0883202020");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void TestChangePhoneShouldReturnZeroWhenNumberNotExists()
        {
            var result = this.repository.ChangePhone("(+359) 899777236", "0883202020");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestChangePhoneWithMerge()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555", "+359887333999" });
            this.repository.AddPhone("Ina", new string[] { "+359887333999" });
            this.repository.AddPhone("Ani", new string[] { "+359887333555", "359887333444" });
            int changedPhonesCount = this.repository.ChangePhone("+359887333999", "+359887333555");
            Assert.AreEqual(2, changedPhonesCount);
            string expectedResult =
                "[Ani: +359887333555, 359887333444]; [Ina: +359887333555]; [Nakov: +359887333555]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 3);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestChangeSingleExistingPhone()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            int changedPhonesCount = this.repository.ChangePhone("+359887333555", "+359888888888");
            Assert.AreEqual(1, changedPhonesCount);
            string expectedResult = "[Nakov: +359888888888]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 1);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestChangeSingleNonExistingPhone()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555" });
            this.repository.AddPhone("Niki", new string[] { "+359887333666" });
            int changedPhonesCount = this.repository.ChangePhone("+359887333777", "+359888888888");
            Assert.AreEqual(0, changedPhonesCount);
            string expectedResult = "[Nakov: +359887333555]; [Niki: +359887333666]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 2);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestChangeSharedPhone()
        {
            this.repository.AddPhone("Nakov", new string[] { "+359887333555", "+3592981981" });
            this.repository.AddPhone("Ina", new string[] { "+3592981981" });
            this.repository.AddPhone("Aneliya", new string[] { "+3592981981" });
            this.repository.AddPhone("Niki", new string[] { "+3592981981", "+359999888777" });
            int changedPhonesCount = this.repository.ChangePhone("+3592981981", "+3592982982");
            Assert.AreEqual(4, changedPhonesCount);
            string expectedResult =
                "[Aneliya: +3592982982]; [Ina: +3592982982]; [Nakov: +3592982982, +359887333555]; " +
                "[Niki: +3592982982, +359999888777]";
            IEnumerable<PhonebookEntry> listedEntries = this.repository.ListEntries(0, 4);
            string actualResult = string.Join("; ", listedEntries);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
