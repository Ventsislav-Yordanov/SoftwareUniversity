using System;

    class SandGlass
    {
        static void Main()
        {
            int n = Int32.Parse(Console.ReadLine());

            for (int i = 0; i <= n / 2; i++)
            {
                string dots = new string('.', i);
                string stars = new string('*', n - 2 * i);
                Console.WriteLine("{0}{1}{0}", dots, stars);
            }

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                string dots = new string('.', i);
                string stars = new string('*', n - 2 * i);
                Console.WriteLine("{0}{1}{0}", dots, stars);
            }
        }
    }