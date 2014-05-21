/*You are given n integers (given in a single line, separated by a space).
 * Write a program that checks whether the product of the odd elements is equal
 * to the product of the even elements. Elements are counted from 1 to n, so the first element is odd,
 * the second is even, etc. 
 * Examples: https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx    */
using System;

    class OddAndEvenProduct
    {
        static void Main()
        {
            int evenProduct = 1;
            int oddProduct = 1;

            Console.Write("Enter number of integers : ");
            int numberIntegers = Int32.Parse(Console.ReadLine());
            Console.Write("Enter numbers : ");
            string numbers = Console.ReadLine();
            string[] splitedNumbers = numbers.Split(new char[] { ' ' },
                                                    StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < numberIntegers; i++)
            {
                int number = int.Parse(splitedNumbers[i]);

                if (i % 2 == 0)
                {
                    evenProduct *= number;
                }
                else
                {
                    oddProduct *= number;
                }
            }

            if (evenProduct == oddProduct)
            {
                Console.WriteLine("yes");
                Console.WriteLine("product = " + evenProduct);
            }
            else
            {
                Console.WriteLine("no");
                Console.WriteLine("odd_product = " + oddProduct);
                Console.WriteLine("even_product = " + evenProduct);
            }
        }
    }