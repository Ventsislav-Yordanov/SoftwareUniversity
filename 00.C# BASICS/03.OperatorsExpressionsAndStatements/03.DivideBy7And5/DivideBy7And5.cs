/*Write a Boolean expression that checks for given integer if it can be divided (without remainder)
 * by 7 and 5 in the same time. */
using System;

    class DivideBy7And5
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            if (number % 5 == 0 && number % 7 == 0)
            {
                Console.WriteLine("Divided by 7 and 5?    Answer : True");
            }
            else
            {
                Console.WriteLine("Divided by 7 and 5?    Answer : False");
            }
        }
    }