namespace BankOfKurtovoKonare
{
    public interface IAccount
    {
        ICustomer Customer { get; set; }
        decimal Balance { get; }
        decimal MonthlyInterestRate { get; }
        decimal CalculateInterestRate(decimal months);
    }
}