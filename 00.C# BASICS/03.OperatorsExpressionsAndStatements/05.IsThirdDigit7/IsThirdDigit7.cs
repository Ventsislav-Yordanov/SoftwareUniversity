/*Write an expression that checks for given integer if its third digit from right-to-left is 7.*/
using System;

    class IsThirdDigit7
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            number = number / 100;
            int thirdDigit = number % 10;

            if (thirdDigit == 7)
            {
                Console.WriteLine("Third digit 7?");
                Console.WriteLine("- True");
            }
            else
            {
                Console.WriteLine("Third digit 7?");
                Console.WriteLine("- False");

            }
        }
    }