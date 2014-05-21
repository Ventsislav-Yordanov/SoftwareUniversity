using System;

    class BatGoikoTower
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = -2;
            for (int row = 0; row < n; row++)
            {
                for (int i = 0; i <= counter; i++)
                {

                    Console.Write(new string('.', n - row - 1));
                    Console.Write("/");
                    Console.Write(new string('.', row));

                    Console.Write(new string('.', row));
                    Console.Write("\\");
                    Console.Write(new string('.', n - row - 1));
                    Console.WriteLine();

                    row++;
                    if (row == n)
                    {
                        return;
                    }
                }

                Console.Write(new string('.', n - row - 1));
                Console.Write("/");
                Console.Write(new string('-', row));

                Console.Write(new string('-', row));
                Console.Write("\\");
                Console.Write(new string('.', n - row - 1));
                Console.WriteLine();

                counter++;
            }
        }
    }