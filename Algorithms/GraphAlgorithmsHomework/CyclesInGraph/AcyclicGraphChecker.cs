namespace CyclesInGraph
{
    using System;
    using System.Collections.Generic;

    public class AcyclicGraphChecker
    {
        public static void Main()
        {
            var graph = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                var lineInfo = line.Split('-');
                string first = lineInfo[0].Trim();
                string second = lineInfo[1].Trim();
                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<string>();
                }

                graph[first].Add(second);
                line = Console.ReadLine();
            }

            var cyclesFinder = new CyclesFinder(graph);
            string result =  cyclesFinder.TryFindCycles();
            Console.WriteLine(result);
        }
    }
}
