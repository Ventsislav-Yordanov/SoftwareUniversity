using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterNumbers
{
    public class EnterNumbersClass
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int counter = 0;

            Console.WriteLine("Please enter 10 numbers :");
            while (counter < 10)
            {
                try
                {
                    int currentNumber = ReadNumbers(start, end);
                    if (currentNumber > start)
                    {
                        start = currentNumber;
                    }
                    counter++;
                }
                catch (ArgumentException argumentException)
                {
                    Console.Error.WriteLine("{0} Repeat input!", argumentException.Message);

                }
                catch (Exception exception)
                {
                    Console.Error.WriteLine("{0} Repeat input!", exception.Message);
                }
            }
        }

        public static int ReadNumbers(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number <= start || number > end)
            {
                throw new IndexOutOfRangeException("The number is outside of the requested range!");
            }
            return number;
        }
    }
}
