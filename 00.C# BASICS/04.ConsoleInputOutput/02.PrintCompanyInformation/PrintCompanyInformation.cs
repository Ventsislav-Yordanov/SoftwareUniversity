/*A company has name, address, phone number, fax number, web site and manager.
 * The manager has first name, last name, age and a phone number.
 * Write a program that reads the information about a company
 * and its manager and prints it back on the console.*/
using System;

    class PrintCompanyInformation
    {
        static void Main()
        {
            Console.Write("Enter Company name : ");
            string companyName = (Console.ReadLine());
            Console.Write("Enter adress : ");
            string adress = (Console.ReadLine());
            Console.Write("Enter phone number : ");
            long companyPhonebumber = long.Parse(Console.ReadLine());
            Console.Write("Enter fax number : ");
            long companyFaxNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter web site : ");
            string webSite = (Console.ReadLine());
            Console.WriteLine();
            Console.Write("Enter manager : ");
            string manager = (Console.ReadLine());
            Console.Write("First name : ");
            string firstName = (Console.ReadLine());
            Console.Write("Last name : ");
            string lastName = (Console.ReadLine());
            Console.Write("Age : ");
            byte age = Byte.Parse(Console.ReadLine());
            Console.Write("Enter phone number : ");
            long phonebumber = long.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Company name : {0}",companyName);
            Console.WriteLine("Company adress : {0}",adress);
            Console.WriteLine("Comapny phone number : {0}",companyPhonebumber);
            Console.WriteLine("Company fax number : {0}",companyFaxNumber);
            Console.WriteLine("Company web site : {0}",webSite);
            Console.WriteLine();
            Console.WriteLine("Mangaer : {0}",manager);
            Console.WriteLine("First name : {0}", firstName);
            Console.WriteLine("Last name : {0}", lastName);
            Console.WriteLine("Age : {0}",age);
            Console.WriteLine("Phone number : {0}",phonebumber);
        }
    }