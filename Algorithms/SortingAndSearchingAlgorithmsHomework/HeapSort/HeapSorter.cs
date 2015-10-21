namespace HeapSort
{
    using System;
    using System.Collections.Generic;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap<T>(collection.ToArray());
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                collection[i] = heap.ExtractMax();
            }
        }
    }
}