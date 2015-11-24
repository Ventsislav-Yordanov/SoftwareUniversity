namespace ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestPathInMatrixExample
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfCols = int.Parse(Console.ReadLine());
            var matrix = new Cell[numberOfRows, numberOfCols];
            var graph = new Cell[numberOfRows * numberOfCols];
            FillTheMatrix(matrix);
            BuildTheGraph(matrix, graph);

            var queue = new PriorityQueue<Cell>();
            graph[0].IsVisited = true;
            queue.Enqueue(graph[0]);

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                foreach (var neighbour in currentCell.Neighbours)
                {
                    var newValue = currentCell.Value + neighbour.InitialValue;
                    if (!neighbour.IsVisited)
                    {
                        neighbour.Value = newValue;
                        neighbour.IsVisited = true;
                        neighbour.Prevous = currentCell;
                        queue.Enqueue(neighbour);
                    }
                    else
                    {
                        if (newValue <= neighbour.Value)
                        {
                            neighbour.Value = newValue;
                            neighbour.Prevous = currentCell;
                        }
                    }
                }
            }

            PrintShortestPath(graph);
        }

        private static void PrintShortestPath(Cell[] graph)
        {
            Console.WriteLine($"Length: {graph[graph.Length - 1].Value}");
            var path = new List<int>();
            var currentCell = graph[graph.Length - 1];
            while (currentCell != null)
            {
                var value = currentCell.InitialValue;
                path.Add(value);
                currentCell = currentCell.Prevous;
            }

            path.Reverse();

            Console.WriteLine($"Path: {string.Join(" ", path)}");
        }

        private static void BuildTheGraph(Cell[,] matrix, Cell[] graph)
        {
            int graphIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var neighbours = FindNeighbours(row, col, matrix);
                    graph[graphIndex] = matrix[row, col];
                    graph[graphIndex].Neighbours = neighbours;
                    graphIndex++;
                }
            }
        }

        private static List<Cell> FindNeighbours(int row, int col, Cell[,] matrix)
        {
            var neighbours = new List<Cell>();

            // left
            if (col - 1 >= 0)
            {
                neighbours.Add(matrix[row, col - 1]);
            }

            // righ
            if (col + 1 < matrix.GetLength(1))
            {
                neighbours.Add(matrix[row, col + 1]);
            }

            // up
            if (row - 1 >= 0)
            {
                neighbours.Add(matrix[row - 1, col]);
            }

            // down
            if (row + 1 < matrix.GetLength(0))
            {
                neighbours.Add(matrix[row + 1, col]);
            }

            return neighbours;
        }

        private static void FillTheMatrix(Cell[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentCell = new Cell(row, col, currentRow[col], currentRow[col]);
                    matrix[row, col] = currentCell;
                }
            }
        }
    }
}
