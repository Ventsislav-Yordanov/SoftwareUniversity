namespace RoundDance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindTheLongestRoundDance
    {
        private static Dictionary<int, List<int>> dancingPeople;
        private static Dictionary<int, bool> visitedPeople;

        public static void Main()
        {
            int numberOfFriendships = int.Parse(Console.ReadLine());
            int leader = int.Parse(Console.ReadLine());
            dancingPeople = GetDancingPeople(numberOfFriendships);
            visitedPeople = new Dictionary<int, bool>();
            var longestDance = FindLongestDance(leader);
            Console.WriteLine(longestDance.Count);
        }

        private static Dictionary<int, List<int>> GetDancingPeople(int numberOfFriendships)
        {
            var dancingPeople = new Dictionary<int, List<int>>();

            for (int i = 0; i < numberOfFriendships; i++)
            {
                int[] dancePair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (!dancingPeople.ContainsKey(dancePair[0]))
                {
                    dancingPeople[dancePair[0]] = new List<int>();
                }

                dancingPeople[dancePair[0]].Add(dancePair[1]);

                if (!dancingPeople.ContainsKey(dancePair[1]))
                {
                    dancingPeople[dancePair[1]] = new List<int>();
                }

                dancingPeople[dancePair[1]].Add(dancePair[0]);
            }

            return dancingPeople;
        }

        private static List<int> FindLongestDance(int person)
        {
            var longestDance = new List<int>();

            visitedPeople[person] = true;
            foreach (var friend in dancingPeople[person])
            {
                var currentDance = new List<int>();
                if (!visitedPeople.ContainsKey(friend) || !visitedPeople[friend])
                {
                    currentDance.AddRange(FindLongestDance(friend));
                }

                if (currentDance.Count > longestDance.Count)
                {
                    longestDance = currentDance;
                }
            }

            longestDance.Add(person);
            return longestDance;
        }
    }
}
