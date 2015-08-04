namespace PlayWithTrees
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);
                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }
            int pathSum = int.Parse(Console.ReadLine());
            int subtreeSum = int.Parse(Console.ReadLine());

            var rootNode = FindRootNode();
            Console.WriteLine("Root node: {0}", rootNode.Value);

            var leafNodes = FindLeafNodes();
            Console.Write("Leaf nodes: ");
            Console.WriteLine(string.Join(", ", leafNodes.Select(node => node.Value)));

            var middleNodes = FindMiddleNodes();
            Console.Write("Middle nodes: ");
            Console.WriteLine(string.Join(", ", middleNodes.Select(node => node.Value)));

            var longestPath = FindLongestPath(rootNode).ToArray();
            Array.Reverse(longestPath);
            Console.Write("Longest path: ");
            Console.Write(string.Join(" -> ", longestPath.Select(node => node.Value)));
            Console.WriteLine(" (Length = {0})", longestPath.Count());

            var pathsWithGivenSum = FindAllPathsWithGivenSum(
                treeNode: rootNode,
                sum: pathSum,
                currentPath: new List<Tree<int>>() { rootNode },
                allPaths: new List<List<int>>(),
                currentSum: rootNode.Value);
            foreach (var path in pathsWithGivenSum)
            {
                Console.WriteLine(string.Join(" ", path));
            }
        }

        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);
            return rootNode;
        }

        static IEnumerable<Tree<int>> FindMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                                .Where(node => node.Children.Count > 0 && node.Parent != null)
                                .OrderBy(node => node.Value);
            return middleNodes;
        }

        static IEnumerable<Tree<int>> FindLeafNodes()
        {
            var middleNodes = nodeByValue.Values
                                .Where(node => node.Children.Count == 0 && node.Parent != null)
                                .OrderBy(node => node.Value);
            return middleNodes;
        }

        static IList<Tree<int>> FindLongestPath(Tree<int> treeNode)
        {
            IList<Tree<int>> longestPath = new List<Tree<int>>();
            foreach (var childNode in treeNode.Children)
            {
                var currentPath = FindLongestPath(childNode);
                if (currentPath.Count > longestPath.Count)
                {
                    longestPath = currentPath;
                }
            }

            longestPath.Add(treeNode);

            return longestPath;
        }

        static IList<List<int>> FindAllPathsWithGivenSum(
            Tree<int> treeNode,
            int sum,
            List<Tree<int>> currentPath,
            IList<List<int>> allPaths,
            int currentSum)
        {
            foreach (var childNode in treeNode.Children)
            {
                currentPath.Add(childNode);
                currentSum += childNode.Value;

                if (currentSum == sum)
                {
                    allPaths.Add(currentPath.Select(t => t.Value).ToList());
                }

                FindAllPathsWithGivenSum(childNode, sum, currentPath, allPaths, currentSum);
                currentPath.Remove(childNode);
                currentSum -= childNode.Value;
            }

            return allPaths;
        }
    }
}
