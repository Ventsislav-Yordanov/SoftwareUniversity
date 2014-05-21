/*A bank account has a holder name (first name, middle name and last name),
 * available amount of money (balance), bank name, IBAN,
 * 3 credit card numbers associated with the account.
 * Declare the variables needed to keep the information for a single bank account
 * using the appropriate data types and descriptive names.*/
using System;

    class BankAccountData
    {
        static void Main()
        {
            string firstName = "Ivan";
            string middleName = "Petrov";
            string lastName = "Ivanov";
            decimal money = 1000m; // лв , $
            string bankName = "UNITED BULGARIAN BANK";
            string IBAN = "BG20TTBB94003528841245";
            ulong creditCard = 0020020043683988;
            ulong masterCard = 2627869517354678;
            ulong debitCard = 4467911156783559;

            Console.WriteLine("First Name : {0}",firstName);
            Console.WriteLine("Middle Name : {0}", middleName);
            Console.WriteLine("Last Name : {0}", lastName);
            Console.WriteLine("Available amount of money (balance) : {0:c}", money);
            Console.WriteLine("Bank name : {0}",bankName);
            Console.WriteLine("IBAN : {0}",IBAN);
            Console.WriteLine("Credit Card : {0}",creditCard);
            Console.WriteLine("Mater Card : {0}", masterCard);
            Console.WriteLine("Debit Card : {0}", debitCard);

        }
    }