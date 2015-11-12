namespace KnightsTour
{
    using System;
    using System.Collections.Generic;

    public class KnightsTourExample
    {
        public static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            var matrix = new int[matrixSize, matrixSize];
            int matrixArea = matrixSize * matrixSize;
            var directionCells = new Cell[]
            {
                new Cell(2, 1),
                new Cell(2, -1),
                new Cell(1, 2),
                new Cell(-2, 1),
                new Cell(-2, -1),
                new Cell(1, -2),
                new Cell(-1, 2),
                new Cell(-1, -2),
            };
            int startRow = 0;
            int startCol = 0;
            int movesCount = 1;
            while (matrixArea > 0)
            {
                var possiblePostions = GetPossiblePositions(startRow, startCol, matrix, directionCells);
                var bestPosition = new Cell(startCol, startRow);
                int minMovesCount = int.MaxValue;
                foreach (var position in possiblePostions)
                {
                    int possibleMovesCount = GetPossiblePositions(position.Row, position.Col, matrix, directionCells).Count;
                    if (possibleMovesCount < minMovesCount)
                    {
                        minMovesCount = possibleMovesCount;
                        bestPosition = new Cell(position.Col, position.Row);
                    }
                }

                matrix[startRow, startCol] = movesCount;
                movesCount++;
                matrixArea--;
                startRow = bestPosition.Row;
                startCol = bestPosition.Col;
            }

            PrintMatrix(matrix);
        }

        private static List<Cell> GetPossiblePositions(int row, int col, int[,] matrix, Cell[] directionCells)
        {
            var result = new List<Cell>();
            for (int i = 0; i < directionCells.Length; i++)
            {
                var currentDirectionCell = directionCells[i];
                int currentRow = row + currentDirectionCell.Row;
                int currentCol = col + currentDirectionCell.Col;
                if (IsInRange(currentRow, currentCol, matrix.GetLength(0)) && matrix[currentRow, currentCol] == 0)
                {
                    result.Add(new Cell(currentCol, currentRow));
                }
            }

            return result;
        }

        private static bool IsInRange(int row, int col, int matrixSize)
        {
            if (row >= 0 && row < matrixSize && col >= 0 && col < matrixSize)
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string currentValue = matrix[row, col].ToString().PadLeft(4);
                    Console.Write(currentValue);
                }
                Console.WriteLine();
            }
        }
    }
}