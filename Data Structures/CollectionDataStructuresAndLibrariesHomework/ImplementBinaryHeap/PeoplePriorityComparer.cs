namespace ImplementBinaryHeap
{
    using System;
    using System.Collections.Generic;

    public class PeoplePriorityComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return -x.CompareTo(y);
        }
    }
}
