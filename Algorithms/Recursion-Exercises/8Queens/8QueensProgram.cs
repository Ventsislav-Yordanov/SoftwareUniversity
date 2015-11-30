namespace _8Queens
{
    using System;

    public class EightQueen
    {
        private const int ChessSize = 5;
        private static bool[,] chessboard = new bool[ChessSize, ChessSize];
        private static bool[] attackedCols = new bool[ChessSize];
        private static bool[] attackedLeftDiagonals = new bool[(ChessSize * 2) - 1];
        private static bool[] attackedRightDiagonals = new bool[(ChessSize * 2) - 1];
        private static int solutionsCount = 0;

        public static void Main()
        {
            PutQueen(0);
            Console.WriteLine($"Solutions count: {solutionsCount}");
        }

        private static void PutQueen(int row)
        {
            if (row == ChessSize)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < ChessSize; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueen(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        private static void PrintSolution()
        {
            for (int row = 0; row < ChessSize; row++)
            {
                for (int col = 0; col < ChessSize; col++)
                {
                    if (chessboard[row, col])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            solutionsCount++;
        }

        private static void MarkAllAttackedPositions(int row, int col)
        {
            attackedCols[col] = true;
            attackedLeftDiagonals[col - row + ChessSize - 1] = true;
            attackedRightDiagonals[col + row] = true;
            chessboard[row, col] = true;
        }

        private static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedCols[col] = false;
            attackedLeftDiagonals[col - row + ChessSize - 1] = false;
            attackedRightDiagonals[col + row] = false;
            chessboard[row, col] = false;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            var positionOccupied =
                    attackedCols[col] ||
                    attackedLeftDiagonals[col - row + ChessSize - 1] ||
                    attackedRightDiagonals[col + row];
            return !positionOccupied;
        }
    }
}
