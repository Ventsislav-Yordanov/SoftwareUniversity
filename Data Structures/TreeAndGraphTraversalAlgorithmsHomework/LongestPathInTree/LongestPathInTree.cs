namespace LongestPathInTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPathInTree
    {
        public static void Main()
        {
            var nodes = new Dictionary<int, List<int>>();
            var parents = new Dictionary<int, int?>();

            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] pair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (!nodes.ContainsKey(pair[0]))
                {
                    nodes[pair[0]] = new List<int>();
                }

                if (!parents.ContainsKey(pair[0]))
                {
                    parents[pair[0]] = null;
                }

                if (!parents.ContainsKey(pair[1]) || parents[pair[1]] == null)
                {
                    parents[pair[1]] = pair[0];
                }

                nodes[pair[0]].Add(pair[1]);
            }

            var rootNode = GetRoot(nodes, parents);
            int sum = FindLongestPathSum(nodes, rootNode);
            Console.WriteLine(sum);
        }

        private static int FindLongestPathSum(Dictionary<int, List<int>> tree, int root)
        {
            int[] bestPaths = new int[2] { int.MinValue, int.MinValue };
            foreach (var childNode in tree[root])
            {
                int currentPathSum = FindCurrentLongestPathSum(tree, childNode);
                if (currentPathSum > bestPaths[0])
                {
                    bestPaths[1] = bestPaths[0];
                    bestPaths[0] = currentPathSum;
                }
                else if (currentPathSum > bestPaths[1])
                {
                    bestPaths[1] = currentPathSum;
                }
            }

            return bestPaths.Sum() + root;
        }

        private static int FindCurrentLongestPathSum(Dictionary<int, List<int>> tree, int treeNode)
        {
            int bestSum = treeNode;
            if (tree.ContainsKey(treeNode))
            {
                foreach (var childNode in tree[treeNode])
                {
                    int currentPathSum = FindCurrentLongestPathSum(tree, childNode) + treeNode;

                    if (currentPathSum > bestSum)
                    {
                        bestSum = currentPathSum;
                    }
                }
            }

            return bestSum;
        }

        private static int GetRoot(Dictionary<int, List<int>> tree, Dictionary<int, int?> parents)
        {
            return tree.First(node => parents[node.Key] == null).Key;
        }
    }
}
