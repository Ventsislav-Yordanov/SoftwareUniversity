namespace CyclesInGraph
{
    using System.Collections.Generic;

    public class CyclesFinder
    {
        private Dictionary<string, List<string>> graph;
        private HashSet<string> cycleNodes;
        private bool IsAcyclic = true;

        public CyclesFinder(Dictionary<string, List<string>> graph)
        {
            this.graph = graph;
        }

        public string TryFindCycles()
        {
            this.cycleNodes = new HashSet<string>();
            foreach (var node in this.graph.Keys)
            {
                if (!this.cycleNodes.Contains(node))
                {
                    TryFindCyclesDFS(node);
                }
            }

            return string.Format("Acyclic: {0}", this.IsAcyclic ? "Yes" : "No");
        }

        private void TryFindCyclesDFS(string node)
        {
            if (this.cycleNodes.Contains(node))
            {
                this.IsAcyclic = false;
            }

            if (!this.cycleNodes.Contains(node))
            {
                this.cycleNodes.Add(node);

                if (graph.ContainsKey(node))
                {
                    foreach (var childNode in graph[node])
                    {
                        TryFindCyclesDFS(childNode);
                    }
                }
            }
        }
    }
}
