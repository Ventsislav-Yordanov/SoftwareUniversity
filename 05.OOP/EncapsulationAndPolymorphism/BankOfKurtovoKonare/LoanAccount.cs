namespace BankOfKurtovoKonare
{
    public class LoanAccount : Account, IAccount, IDepositable
    {
        public LoanAccount(ICustomer customer, decimal monthlyInterestRate, decimal balance)
            : base(customer, monthlyInterestRate, balance)
        {

        }

        public override decimal CalculateInterestRate(decimal months)
        {
            if (this.Customer is IndividualCustomer)
            {
                if (months >= 3)
                {
                    return base.CalculateInterestRate(months - 3);
                }

                else
                {
                    return this.Balance;
                }
            }

            if (this.Customer is CompanyCustomer)
            {
                if (months >= 2)
                {
                    return base.CalculateInterestRate(months - 2);
                }

                else
                {
                    return this.Balance;
                }
            }

            return CalculateInterestRate(months);
        }
    }
}
