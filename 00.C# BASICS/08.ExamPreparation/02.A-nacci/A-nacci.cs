/*condition : https://www.dropbox.com/s/7h39a0pqwxi4ets/2.%20A-nacci.doc */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            int shift = 64;

            //Console.Write("Enter first member : ");
            string firstMember = Console.ReadLine();
            int first = firstMember[0] - shift; // (int)'A' = 65    first = 65-64 = 1

            //Console.Write("Enter second member : ");
            string secondMember = Console.ReadLine();
            int second = secondMember[0] - shift; // (int)'B' = 66  second = 66 - 64 = 2

            //Console.Write("Enter rows : ");
            int rowsNumber = Int32.Parse(Console.ReadLine());

            //Console.WriteLine();

            Console.WriteLine((char)(first + shift));
            if (rowsNumber  > 1)
            {
                int next = first + second;

                if (next > 26)
                {
                    next = next % 26;
                }

                string result = ((char)(second + shift)).ToString() + ((char)(next + shift)).ToString();
                Console.WriteLine(result);
                first = second;
                second = next;


                for (int i = 3; i <= rowsNumber; i++)
                {
                    next = first + second;
                    if (next > 26)
                    {
                        next = next % 26;
                    }

                    first = second;
                    second = next;

                    next = first + second;
                    if (next > 26)
                    {
                        next = next % 26;
                    }

                    first = second;
                    second = next;
                    Console.Write((char)(first + shift));
                    Console.Write(new string(' ', i - 2));
                    Console.WriteLine((char)(second + shift));
                }
            }
        }
    }