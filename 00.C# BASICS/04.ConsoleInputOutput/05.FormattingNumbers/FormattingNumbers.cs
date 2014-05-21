/*Write a program that reads 3 numbers: an integer a (0 ≤ a ≤ 500),
 * a floating-point b and a floating-point c and prints them in 4 virtual columns on the console.
 * Each column should have a width of 10 characters. The number a should be printed in hexadecimal,
 * left aligned; then the number a should be printed in binary form,
 * padded with zeroes, then the number b should be printed with 2 digits after the decimal point,
 * right aligned; the number c should be printed with 3 digits after the decimal point, left aligned. */
using System;

class FormattingNumbers
{
    static void Main()
    {
        Console.Write("Enter number A : ");
        int a = int.Parse(Console.ReadLine());

        if (a >= 0 && a <= 500)
        {
            Console.Write("Enter number B : ");
            float b = float.Parse(Console.ReadLine());
            Console.Write("Enter number C : ");
            float c = float.Parse(Console.ReadLine());

            string inHex = a.ToString("x");
            string inBin = Convert.ToString(a, 2);

            Console.WriteLine("|{0,-10}|{1,10:F10}|{2,10:F2}|{3,-10:F3}"
                              , inHex, inBin.PadLeft(10, '0'), Math.Round(b, 2), Math.Round(c, 3));
        }
        else
        {
            Console.WriteLine("Number A need to be in interval : (0 ≤ A ≤ 500)");
        }
    }
}