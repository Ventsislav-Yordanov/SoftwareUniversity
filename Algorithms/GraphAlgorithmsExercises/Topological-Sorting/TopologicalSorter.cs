using System;
using System.Collections.Generic;
using System.Linq;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;
    private HashSet<string> visitedNodes;
    private HashSet<string> cycleNodes;
    private LinkedList<string> sortedNodes;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }


    public ICollection<string> TopSort()
    {
        this.visitedNodes = new HashSet<string>();
        this.sortedNodes = new LinkedList<string>();
        this.cycleNodes = new HashSet<string>();
        foreach (var node in this.graph.Keys)
        {
            TopSortDFS(node);
        }

        return this.sortedNodes;
    }

    private void TopSortDFS(string node)
    {
        if (this.cycleNodes.Contains(node))
        {
            throw new InvalidOperationException("A cycle detected in the graph");
        }

        if (!this.visitedNodes.Contains(node))
        {
            this.visitedNodes.Add(node);
            this.cycleNodes.Add(node);

            if (graph.ContainsKey(node))
            {
                foreach (var childNode in graph[node])
                {
                    TopSortDFS(childNode);
                }
            }

            this.cycleNodes.Remove(node);
            this.sortedNodes.AddFirst(node);
        }
    }

    //public ICollection<string> TopSort()
    //{
    //    var predecessorsCount = new Dictionary<string, int>();
    //    foreach (var node in this.graph)
    //    {
    //        if (!predecessorsCount.ContainsKey(node.Key))
    //        {
    //            predecessorsCount[node.Key] = 0;
    //        }
    //        foreach (var childNode in graph[node.Key])
    //        {
    //            if (!predecessorsCount.ContainsKey(childNode))
    //            {
    //                predecessorsCount[childNode] = 0;
    //            }

    //            predecessorsCount[childNode]++;
    //        }
    //    }

    //    var removedNodes = new List<string>();
    //    bool noteRemoved = true; 
    //    while (noteRemoved)
    //    {
    //        string nodeToRemove = graph.Keys.FirstOrDefault(k => predecessorsCount[k] == 0);
    //        if (nodeToRemove == null)
    //        {
    //            // No more nodes for removal (with 0 predecessors)
    //            break;
    //        }

    //        foreach (var childNode in graph[nodeToRemove])
    //        {
    //            predecessorsCount[childNode]--;
    //        }
    //        removedNodes.Add(nodeToRemove);
    //        graph.Remove(nodeToRemove);
    //    }

    //    if (graph.Count > 0)
    //    {
    //        throw new InvalidOperationException("A cycle detected in the graph");
    //    }

    //    return removedNodes;
    //}
}
