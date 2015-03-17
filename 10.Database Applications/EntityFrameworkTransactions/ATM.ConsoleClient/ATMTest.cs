namespace ATM.ConsoleClient
{
    using System;

    using ATM.Entities;

    public class ATMTest
    {
        public static void Main()
        {
            Console.WriteLine("Please wait...");
            AccountOperations.Withdraw("1234567890", "0609", 300);
            //AccountOperations.Withdraw("1235423462", "5540", 300); // returns "The card number or pin code is wrong"
            //AccountOperations.Withdraw("1235423462", "5550", 30000); // returns "Insufficient funds"
        }
    }
}
