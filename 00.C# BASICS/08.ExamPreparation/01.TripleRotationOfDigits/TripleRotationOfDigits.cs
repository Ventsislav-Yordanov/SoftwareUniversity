using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        string input = Console.ReadLine();

        for (int i = 0; i < 3; i++)
        {
            char digit = input[input.Length - 1];           // gest lastdigit
            input = input.Remove(input.Length - 1);         // delete last digit 
            input = digit + input;                          // move last digit before input
            input = input.TrimStart(new Char[] { '0' });    // delete leading Zeros
        }
        Console.WriteLine(input);
    }
}