namespace RideTheHorse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RideTheHorse
    {
        private static Point[] directions = new Point[]
            {
                new Point(1, 2),
                new Point(2, 1),
                new Point(2, -1),
                new Point(1, -2),
                new Point(-1, -2),
                new Point(-2, -1),
                new Point(-2, 1),
                new Point(-1, 2),
            };

        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfCols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            var board = new int[numberOfRows, numberOfCols];
            var queue = new Queue<Point>();
            var startPoint = new Point(startCol, startRow) { Distance = 1 };
            queue.Enqueue(startPoint);

            while (queue.Count != 0)
            {
                var currentPoint = queue.Dequeue();
                board[currentPoint.Y, currentPoint.X] = currentPoint.Distance;

                var neighbours = directions.Select(d => currentPoint + d);
                foreach (var neighbour in neighbours)
                {
                    bool isInBoard = neighbour.X >= 0 && neighbour.X < numberOfCols &&
                        neighbour.Y >= 0 && neighbour.Y < numberOfRows;
                    if (isInBoard && board[neighbour.Y, neighbour.X] == 0)
                    {
                        neighbour.Distance = currentPoint.Distance + 1;
                        queue.Enqueue(neighbour);
                    }
                }
            }

            PrintBoard(board, numberOfRows, numberOfCols);
        }

        private static void PrintBoard(int[,] board, int numberOfRows, int numberOfCols)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfCols; col++)
                {
                    Console.Write("{0,3}", board[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}