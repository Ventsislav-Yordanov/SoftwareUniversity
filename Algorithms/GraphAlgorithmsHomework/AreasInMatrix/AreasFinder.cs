namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class AreasFinder
    {
        private static char[][] matrix;
        private static bool[,] visited;

        public static void Main()
        {
            var numberOfRowsInfo = Console.ReadLine().Split(':');
            int numberOfRows = int.Parse(numberOfRowsInfo[1]);
            matrix = new char[numberOfRows][];
            for (int i = 0; i < numberOfRows; i++)
            {
                string line = Console.ReadLine();
                matrix[i] = line.ToCharArray();
            }

            visited = new bool[matrix.Length, matrix[0].Length];
            var result = new SortedDictionary<char, int>();
            int areasCount = 0;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (!visited[row, col])
                    {
                        areasCount++;
                        if (!result.ContainsKey(matrix[row][col]))
                        {
                            result.Add(matrix[row][col], 1);
                        }
                        else
                        {
                            result[matrix[row][col]]++;
                        }

                        FindConnectedArea(row, col, matrix[row][col]);
                    }
                }
            }
            Console.WriteLine(string.Format("Areas: {0}", areasCount));
            foreach (var area in result)
            {
                Console.WriteLine(string.Format("Letter '{0}' -> {1}", area.Key, area.Value));
            }
        }

        private static void FindConnectedArea(int row, int col, char character)
        {
            if (!IsInMatrix(row, col))
            {
                return;
            }

            if (visited[row, col] || matrix[row][col] != character)
            {
                return;
            }

            visited[row, col] = true;

            FindConnectedArea(row + 1, col, character); // up
            FindConnectedArea(row - 1, col, character); // down
            FindConnectedArea(row, col + 1, character); // right
            FindConnectedArea(row, col - 1, character); // left
        }

        private static bool IsInMatrix(int row, int col)
        {
            if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[0].Length)
            {
                return true;
            }

            return false;
        }
    }
}
