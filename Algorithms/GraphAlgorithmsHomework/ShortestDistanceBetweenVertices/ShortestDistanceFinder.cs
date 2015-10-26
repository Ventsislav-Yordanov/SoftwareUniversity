namespace ShortestDistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Pair = System.Collections.Generic.KeyValuePair<int, int>; // I am a master ;)

    public class ShortestDistanceFinder
    {
        public static void Main()
        {
            // Note: Add an empty line when testing after you have written all input
            var nodes = new Dictionary<int, Node<int>>();
            Console.ReadLine();
            string line = Console.ReadLine();
            while (line != "Distances to find:")
            {
                var lineParts = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                if (lineParts.Length > 1)
                {
                    int currentNode = int.Parse(lineParts[0]);
                    var neighbours = lineParts[1]
                        .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    foreach (var neighbour in neighbours)
                    {
                        if (!nodes.ContainsKey(currentNode))
                        {
                            nodes[currentNode] = new Node<int>(currentNode);
                        }

                        if (!nodes.ContainsKey(neighbour))
                        {
                            nodes[neighbour] = new Node<int>(neighbour);
                        }

                        nodes[currentNode].Neighbours.Add(nodes[neighbour]);
                    }
                }

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            var distancesToFind = new List<Pair>();
            while (!string.IsNullOrEmpty(line))
            {
                var pair = line.Split('-').Select(int.Parse).ToList();
                distancesToFind.Add(new Pair(pair[0], pair[1]));
                line = Console.ReadLine();
            }

            foreach (var pair in distancesToFind)
            {
                int result = FindShortestDistanceBetweenVertices(nodes, pair.Key, pair.Value);
                Console.WriteLine("{{{0}, {1}}} -> {2}", pair.Key, pair.Value, result);
            }
        }

        public static int FindShortestDistanceBetweenVertices(Dictionary<int, Node<int>> nodes, int startNode, int endNode)
        {
            var queue = new Queue<Node<int>>();
            var visitedNodes = new HashSet<int>();
            var distances = new Dictionary<Node<int>, int>();

            // Enqueue the start node to the queue
            visitedNodes.Add(startNode);
            queue.Enqueue(nodes[startNode]);
            distances[nodes[startNode]] = 0;

            // Breadth-First Search (BFS)
            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Value == endNode)
                {
                    return distances[currentNode];
                }

                foreach (var neighbourNode in currentNode.Neighbours)
                {
                    if (!visitedNodes.Contains(neighbourNode.Value))
                    {
                        queue.Enqueue(neighbourNode);
                        visitedNodes.Add(neighbourNode.Value);
                        distances[neighbourNode] = distances[currentNode] + 1;
                    }
                }
            }

            return -1;
        }
    };
}
