/*A marketing company wants to keep record of its employees.
 * Each record would have the following characteristics:
•	First name
•	Last name
•	Age (0...100)
•	Gender (m or f)
•	Personal ID number (e.g. 8306112507)
•	Unique employee number (27560000…27569999)      */
using System;

    class EmployeeData
    {
        static void Main()
        {
            string firstName = "Ventsislav";
            string lastName = "Yordanov";
            sbyte age = 19;
            char gender = 'm';
            long ID = 8306112507;
            int employeeID = 27560930;

            Console.WriteLine("First Name : {0}",firstName);
            Console.WriteLine("Last Name : {0}",lastName);
            Console.WriteLine("Age : {0}",age);
            Console.WriteLine("Gender : {0}",gender);
            Console.WriteLine("Personal ID number : {0}",ID);
            Console.WriteLine("Unique employee number : {0}",employeeID);
            Console.WriteLine();
        }
    }
