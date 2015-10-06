namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;

    // TODO: start cell maybe can be different from (0, 0)
    public class PathsBetweenCellsInMatrixProgram
    {
        // example path 1
        //static char[,] labyrinth =
        //{
        //    {' ', ' ', ' ', ' '},
        //    {' ', '*', '*', ' '},
        //    {' ', '*', '*', ' '},
        //    {' ', '*', 'e', ' '},
        //    {' ', ' ', ' ', ' '},
        //};

        // example path 2
        static char[,] labyrinth =
        {
            {' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', '*', ' ', '*', ' '},
            {' ', '*', 'e', ' ', ' ', ' '},
            {' ', ' ', ' ', '*', ' ', ' '},
        };

        static List<char> path = new List<char>();
        static int PathsCount = 0;
        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < labyrinth.GetLength(0);
            bool colInRange = col >= 0 && col < labyrinth.GetLength(1);
            return rowInRange && colInRange;
        }

        static void FindPathToExit(int row, int col, char direction)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a path
                return;
            }

            // Check if we have found the exit
            if (labyrinth[row, col] == 'e')
            {
                PathsCount++;
                Console.WriteLine(string.Join("", path) + direction);
                return;
            }

            if (labyrinth[row, col] != ' ')
            {
                // The current cell is not free -> can't find a path
                return;
            }

            // Temporary mark the current cell as visited to avoid cycles
            labyrinth[row, col] = 's';
            if (direction != 'S')
            {
                path.Add(direction);
            }

            // Invoke recursion to explore all possible directions
            FindPathToExit(row, col - 1, 'L'); // left
            FindPathToExit(row - 1, col, 'U'); // up
            FindPathToExit(row, col + 1, 'R'); // right
            FindPathToExit(row + 1, col, 'D'); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            labyrinth[row, col] = ' ';
            if ((path.Count - 1) >= 0)
            {
                path.RemoveAt(path.Count - 1); // Remove last
            }
        }

        static void Main()
        {
            FindPathToExit(0, 0, 'S');
            Console.WriteLine("Total paths found: {0}", PathsCount);
        }
    }
}
