using System;

    class ForestRoad
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int star = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == star)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
                star++;
            }

            star -= 2;

            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (col == star)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
                star--;
            }
        }
    }