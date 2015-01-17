namespace Phonebook 
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        private string name;
        private string nameInLowerInvariant;

        public PhonebookEntry(string name)
        {
            this.Name = name;
            this.PhoneNumbers = new SortedSet<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                // TODO: VALIDATION FOR TOO MUCH LONG NAME
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }

                this.name = value;
                this.nameInLowerInvariant = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> PhoneNumbers { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append('[');
            result.Append(this.Name);
            result.Append(": ");
            result.Append(string.Join(", ", this.PhoneNumbers));
            result.Append(']');

            return result.ToString();
        }

        public int CompareTo(PhonebookEntry other)
        {
            return this.nameInLowerInvariant.CompareTo(other.nameInLowerInvariant);
        }
    }
}
