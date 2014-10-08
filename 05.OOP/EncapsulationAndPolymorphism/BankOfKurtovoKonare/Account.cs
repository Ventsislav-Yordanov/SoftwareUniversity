namespace BankOfKurtovoKonare
{
    using System;
    public abstract class Account : IDepositable, IAccount
    {
        private ICustomer customer;
        private decimal monthlyInterestRate;
        private decimal balance;

        public Account(ICustomer customer, decimal monthlyInterestRate, decimal balance)
        {
            this.Customer = customer;
            this.MonthlyInterestRate = monthlyInterestRate;
            this.Balance = balance;
        }

        public ICustomer Customer
        {
            get { return this.customer; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Customer cannot be null!");
                }

                this.customer = value;
            }
        }

        public decimal MonthlyInterestRate
        {
            get { return this.monthlyInterestRate; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("MonthlyInterestRate cannot be negative!");
                }

                this.monthlyInterestRate = value;
            }
        }

        public decimal Balance
        {
            get { return this.balance; }
            protected set { this.balance = value; }
        }

        public virtual decimal CalculateInterestRate(decimal months)
        {
            return this.Balance * (1 + ((this.MonthlyInterestRate * months) / 100));
        }

        public virtual void Deposit(decimal sum)
        {
            this.Balance += sum;
        }
    }
}