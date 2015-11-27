namespace Bridges
{
    using System;
    using System.Linq;

    public class Bridges
    {
        private const int NotFound = -1;
        private static int[] north;
        private static int[] south;
        private static int[,] MaxBridgesCount;

        public static void Main()
        {
            north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            south = Console.ReadLine().Split().Select(int.Parse).ToArray();
            MaxBridgesCount = new int[north.Length, south.Length];
            for (int row = 0; row < MaxBridgesCount.GetLength(0); row++)
            {
                for (int col = 0; col < MaxBridgesCount.GetLength(1); col++)
                {
                    MaxBridgesCount[row, col] = NotFound;
                }
            }
            int maxBridgesCount = FindMaxBridgesCount(north.Length - 1, south.Length - 1);
            Console.WriteLine(maxBridgesCount);
        }

        private static int FindMaxBridgesCount(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }
            else
            {
                if (MaxBridgesCount[x, y] != NotFound)
                {
                    return MaxBridgesCount[x, y];
                }
                else
                {
                    if (north[x] == south[y])
                    {
                        MaxBridgesCount[x, y] = 1 + Math.Max(FindMaxBridgesCount(x - 1, y), FindMaxBridgesCount(x, y - 1));
                        return MaxBridgesCount[x, y];
                    }
                    else
                    {
                        MaxBridgesCount[x, y] = Math.Max(FindMaxBridgesCount(x - 1, y), FindMaxBridgesCount(x, y - 1));
                        return MaxBridgesCount[x, y];
                    }
                }
            }
        }
    }
}
