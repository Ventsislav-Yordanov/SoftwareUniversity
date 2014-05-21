using System;
using System.Text;

class TelerikLogo
{
    static void Main()
    {
        int X = int.Parse(Console.ReadLine());
        int Y = X;
        int Z = (X + 1) / 2;

        int Width = 3 * X - 2;

        for (int i = 0; i < 2 * X - 2; i++)
        {
            StringBuilder line = new StringBuilder(new string('.', Width));

            if (Z - 1 - i >= 0)
            {
                line[Z - 1 - i] = '*';
            }
            line[Z - 1 + i] = '*';

            line[Width - Z - i] = '*';
            if (Width - Z + i < Width)
            {
                line[Width - Z + i] = '*';
            }

            Console.WriteLine(line);
        }

        for (int i = 0; i < X; i++)
        {
            StringBuilder line = new StringBuilder(new string('.', Width));
            line[Z - 1 + i] = '*';
            line[Width - Z - i] = '*';
            Console.WriteLine(line);
        }
    }
}