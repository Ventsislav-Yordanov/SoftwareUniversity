namespace MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostReliablePathExample
    {
        static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine().Split(' ')[1]);
            char[] delimiters = new char[] { '-', ':' };
            string[] pathInfo = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int startNode = int.Parse(pathInfo[1]);
            int endNode = int.Parse(pathInfo[2]);
            int edgesCount = int.Parse(Console.ReadLine().Split(' ')[1]);

            var nodes = new Node[nodesCount];
            for (int i = 0; i < nodesCount; i++)
            {
                nodes[i] = new Node(i);
            }

            var graph = new Dictionary<Node, List<Edge>>();
            for (int i = 0; i < edgesCount; i++)
            {
                int[] edgeInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var currentStartNode = nodes[edgeInfo[0]];
                if (!graph.ContainsKey(currentStartNode))
                {
                    graph[currentStartNode] = new List<Edge>();
                }

                var currentEndNode = nodes[edgeInfo[1]];
                if (!graph.ContainsKey(currentEndNode))
                {
                    graph[currentEndNode] = new List<Edge>();
                }

                graph[currentStartNode].Add(new Edge(currentEndNode, (edgeInfo[2] * 1.00) / 100));
                graph[currentEndNode].Add(new Edge(currentStartNode, (edgeInfo[2] * 1.00) / 100));
            }

            var sourceNode = nodes[startNode];
            FindMostReliablePathDijkstra(graph, sourceNode);
            var target = nodes[endNode];
            double distance = target.Distance;
            if (double.IsNegativeInfinity(distance))
            {
                Console.WriteLine("No path.");
            }
            else
            {
                var path = FindPath(graph, target);
                Console.WriteLine("Most reliable path reliability: {0:F2}%", distance * 100);
                string pathString = string.Join(" -> ", path.Select(p => p.Id));
                Console.WriteLine(pathString);
            }
        }

        public static void FindMostReliablePathDijkstra(Dictionary<Node, List<Edge>> graph, Node sourceNode)
        {
            var queue = new PriorityQueue<Node>();
            foreach (var node in graph)
            {
                node.Key.Distance = double.NegativeInfinity;
            }

            sourceNode.Distance = 1.0d;
            queue.Enqueue(sourceNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsNegativeInfinity(currentNode.Distance))
                {
                    // All nodes processed --> algorithm finished
                    break;
                }

                foreach (var childEdge in graph[currentNode])
                {
                    var newDistance = currentNode.Distance * childEdge.Distance;
                    if (newDistance > childEdge.Node.Distance)
                    {
                        childEdge.Node.Distance = newDistance;
                        childEdge.Node.PreviousNode = currentNode;
                        queue.Enqueue(childEdge.Node);
                    }
                }
            }
        }

        private static List<Node> FindPath(Dictionary<Node, List<Edge>> graph, Node endNode)
        {
            var path = new List<Node>();
            while (endNode != null)
            {
                path.Add(endNode);
                endNode = endNode.PreviousNode;
            }

            path.Reverse();

            return path;
        }
    }
}
