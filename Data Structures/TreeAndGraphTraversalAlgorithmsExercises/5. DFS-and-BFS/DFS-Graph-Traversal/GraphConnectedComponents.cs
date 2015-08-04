using System;
using System.Collections.Generic;
using System.Linq;

public class GraphConnectedComponents
{

    private static List<int>[] graph ;

    private static bool[] visited;

    public static void Main()
    {
        graph = ReadGraph();
        visited = new bool[graph.Length];
        for (int i = 0; i < graph.Length; i++)
        {
            if (!visited[i])
            {
                Console.Write("Connected component:");
                DFS(i);
                Console.WriteLine();
            }
        }
        Console.Read();
    }

    private static void DFS(int indexNode)
    {
        if (!visited[indexNode])
        {
            visited[indexNode] = true;
            foreach (var childNode in graph[indexNode])
            {
                DFS(childNode);
            }
            Console.Write(" " + indexNode);
        }
    }

    private static List<int>[] ReadGraph()
    {
        int n = int.Parse(Console.ReadLine());
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
        }

        return graph;
    }
}
