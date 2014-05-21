/* Condition : https://www.dropbox.com/s/7kp63mpacr7603r/1.%20Sevenland%20Numbers.docx */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class SevenlandNumbers
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int inputNumber = Int32.Parse(input);
            byte powerCounter = 0; // за степените
            int decimalNumber = 0; // числото в десеттична бройна система

            while (inputNumber != 0)
            {
                byte lastnumber = (byte)(inputNumber % 10);
                decimalNumber += lastnumber * (int)Math.Pow(7, powerCounter);
                powerCounter++;
                inputNumber /= 10;
            }

            decimalNumber++; //The output should consist of a single line holding the number K+1 
                             //(in 7-based numeral system).

            string result = "";

            while (decimalNumber != 0)
            {
                byte lastNumber = (byte)(decimalNumber % 7);
                result = lastNumber + result;
                decimalNumber /= 7;
            }

            Console.WriteLine(result);
        }
    }