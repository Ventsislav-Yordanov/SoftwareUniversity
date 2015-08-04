namespace FindTheRoot
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Graph : IEnumerable<int>
    {
        public Graph(int numberOfNodes)
        {
            this.Nodes = new List<int>[numberOfNodes];
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                this.Nodes[i] = new List<int>();
            }
        }

        public List<int>[] Nodes { get; private set; }

        public int Count
        {
            get
            {
                return this.Nodes.Length;
            }
        }

        public void Add(int parent, int child)
        {
            if (parent < 0 || parent >= this.Nodes.Length)
            {
                throw new IndexOutOfRangeException("Invalid parent index. Index must be between 0 and the number of nodes.");
            }

            if (child < 0 || child >= this.Nodes.Length)
            {
                throw new IndexOutOfRangeException("Invalid child index. Index must be between 0 and the number of nodes.");
            }

            this.Nodes[parent].Add(child);
        }

        public static Graph Create()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            var graph = new Graph(numberOfNodes);

            for (int i = 0; i < numberOfEdges; i++)
            {
                int[] parentChildPair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                graph.Add(parentChildPair[0], parentChildPair[1]);
            }

            return graph;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Nodes.Length; i++)
            {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
