namespace BankOfKurtovoKonare
{
    using System;
    using System.Collections.Generic;
    public class TestBankSystem
    {
        static void Main(string[] args)
        {
            ICustomer mitko = new IndividualCustomer("Dimitar Obretenov");
            ICustomer alex = new IndividualCustomer("Alex Petrov");
            ICustomer rosko = new IndividualCustomer("Rostislav Savov");
            ICustomer bobi = new IndividualCustomer("Boqna Ivailova");
            ICustomer nikeCompany = new CompanyCustomer("Nike ltd.");
            ICustomer adidasCompany = new CompanyCustomer("Adidas ltd.");
            ICustomer pumaCompany = new CompanyCustomer("Puma ltd.");

            IAccount mortgageAccIndividual = new MortgageAccount(mitko, 5.5m, 1500m);
            IAccount mortgageAccCompany = new MortgageAccount(nikeCompany, 6m, 3250m);
            IAccount loanAccIndividual = new LoanAccount(alex, 6.1m, 5000m);
            IAccount loanAccCompany = new LoanAccount(adidasCompany, 4.1m, 5000m);
            IAccount depositAccIndividualSmall = new DepositAccount(rosko, 4.5m, 970m);
            IAccount depositAccIndividualBig = new DepositAccount(bobi, 5m, 1500m);
            IAccount depostAccCompany = new DepositAccount(pumaCompany, 5.1m, 1700m);

            List<IAccount> accounts = new List<IAccount>()
            {
                mortgageAccIndividual,
                mortgageAccCompany,
                loanAccIndividual,
                loanAccCompany,
                depositAccIndividualBig,
                depositAccIndividualSmall,
                depostAccCompany
            };

            foreach (var account in accounts)
            {
                Console.Write("Type customer: {0}, ", account.Customer.GetType().Name);
                Console.WriteLine("Type account: {0}, ", account.GetType().Name);
                Console.WriteLine("Calculate interest rate for 2 months: {0}, ", account.CalculateInterestRate(2));
                Console.WriteLine("Calculate interest rate for 5 months: {0}, ", account.CalculateInterestRate(5));
                Console.WriteLine("Calculate interest rate for 7 months: {0}, ", account.CalculateInterestRate(7));
                Console.WriteLine("Calculate interest rate for 13 months: {0}, ", account.CalculateInterestRate(13));
                Console.WriteLine();
            }
        }
    }
}