/*Write a program that reads a number n and a sequence of n integers, sorts them and prints them.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class SortingNumbers
    {
        static void Main()
        {
            Console.Write("Enter number of integers : ");
            int numbersCount = Int32.Parse(Console.ReadLine());
            int[] numbersArray = FillArray(numbersCount);

            Console.WriteLine();

            Console.WriteLine("Sort array : ");
            foreach (var number in numbersArray)
            {
                Console.WriteLine(number);
            }
        }

        static int[] FillArray (int inputCount)
        {
            int[] numbers = new int[inputCount];

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter number#{0} : ",i);
                numbers[i] = Int32.Parse(Console.ReadLine());
            }

            Array.Sort(numbers);
            return numbers;
        }
    }