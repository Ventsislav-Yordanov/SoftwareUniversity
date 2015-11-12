namespace ShortestPathsWithNegativeEdges
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            char[] delimiters = new char[] { '-', ':' };
            string[] pathInfo = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int startNode = int.Parse(pathInfo[1]);
            int endNode = int.Parse(pathInfo[2]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            var distance = new double[nodesCount];
            var predecessor = new int[nodesCount];

            // TODO
        }
    }
}
