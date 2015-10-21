namespace MoveDownRightSum
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int[,] matrix =
            {
                { 2, 6, 1, 8, 9, 4, 2 },
                { 1, 8, 0, 3, 5, 6, 7 },
                { 3, 4, 8, 7, 2, 1, 8 },
                { 0, 9, 2, 8, 1, 7, 9 },
                { 2, 7, 1, 9, 7, 8, 2 },
                { 4, 5, 6, 1, 2, 5, 6 },
                { 9, 3, 5, 2, 8, 1, 9 },
                { 2, 3, 4, 1, 7, 2, 8 }
            };

            int[,] sums = new int[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int topCell = 0;
                    int leftCell = 0;
                    if (row > 0)
                    {
                        topCell = sums[row - 1, col];
                    }

                    if (col > 0)
                    {
                        leftCell = sums[row, col - 1];
                    }

                    int currentCell = matrix[row, col];
                    sums[row, col] = currentCell + Math.Max(topCell, leftCell);
                }
            }
        }
    }
}
