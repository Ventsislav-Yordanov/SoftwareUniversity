namespace BreakCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CyclesBreaker
    {
        public static void Main()
        {
            var nodes = new SortedDictionary<string, Node<string>>();
            ReadInput(nodes);
            int removedEdgesCount = 0;
            var removedEdges = new List<string>();
            foreach (var currentNode in nodes)
            {
                for (int neighbourIndex = 0; neighbourIndex < currentNode.Value.Neighbours.Count; neighbourIndex++)
                {
                    var currentNeighbour = currentNode.Value.Neighbours[neighbourIndex];
                    nodes[currentNode.Value.Value].Neighbours.Remove(currentNeighbour);
                    nodes[currentNeighbour.Value].Neighbours.Remove(currentNode.Value);
                    bool canBeDeleted = CanFindPathFromNodeToAnotherNode(nodes, currentNode.Value.Value, currentNeighbour.Value);
                    if (canBeDeleted)
                    {
                        string removedEdgeAsString = string.Format("{0} - {1}", currentNode.Value.Value, currentNeighbour.Value);
                        removedEdges.Add(removedEdgeAsString);
                        removedEdgesCount++;
                    }
                    else
                    {
                        nodes[currentNode.Value.Value].Neighbours.Add(currentNeighbour);
                    }
                }
            }

            Console.WriteLine("Edges to remove: {0}", removedEdgesCount);
            Console.WriteLine(string.Join(Environment.NewLine, removedEdges));
        }

        private static void ReadInput(SortedDictionary<string, Node<string>> nodes)
        {
            string line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var lineParts = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                if (lineParts.Length > 1)
                {
                    string currentNode = lineParts[0];
                    var neighbours = lineParts[1]
                        .Trim()
                        .Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                        .OrderBy(n => n);

                    foreach (var neighbour in neighbours)
                    {
                        if (!nodes.ContainsKey(currentNode))
                        {
                            nodes[currentNode] = new Node<string>(currentNode);
                        }

                        if (!nodes.ContainsKey(neighbour))
                        {
                            nodes[neighbour] = new Node<string>(neighbour);
                        }

                        nodes[currentNode].Neighbours.Add(nodes[neighbour]);
                    }
                }

                line = Console.ReadLine();
            }
        }

        public static bool CanFindPathFromNodeToAnotherNode(SortedDictionary<string, Node<string>> nodes, string startNode, string endNode)
        {
            var queue = new Queue<Node<string>>();
            var visitedNodes = new HashSet<string>();

            // Enqueue the start node to the queue
            visitedNodes.Add(startNode);
            queue.Enqueue(nodes[startNode]);

            // Breadth-First Search (BFS)
            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Value == endNode)
                {
                    return true;
                }

                foreach (var neighbourNode in currentNode.Neighbours)
                {
                    if (!visitedNodes.Contains(neighbourNode.Value))
                    {
                        queue.Enqueue(neighbourNode);
                        visitedNodes.Add(neighbourNode.Value);
                    }
                }
            }

            return false;
        }
    }
}