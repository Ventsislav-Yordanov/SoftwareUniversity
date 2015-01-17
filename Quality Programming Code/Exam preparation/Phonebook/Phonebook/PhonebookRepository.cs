namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class PhonebookRepository : IPhonebookRepository
    {
        private OrderedSet<PhonebookEntry> sortedEntries;
        private IDictionary<string, PhonebookEntry> entriesByName;
        private MultiDictionaryBase<string, PhonebookEntry> entriesByPhone;

        public PhonebookRepository()
            : this(new Dictionary<string, PhonebookEntry>(), new MultiDictionary<string, PhonebookEntry>(false))
        {
        }

        public PhonebookRepository(IDictionary<string, PhonebookEntry> entriesByName, MultiDictionaryBase<string, PhonebookEntry> entriesByPhone)
        {
            this.sortedEntries = new OrderedSet<PhonebookEntry>();
            this.entriesByName = entriesByName;
            this.entriesByPhone = entriesByPhone;
        }

        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            string nameToLowerInvariant = name.ToLowerInvariant();
            PhonebookEntry entry;
            bool doesEntryNotExists = !this.entriesByName.TryGetValue(nameToLowerInvariant, out entry);
            if (doesEntryNotExists)
            {
                entry = new PhonebookEntry(name);
                this.entriesByName.Add(nameToLowerInvariant, entry);
                this.sortedEntries.Add(entry);
            }

            this.AddPhoneNumbersToEntriesByPhone(phoneNumbers, entry);

            entry.PhoneNumbers.UnionWith(phoneNumbers);
            return doesEntryNotExists;
        }        

        public int ChangePhone(string oldNumber, string newNumber)
        {
            // ToList() is bottleneck because it makes the operation slow. Cannot fix.
            var foundEntries = this.entriesByPhone[oldNumber].ToList();
            foreach (var entry in foundEntries)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                this.entriesByPhone.Remove(oldNumber, entry);
                entry.PhoneNumbers.Add(newNumber);
                this.entriesByPhone.Add(newNumber, entry);
            }

            return foundEntries.Count;
        }

        public IEnumerable<PhonebookEntry> ListEntries(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex + count > this.entriesByName.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count");
            }

            var result = new List<PhonebookEntry>(count);

            for (int i = startIndex; i <= startIndex + count - 1; i++)
            {
                result.Add(this.sortedEntries[i]);
            }

            return result;
        }

        private void AddPhoneNumbersToEntriesByPhone(IEnumerable<string> phoneNumbers, PhonebookEntry entry)
        {
            foreach (var number in phoneNumbers)
            {
                this.entriesByPhone.Add(number, entry);
            }
        }

        // Add for easy unit testing
        public int EntriesCount
        {
            get
            {
                return this.entriesByName.Count;
            }
        }

        public int PhonesCount
        {
            get
            {
                return this.entriesByPhone.Count;
            }
        }
    }
}
