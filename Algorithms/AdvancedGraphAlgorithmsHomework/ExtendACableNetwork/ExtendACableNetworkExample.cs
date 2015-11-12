namespace ExtendACableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendACableNetworkExample
    {
        private static List<Edge> edges = new List<Edge>();

        public static void Main()
        {
            // Parse info from console
            int budget = int.Parse(Console.ReadLine().Split(' ')[1]);
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeInfoParts = Console.ReadLine().Split(' ');
                // Is connected edge
                if (edgeInfoParts.Length > 3)
                {
                    edges.Add(new Edge(edgeInfoParts[0], edgeInfoParts[1], int.Parse(edgeInfoParts[2]), true));
                }
                else
                {
                    edges.Add(new Edge(edgeInfoParts[0], edgeInfoParts[1], int.Parse(edgeInfoParts[2]), false));
                }
            }

            var currentEdges = edges.Where(e => e.IsConnected).ToList();
            var remainingEdges = edges.Where(e => !e.IsConnected).ToList();

            var graph = BuildGraph();
            var spanningTreeNodes = new HashSet<string>();
            foreach (var edge in currentEdges)
            {
                spanningTreeNodes.Add(edge.StartNode);
                spanningTreeNodes.Add(edge.EndNode);
            }

            var spanningTreeEdges = new List<Edge>(currentEdges);

            Prim(graph, spanningTreeNodes, spanningTreeEdges, remainingEdges, budget);

            var newEdges = spanningTreeEdges.Except(currentEdges);
            foreach (var edge in newEdges)
            {
                Console.WriteLine(edge);
            }

            Console.WriteLine("Budget used: {0}", newEdges.Sum(e => e.Weight));
        }

        private static void Prim(
            Dictionary<string, List<Edge>> graph,
            HashSet<string> spanningTreeNodes,
            List<Edge> spanningTreeEdges,
            List<Edge> remainingEdges,
            int budget)
        {
            // Append the startNode child edges to the priority queue
            var priorityQueue = new BinaryHeap<Edge>();
            foreach (var childEdge in remainingEdges)
            {
                priorityQueue.Enqueue(childEdge);
            }

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (budget >= smallestEdge.Weight &&
                    (spanningTreeNodes.Contains(smallestEdge.StartNode) ^ spanningTreeNodes.Contains(smallestEdge.EndNode)))
                {
                    // Attach the smallest edge to the minimum spanning tree (MST)
                    spanningTreeEdges.Add(smallestEdge);
                    var nonTreeNode = spanningTreeNodes.Contains(smallestEdge.StartNode) ?
                        smallestEdge.EndNode : smallestEdge.StartNode;
                    spanningTreeNodes.Add(nonTreeNode);
                    budget -= smallestEdge.Weight;

                    foreach (var childEdge in graph[nonTreeNode])
                    {
                        if (budget >= childEdge.Weight)
                        {
                            priorityQueue.Enqueue(childEdge);
                        }
                    }
                }
            }
        }

        static Dictionary<string, List<Edge>> BuildGraph()
        {
            var graph = new Dictionary<string, List<Edge>>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge.StartNode))
                {
                    graph.Add(edge.StartNode, new List<Edge>());
                }
                graph[edge.StartNode].Add(edge);
                if (!graph.ContainsKey(edge.EndNode))
                {
                    graph.Add(edge.EndNode, new List<Edge>());
                }
                graph[edge.EndNode].Add(edge);
            }

            return graph;
        }
    }
}