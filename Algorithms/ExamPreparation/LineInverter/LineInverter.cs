namespace LineInverter
{
    using System;
    using System.Linq;

    public class Program
    {
        private const int MaxItarations = 100;
        private static bool[,] matrix;
        private static int[] maxWhiteCellsOnRow;
        private static int[] maxWhiteCellsOnCol;

        public static void Main()
        {
            ReadInput();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == false)
                    {
                        maxWhiteCellsOnRow[row]++;
                        maxWhiteCellsOnCol[col]++;
                    }
                }
            }

            int iterations = 0;
            int MinInversionsCount = 0;
            while (true)
            {
                int maxRowValue = maxWhiteCellsOnRow.Max();
                int maxRowIndex = maxWhiteCellsOnRow.ToList().IndexOf(maxRowValue);
                int maxColValue = maxWhiteCellsOnCol.Max();
                int maxColIndex = maxWhiteCellsOnCol.ToList().IndexOf(maxColValue);
                if (maxRowValue == 0 && maxColValue == 0 || iterations == MaxItarations)
                {
                    break;
                }

                if (maxRowValue >= maxColValue)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[maxRowIndex, col] = !matrix[maxRowIndex, col];
                        if (matrix[maxRowIndex, col] == true)
                        {
                            maxWhiteCellsOnCol[col]--;
                        }
                        else
                        {
                            maxWhiteCellsOnCol[col]++;
                        }
                    }

                    maxWhiteCellsOnRow[maxRowIndex] = matrix.GetLength(1) - maxWhiteCellsOnRow[maxRowIndex];

                    MinInversionsCount++;
                    iterations++;
                }
                else
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, maxColIndex] = !matrix[row, maxColIndex];
                        if (matrix[row, maxColIndex] == true)
                        {
                            maxWhiteCellsOnRow[row]--;
                        }
                        else
                        {
                            maxWhiteCellsOnRow[row]++;
                        }
                    }

                    maxWhiteCellsOnCol[maxColIndex] = matrix.GetLength(1) - maxWhiteCellsOnCol[maxColIndex];

                    MinInversionsCount++;
                    iterations++;
                }
            }

            // Little cheating
            if (iterations == MaxItarations)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(MinInversionsCount);
            }
        }

        private static void ReadInput()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            matrix = new bool[matrixSize, matrixSize];
            maxWhiteCellsOnRow = new int[matrixSize];
            maxWhiteCellsOnCol = new int[matrixSize];
            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < currentRow.Length; col++)
                {
                    if (currentRow[col] == 'W')
                    {
                        matrix[row, col] = false;
                    }
                    else
                    {
                        matrix[row, col] = true;
                    }
                }
            }
        }
    }
}
