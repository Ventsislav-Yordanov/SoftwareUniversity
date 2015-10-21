namespace HeapSort
{
    using System;
    using System.Collections.Generic;

    public class HeapSortExample
    {
        public static void Main()
        {
            var sorter = new HeapSorter<int>();
            var collection = new List<int> { 1, 20, 33, 43, 12, 2, 5, 3 };
            sorter.Sort(collection);
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
        }
    }
}
