namespace FisherYatesShuffle
{
    using System;
    using System.Linq;

    public static class FisherYatesShuffleExample
    {
        public static void Main()
        {
            const int MaxIterations = 10;
            var collection = new SortableCollection<int>(Enumerable.Range(1, 10));
            for (int i = 0; i < MaxIterations; i++)
            {
                collection.Shuffle();
                Console.WriteLine(string.Join(Environment.NewLine, collection));
            }
        }
    }
}
