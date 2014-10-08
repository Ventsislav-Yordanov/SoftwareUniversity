namespace BankOfKurtovoKonare
{
    public class DepositAccount : Account, IAccount, IDepositable, IWithdrawable
    {
        public DepositAccount(ICustomer customer, decimal monthlyInterestRate, decimal balance)
            : base(customer, monthlyInterestRate, balance)
        {

        }

        public void WithDraw(decimal sum)
        {
            this.Balance -= sum;
        }

        public override decimal CalculateInterestRate(decimal months)
        {
            if (this.Balance >= 0 && this.Balance < 1000)
            {
                return this.Balance;
            }

            else
            {
                return base.CalculateInterestRate(months);
            }
        }
    }
}