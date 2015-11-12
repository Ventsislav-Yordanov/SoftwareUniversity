﻿namespace ModifiedKruskalAlgorithm
{
    using System.Collections.Generic;

    public class KruskalAlgorithm
    {
        public static List<Edge> Kruskal(int numberOfVertices, List<Edge> edges)
        {
            edges.Sort();
            var parent = new int[numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                parent[i] = i;
            }

            // Kurskal's Algorithm
            var spaningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = FindRoot(edge.StartNode, parent);
                int rootEndNode = FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spaningTree.Add(edge);
                    parent[rootEndNode] = rootStartNode;
                }
            }

            return spaningTree;
        }

        public static int FindRoot(int node, int[] parent)
        {
            int root = node;
            while (parent[root] != root)
            {
                root = parent[root];
            }

            // Optimize the path to root
            // Attach each path node directly to the root
            while (node != root)
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }
    }
}
