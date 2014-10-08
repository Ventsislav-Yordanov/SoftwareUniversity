namespace BankOfKurtovoKonare
{
    public class MortgageAccount : Account, IAccount, IDepositable
    {
        public MortgageAccount(ICustomer customer, decimal monthlyInterestRate, decimal balance)
            : base(customer, monthlyInterestRate, balance)
        {

        }

        public override decimal CalculateInterestRate(decimal months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months >= 6)
                {
                    return base.CalculateInterestRate(months - 6);
                }

                else
                {
                    return this.Balance;
                }
            }

            if (this.Customer is CompanyCustomer)
            {
                if (months <= 12)
                {
                    return base.CalculateInterestRate(months) / 2;
                }

                else
                {
                    return (base.CalculateInterestRate(12) / 2) + base.CalculateInterestRate(months - 12);
                }
            }

            return CalculateInterestRate(months);
        }
    }
}