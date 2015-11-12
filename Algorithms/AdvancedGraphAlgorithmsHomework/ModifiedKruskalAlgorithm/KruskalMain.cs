namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KruskalMain
    {
        private static List<Edge> edges = new List<Edge>();

        public static void Main()
        {
            // Parse info from console
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeInfoParts = Console.ReadLine().Split(' ');
                edges.Add(new Edge(int.Parse(edgeInfoParts[0]), int.Parse(edgeInfoParts[1]), int.Parse(edgeInfoParts[2])));
            }

            var minimumSpanningForest = KruskalAlgorithm.Kruskal(nodesCount, edges);
            Console.WriteLine("Minimum spanning forest weight: " + minimumSpanningForest.Sum(e => e.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }
    }
}
