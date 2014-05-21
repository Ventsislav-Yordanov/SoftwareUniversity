/*Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
•	Calculates the sum of the digits (in our example 2+0+1+1 = 4).
•	Prints on the console the number in reversed order: dcba (in our example 1102).
•	Puts the last digit in the first position: dabc (in our example 1201).
•	Exchanges the second and the third digits: acbd (in our example 2101).
The number has always exactly 4 digits and cannot start with 0.
*/
using System;

    class FourDigitNumber
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            int d = number % 10;
            number /= 10;
            int c = number % 10;
            number /= 10;
            int b = number % 10;
            number /= 10;
            int a = number % 10;

            int sumOfDigits = a + b + c + d;

            Console.WriteLine("Sum of digits : {0}",sumOfDigits);
            Console.WriteLine("The number in reversed order is: "+ d + c + b + a);
            Console.WriteLine("last digit in front: "+ d + a + b + c);
            Console.WriteLine("second and third digits exchanged: "+ a + c + b + d);
        }
    }
