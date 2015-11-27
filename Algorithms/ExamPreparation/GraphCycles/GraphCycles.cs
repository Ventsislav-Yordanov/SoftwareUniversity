namespace GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphCycles
    {
        private static int[] edges;
        private static Dictionary<int, int[]> edgeChilds;

        public static void Main()
        {
            int verticesCount = int.Parse(Console.ReadLine());
            edges = new int[verticesCount];
            edgeChilds = new Dictionary<int, int[]>();
            for (int i = 0; i < verticesCount; i++)
            {
                var sourceAndChilds = Console.ReadLine()
                    .Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                edges[i] = sourceAndChilds[0];
                if (!edgeChilds.ContainsKey(sourceAndChilds[0]))
                {
                    edgeChilds[sourceAndChilds[0]] = sourceAndChilds
                        .Skip(1)
                        .Distinct()
                        .OrderBy(x => x)
                        .ToArray();
                }
            }

            var result = new List<Node>();
            int count = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                foreach (var child in edgeChilds[edges[i]])
                {
                    foreach (var subChild in edgeChilds[child])
                    {
                        foreach (var subSubChild in edgeChilds[subChild])
                        {
                            if (subChild != subSubChild &&
                                child < subChild &&
                                child < subSubChild)
                            {
                                if (subSubChild == edges[i])
                                {
                                    result.Add(new Node(child, subChild, subSubChild));
                                    count++;
                                }
                            }

                        }
                    }
                }
            }

            result.Sort();
            foreach (var node in result)
            {
                Console.WriteLine($"{{{node.Child} -> {node.SubChild} -> {node.SubSubChild}}}");
            }

            if (count == 0)
            {
                Console.WriteLine("No cycles found");
            }
        }
    }
}
