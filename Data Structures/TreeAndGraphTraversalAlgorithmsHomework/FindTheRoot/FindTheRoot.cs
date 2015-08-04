namespace FindTheRoot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTheRoot
    {
        public static void Main()
        {
            // First Solution: We remember the graph. This is useful
            // because another algorithm may need it.

            //var graph = Graph.Create();
            //FindRoot(graph);

            FindTheRootProposedSolution.FindRoot();
        }

        private static void FindRoot(Graph graph)
        {
            var allChildren = new HashSet<int>();

            foreach (var node in graph.Nodes)
            {
                allChildren.UnionWith(node);
            }

            if (allChildren.Count == graph.Count)
            {
                Console.WriteLine("No root!");
            }
            else if (allChildren.Count == graph.Count - 1)
            {
                // Except() returns all graph nodes which aren't children.
                // Since there is only one such node, we get it directly.
                var root = graph.Except(allChildren).First();
                Console.WriteLine("Root: {0}", root);
            }
            else
            {
                Console.WriteLine("Multiple root nodes!");
            }
        }
    }
}
