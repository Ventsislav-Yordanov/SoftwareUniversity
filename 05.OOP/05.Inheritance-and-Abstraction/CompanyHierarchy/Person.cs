namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public abstract class Person : IPerson
    {
        private static HashSet<string> uniqueIds;

        private string id;
        private string firstName;
        private string lastName;

        static Person()
        {
            Person.uniqueIds = new HashSet<string>();
        }

        public Person(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Id cannot be empty or null!");
                }

                if (Person.uniqueIds.Contains(value))
                {
                    throw new ArgumentException("Id is busy, please enter different id!");
                }

                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("firstName cannot be empty or null!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("lastName cannot be empty or null!");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\nFirst Name: {1}\nLast Name: {2}", this.Id, this.FirstName, this.LastName);
        }
    }
}