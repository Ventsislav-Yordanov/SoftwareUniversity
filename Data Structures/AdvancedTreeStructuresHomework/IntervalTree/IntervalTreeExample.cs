namespace IntervalTree
{
    using System;

    public class IntervalTreeExample
    {
        public static void Main()
        {
            // Check this link to see the example I'm using:
            // http://ocw.mit.edu/courses/electrical-engineering-and-computer-science/6-046j-introduction-to-algorithms-sma-5503-fall-2005/video-lectures/lecture-11-augmenting-data-structures-dynamic-order-statistics-interval-trees/lec11.pdf
            // (look at slides 12 and 15-21 to see examples of insertion and interval search)
            var tree = new IntervalTree<int>();
            tree.Insert(new Interval<int>(17, 19));
            tree.Insert(new Interval<int>(5, 11));
            tree.Insert(new Interval<int>(4, 8));
            tree.Insert(new Interval<int>(15, 18));
            tree.Insert(new Interval<int>(7, 10));
            tree.Insert(new Interval<int>(22, 23));

            var searchInterval = new Interval<int>(14, 16);
            DisplaySearchResult(tree, searchInterval);
            searchInterval = new Interval<int>(12,14);
            DisplaySearchResult(tree, searchInterval);
        }

        private static void DisplaySearchResult(IntervalTree<int> tree, Interval<int> searchInterval)
        {
            var resultInterval = tree.Search(searchInterval);

            if (resultInterval != null)
            {
                Console.WriteLine(
                    "[{0}; {1}] is contained in the interval: [{2}; {3}]",
                    searchInterval.Start,
                    searchInterval.End,
                    resultInterval.Interval.Start,
                    resultInterval.Interval.End);
            }
            else
            {
                Console.WriteLine(
                   "[{0}; {1}] is not contained in any interval",
                   searchInterval.Start,
                   searchInterval.End);
            }
        }
    }
}
