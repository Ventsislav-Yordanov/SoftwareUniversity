/*Write a program that converts a number in the range [0…999] to words,
 * corresponding to the English pronunciation. */
using System;

    class NumberAsWords
    {
        static void Main()
        {                                                 // example :
            int number = Int32.Parse(Console.ReadLine()); // 915
            int number0to20 = number % 100;               // 15
            int units = number % 10;                      // 5
            int tens = (number / 10) % 10;                // 1
            int hundreds = (number / 100) % 10;           // 9

            string result = "";

            string[] unitsAsWods = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                            "eleven", "twelve", "thirteen", "fourten", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
            string[] tensAsWords = { "", "", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] hundredsAsWords = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


            if (units == 0 && tens == 0 && hundreds == 0)
            {
                Console.WriteLine("zero");
                return;
            }

            string and = "";
            if (hundreds > 0 && number0to20 > 0)
            {
                and = " and ";
            }

            if (number0to20 < 20)
            {
                result = string.Format("{0}{1}{2}{3}", hundredsAsWords[hundreds], hundreds == 0 ? "" : " hundred", and, unitsAsWods[number0to20]);
            }
            else
            {
                result = string.Format("{0}{1}{2}{3} {4}", hundredsAsWords[hundreds], hundreds == 0 ? "" : " hundred",
                               and, tensAsWords[tens], unitsAsWods[units]);
            }

            Console.WriteLine(result);
        }
    }