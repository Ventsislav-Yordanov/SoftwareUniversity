namespace BankOfKurtovoKonare
{
    using System;
    public abstract class Customer : ICustomer
    {
        private string name;

        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name cannot be empty or null!");
                }

                this.name = value;
            }
        }
    }
}