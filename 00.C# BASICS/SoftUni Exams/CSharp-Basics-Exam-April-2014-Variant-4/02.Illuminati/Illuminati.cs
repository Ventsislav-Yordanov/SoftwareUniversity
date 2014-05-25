using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Illuminati
{
    static void Main()
    {
        string input = Console.ReadLine();

        int counter = 0;
        int totalsum = 0;

        foreach (var letter in input)
        {
            if (letter == 'A' | letter == 'a')
            {
                totalsum += 65;
                counter++;
            }
            else if (letter == 'E' | letter == 'e')
            {
                totalsum += 69;
                counter++;
            }
            else if (letter == 'I' | letter == 'i')
            {
                totalsum += 73;
                counter++;
            }
            else if (letter == 'O' | letter == 'o')
            {
                totalsum += 79;
                counter++;
            }
            else if (letter == 'U' | letter == 'u')
            {
                totalsum += 85;
                counter++;
            }
        }

        Console.WriteLine(counter);
        Console.WriteLine(totalsum);
    }
}