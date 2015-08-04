namespace Escape_from_Labyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EscapeFromLabyrinth
    {
        private const char VisitedCell = 's';
        private static int width;
        private static int height;
        private static char[,] labyrinth;

        public static void Main()
        {
            ReadLabyrinth();

            string shortestPathToExit = FindShortestPathToExit();
            if (shortestPathToExit == null)
            {
                Console.WriteLine("No exit!");
            }
            else if (shortestPathToExit == "")
            {
                Console.WriteLine("Start is at the exit.");
            }
            else
            {
                Console.WriteLine("Shortest exit: {0}", shortestPathToExit);
            }
        }

        public static string FindShortestPathToExit()
        {
            var queue = new Queue<Point>();
            var startPostion = FindStartPosition();
            if (startPostion == null)
            {
                // no start postion => no exit
                return null;
            }

            queue.Enqueue(startPostion);
            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                //Console.WriteLine("Visited cell: ({0}, {1})", currentCell.X, currentCell.Y);
                if (IsExit(currentCell))
                {
                    return TracePathBack(currentCell);
                }

                TryDirection(queue, currentCell, "U", 0, -1);
                TryDirection(queue, currentCell, "R", +1, 0);
                TryDirection(queue, currentCell, "D", 0, +1);
                TryDirection(queue, currentCell, "L", -1, 0);
            }

            return null;
        }

        private static Point FindStartPosition()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (labyrinth[y, x] == VisitedCell) // y = col, x = row
                    {
                        return new Point() { X = x, Y = y };
                    }
                }
            }

            return null;
        }

        private static bool IsExit(Point cell)
        {
            bool isOnBorderX = cell.X == 0 || cell.X == width - 1;
            bool isOnBorderY = cell.Y == 0 || cell.Y == height - 1;
            return isOnBorderX || isOnBorderY;
        }

        private static void TryDirection(Queue<Point> queue, Point cell, string direction, int deltaX, int deltaY)
        {
            int newX = cell.X + deltaX;
            int newY = cell.Y + deltaY;
            if (newX >= 0 && newX < width && newY >= 0 && newY < height && labyrinth[newY, newX] == '-')
            {
                labyrinth[newY, newX] = VisitedCell;
                var nextCell = new Point()
                {
                    X = newX,
                    Y = newY,
                    Direction = direction,
                    PreviousPoint = cell
                };
                queue.Enqueue(nextCell);
            }
        }

        private static string TracePathBack(Point cell)
        {
            var path = new StringBuilder();
            while (cell.PreviousPoint != null)
            {
                path.Append(cell.Direction);
                cell = cell.PreviousPoint;
            }

            var pathReversed = new StringBuilder(path.Length);
            for (int i = path.Length - 1; i >= 0; i--)
            {
                pathReversed.Append(path[i]);
            }

            return pathReversed.ToString();
        }

        private static void ReadLabyrinth()
        {
            width = int.Parse(Console.ReadLine());
            height = int.Parse(Console.ReadLine());
            labyrinth = new char[height, width];
            for (int row = 0; row < height; row++)
            {
                var lineString = Console.ReadLine();
                var characters = lineString.ToCharArray();
                for (int col = 0; col < characters.Length; col++)
                {
                    labyrinth[row, col] = characters[col];
                }
            }
        }
    }
}
