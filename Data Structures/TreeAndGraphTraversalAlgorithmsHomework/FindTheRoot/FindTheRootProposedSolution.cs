namespace FindTheRoot
{
    using System;
    using System.Linq;

    public class FindTheRootProposedSolution
    {
        public static void FindRoot()
        {
            bool[] hasParent = ReadGraph();

            bool isRootFound = false;
            bool areManyRootsFound = false;
            int rootNode = -1;

            for (int i = 0; i < hasParent.Length; i++)
            {
                if (!hasParent[i])
                {
                    if (isRootFound)
                    {
                        areManyRootsFound = true;
                        break;
                    }

                    isRootFound = true;
                    rootNode = i;
                }
            }

            if (isRootFound)
            {
                if (areManyRootsFound)
                {
                    Console.WriteLine("Multiple root nodes!");
                    return;
                }

                Console.WriteLine("Root: {0}", rootNode);
            }
            else
            {
                Console.WriteLine("No root!");
            }
        }

        private static bool[] ReadGraph()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            bool[] hasParent = new bool[numberOfNodes];

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] parentChildPair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                hasParent[parentChildPair[1]] = true;
            }

            return hasParent;
        }
    }
}
