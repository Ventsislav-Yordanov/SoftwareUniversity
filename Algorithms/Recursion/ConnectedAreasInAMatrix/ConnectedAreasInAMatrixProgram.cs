namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectedAreasInAMatrixProgram
    {
        // input example 1
        static char[,] matrix =
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' ','*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' ','*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' ','*', ' '},
            {' ', ' ', ' ', ' ', '*', ' ', '*',' ', ' '},
        };

        // input example 2
        //static char[,] matrix =
        //{
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ','*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ','*', ' ', ' '},
        //    {'*', ' ', ' ', '*', '*', '*', '*','*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ','*', ' ', ' '},
        //    {'*', ' ', ' ', '*', ' ', ' ', ' ','*', ' ', ' '}
        //};

        private static SortedSet<Area> areas = new SortedSet<Area>();
        private static int areaSize;

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }

        private static void FindAreas()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        MarkAreaCells(row, col);
                        var newArea = new Area(row, col, areaSize);
                        areas.Add(newArea);
                        areaSize = 0;
                    }
                }
            }
        }

        private static void MarkAreaCells(int row, int col)
        {
            if (!InRange(row, col))
            {
                // We are out of the labyrinth -> can't find a area
                return;
            }

            if (matrix[row, col] != ' ')
            {
                // The current cell is not free
                return;
            }

            // Mark the current cell as visited and increment current area size
            areaSize++;
            matrix[row, col] = '#';

            // Invoke recursion to explore all possible directions
            MarkAreaCells(row, col + 1); // right
            MarkAreaCells(row, col - 1); // left
            MarkAreaCells(row + 1, col); // down
            MarkAreaCells(row - 1, col); // up
        }

        private static void PrintAllAreasInfo()
        {
            if (areas.Any())
            {
                int counter = 1;
                foreach (var area in areas)
                {
                    Console.WriteLine("Area #{0} at ({1}, {2}), size: {3}", counter, area.Row, area.Col, area.Size);
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("There is no areas.");
            }
        }

        public static void Main()
        {
            FindAreas();
            PrintAllAreasInfo();
        }
    }
}
