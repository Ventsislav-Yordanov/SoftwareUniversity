namespace InsertionSort
{
    using System;
    using System.Collections.Generic;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (var counter = 0; counter < collection.Count - 1; counter++)
            {
                var index = counter + 1;
                while (index > 0)
                {
                    if (collection[index - 1].CompareTo(collection[index]) > 0)
                    {
                        var temp = collection[index - 1];
                        collection[index - 1] = collection[index];
                        collection[index] = temp;
                    }

                    index--;
                }
            }
        }
    }
}