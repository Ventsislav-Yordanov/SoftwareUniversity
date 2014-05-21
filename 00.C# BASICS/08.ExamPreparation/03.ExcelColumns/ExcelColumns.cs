/*Condition : https://www.dropbox.com/s/zarb2ikd6qaptcu/3.%20Excel%20Columns.doc */
using System;

    class ExcelColumns
    {
        static void Main()
        {
            string str = "";
            int n = Int32.Parse(Console.ReadLine());
            long number = 0;

            for (int i = 0; i < n; i++)
            {
                str += Console.ReadLine();
            }

            for (int i = 0; i < str.Length; i++)
            {
                number *= 26;
                number += (str[i] - 'A' + 1);
            }
            Console.WriteLine(number);
        }
    }
