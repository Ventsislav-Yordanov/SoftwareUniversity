namespace ATM.ConsoleClient
{
    using System;
    using System.Data;
    using System.Linq;
    
    using ATM.Entities;

    public class AccountOperations
    {
        public static void Withdraw(string cardNumber, string pinCode, decimal sumAmmount)
        {
            var context = new ATMDBEntities();

            using (var dbContextTransaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    Console.WriteLine("Withdrawing...");

                    var account = context
                        .CardAccounts
                        .Where(a => a.CardNumber == cardNumber && a.CardPIN == pinCode)
                        .FirstOrDefault();

                    if (account == null)
                    {
                        throw new InvalidOperationException("The card number or pin code is wrong");
                    }

                    if (sumAmmount > account.CardCash)
                    {
                        throw new ArgumentOutOfRangeException("The requested sum amount is greather than current balance");
                    }

                    account.CardCash -= sumAmmount;
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    Console.WriteLine("Transaction completed. Withdrawn sum: {0}. Balance After withdraw: {1}",
                        sumAmmount, account.CardCash);

                    LogTransactionHistory(cardNumber, pinCode, sumAmmount);
                }
                catch (Exception e)
                {
                    var exceptionType = e.GetType().ToString();
                    switch (exceptionType)
                    {
                        case "System.InvalidOperationException":
                            Console.WriteLine("The card number or pin code is wrong");
                            break;
                        case "System.ArgumentOutOfRangeException":
                            Console.WriteLine("Insufficient funds");
                            break;
                        default:
                            break;
                    }

                    dbContextTransaction.Rollback();
                }
            }
        }

        private static void LogTransactionHistory(string cardNumber, string pinCode, decimal ammount)
        {
            var context = new ATMDBEntities();
            var newLog = new TransactionHistory
            {
                CardNumber = cardNumber,
                TransactionDate = DateTime.Now,
                Amount = ammount
            };

            context.TransactionHistories.Add(newLog);
            context.SaveChanges();
        }
    }
}
