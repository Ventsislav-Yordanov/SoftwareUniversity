namespace Zigzag_Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ZigzagMatrix
    {
        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfColumns = int.Parse(Console.ReadLine());

            int[][] matrix = new int[numberOfRows][];
            ReadMatrix(numberOfRows, matrix);

            var maxPaths = new int[numberOfRows, numberOfColumns];
            var previousRowIndex = new int[numberOfRows, numberOfColumns];
            // Initialize first column
            for (int row = 1; row < numberOfRows; row++)
            {
                maxPaths[row, 0] = matrix[row][0];
            }

            // Fill max paths
            for (int col = 1; col < numberOfColumns; col++)
            {
                for (int row = 0; row < numberOfRows; row++)
                {
                    int previousMax = 0;

                    // On odd columns we check cells below and one column to the left
                    if (col % 2 != 0)
                    {
                        for (int i = row + 1; i < numberOfRows; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                // Update previousMax and maxPaths
                                previousMax = maxPaths[i, col - 1];
                                maxPaths[row, col] = previousMax + matrix[row][col];
                                // Mark the best path to cell in the previousRowIndex matrix
                                previousRowIndex[row, col] = i;
                            }
                        }
                    }
                    else // on even columns we check cells above and one column to the left
                    {
                        for (int i = 0; i <= row - 1; i++)
                        {
                            if (maxPaths[i, col - 1] > previousMax)
                            {
                                // Update previousMax and maxPaths
                                previousMax = maxPaths[i, col - 1];
                                maxPaths[row, col] = previousMax + matrix[row][col];
                                // Mark the best path to cell in the previousRowIndex matrix
                                previousRowIndex[row, col] = i;
                            }
                        }
                    }

                }
            }

            int currentRowIndex = GetLastRowIndexOfPath(maxPaths, numberOfColumns);
            var path = RecoverMaxPath(numberOfColumns, matrix, currentRowIndex, previousRowIndex);
            Console.WriteLine($"{path.Sum()} = {string.Join(" + ", path)}");
        }

        private static void ReadMatrix(int numberOfRows, int[][] matrix)
        {
            for (int i = 0; i < numberOfRows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        private static int GetLastRowIndexOfPath(int[,] maxPaths, int numberOfColumns)
        {
            int currentRowIndex = -1;
            int globalMax = 0;
            for (int row = 0; row < maxPaths.GetLength(0); row++)
            {
                if (maxPaths[row, numberOfColumns - 1] > globalMax)
                {
                    globalMax = maxPaths[row, numberOfColumns - 1];
                    currentRowIndex = row;
                }
            }

            return currentRowIndex;
        }

        private static List<int> RecoverMaxPath(
            int numberOfColumns,
            int[][] matrix,
            int rowIndex,
            int[,] previousRowIndex)
        {
            var path = new List<int>();
            int columnIndex = numberOfColumns - 1;
            while (columnIndex >= 0)
            {
                // Add cell to path (found at rowIndex)
                path.Add(matrix[rowIndex][columnIndex]);
                // Update rowIndex using the info int previousIndex
                rowIndex = previousRowIndex[rowIndex, columnIndex];
                columnIndex--;
            }

            path.Reverse();

            return path;
        }
    }
}