/*Write a program that enters 3 real numbers and prints them sorted in descending order.
 * Use nested if statements. Don’t use arrays and the built-in sorting functionality. */
using System;

    class Sort3NumbersWithNestedIfs
    {
        static void Main()
        {
            Console.Write("Enter 1st number : ");
            decimal numA = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number : ");
            decimal numB = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter 3rd number : ");
            decimal numC = Decimal.Parse(Console.ReadLine());

            decimal theBiggest = 0;
            decimal theMiddle = 0;
            decimal theSmallest = 0;

            if (numA >= numB && numB >= numC)
            {
                theSmallest = numC;
                if (numA >= numB)
                {
                    theBiggest = numA;
                    theMiddle = numB;
                }
                else
                {
                    theBiggest = numB;
                    theMiddle = numA;
                }
            }
            else if (numA >= numB && numB <= numC)
            {
                theSmallest = numB;
                if (numA >= numC)
                {
                    theBiggest = numA;
                    theMiddle = numC;
                }
                else
                {
                    theBiggest = numC;
                    theMiddle = numA;
                }
            }
            else
            {
                theSmallest = numA;
                if (numB >= numC)
                {
                    theBiggest = numB;
                    theMiddle = numC;
                }
                else
                {
                    theBiggest = numC;
                    theMiddle = numB;
                }
            }

            Console.WriteLine("These 3 numbers, sorted in Descending order are: {0}, {1}, {2} !",
            theBiggest, theMiddle, theSmallest);
        }
    }