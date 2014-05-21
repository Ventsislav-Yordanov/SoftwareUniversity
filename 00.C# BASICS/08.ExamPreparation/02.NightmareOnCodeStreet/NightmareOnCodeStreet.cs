using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NightmareOnCodeStreet
{
    static void Main()
    {
        string input = Console.ReadLine();

        int count = 0;
        int sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 != 0)
            {
                switch (input[i])
                {
                    case '0':
                        sum += 0; 
                        count++; 
                        break;
                    case '1': 
                        sum += 1; 
                        count++; 
                        break;
                    case '2': 
                        sum += 2; 
                        count++; 
                        break;
                    case '3': 
                        sum += 3; 
                        count++; 
                        break;
                    case '4': 
                        sum += 4; 
                        count++; 
                        break;
                    case '5': 
                        sum += 5; 
                        count++; 
                        break;
                    case '6': 
                        sum += 6; 
                        count++; 
                        break;
                    case '7': 
                        sum += 7; 
                        count++; 
                        break;
                    case '8': 
                        sum += 8; 
                        count++; 
                        break;
                    case '9': 
                        sum += 9; 
                        count++; 
                        break;
                    //default: 
                    //    sum += 0; 
                    //    break;
                }
            }
        }
        Console.WriteLine("{0} {1}", count, sum);
    }
}