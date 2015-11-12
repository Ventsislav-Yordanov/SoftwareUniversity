namespace ShortestPathsBetweenAllPairsOfNodes
{
    using System;
    using System.Linq;

    public class ShortestPathsBetweenAllPairsOfNodesExample
    {
        public static void Main()
        {
            // Floyd–Warshall algorithm (Source: https://en.wikipedia.org/wiki/Floyd%E2%80%93Warshall_algorithm)
            int nodesCount = int.Parse(Console.ReadLine().Split(':')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(':')[1]);
            var distances = new int[nodesCount, nodesCount];

            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    // Protect from int overflow (int.MaxValue / 2)
                    distances[i, j] = int.MaxValue / 2;
                }
            }

            for (int i = 0; i < nodesCount; i++)
            {
                distances[i, i] = 0;
            }

            for (int i = 0; i < edgesCount; i++)
            {
                int[] edgeInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                distances[edgeInfo[0], edgeInfo[1]] = edgeInfo[2];
                distances[edgeInfo[1], edgeInfo[0]] = edgeInfo[2];
            }

            for (int k = 0; k < nodesCount; k++)
            {
                for (int i = 0; i < nodesCount; i++)
                {
                    for (int j = 0; j < nodesCount; j++)
                    {
                        distances[i, j] = Math.Min(distances[i, j], distances[i, k] + distances[k, j]);
                    }
                }
            }

            // Print the output
            Console.WriteLine("Shortest paths matrix: "); 
            var matrixRangeNumbers = Enumerable.Range(0, nodesCount).Select(x => string.Format(" {0}  ", x));
            string matrixRangeNumbersString = string.Join(string.Empty, matrixRangeNumbers);
            Console.WriteLine(matrixRangeNumbersString);
            Console.WriteLine(new string('-', matrixRangeNumbersString.Length));
            for (int i = 0; i < distances.GetLength(0); i++)
            {
                for (int j = 0; j < distances.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0, 2}| ", distances[j, i]));
                }
                Console.WriteLine();
            }
        }
    }
}
