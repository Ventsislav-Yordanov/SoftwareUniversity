/*Write a program to find the longest area of equal elements in array of strings.
 * You first should read an integer n and n strings (each at a separate line),
 * then find and print the longest sequence of equal elements (first its length, then its elements).
 * If multiple sequences have the same maximal length, print the leftmost of them.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class LongestAreaInArray
    {
        static void Main()
        {
            Console.Write("Array lenght :");
            int arrayLenght = Int32.Parse(Console.ReadLine());

            //create array for words
            string[] words = new string[arrayLenght]; 

            // enter words
            for (int i = 0; i < words.Length; i++) 
            {
                Console.Write("Array element #{0} = ");
                string arrayElement = Console.ReadLine();
                words[i] = arrayElement; // add current word in array at index i
            }

            int startIndex = 0;
            int lenghtCount = 1;
            int currentCount = 1;


            for (int i = 0; i < words.Length - 1; i++) // words.Length - 1 beacuse compare with the next
            {
                if (words[i] == words[i+1])
                {
                    currentCount++;

                    if (currentCount > lenghtCount)
                    {
                        lenghtCount = currentCount;
                        startIndex = (i + 1) - (lenghtCount - 1);
                    }
                }
                else
                {
                    currentCount = 1;
                }
            }

            Console.WriteLine("Lenght : {0}",lenghtCount);

            for (int i = 0; i < lenghtCount; i++)
            {
                Console.WriteLine(words[startIndex + i]);
            }
        }
    }