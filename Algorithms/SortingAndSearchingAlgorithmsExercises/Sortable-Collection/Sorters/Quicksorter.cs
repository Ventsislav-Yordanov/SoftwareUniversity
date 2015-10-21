namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Contracts;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(List<T> collection, int start, int end)
        {
            if (start < end)
            {
                var pivot = Partition(collection, start, end);
                QuickSort(collection, start, pivot);
                QuickSort(collection, pivot + 1, end);
            }
        }

        private int Partition(List<T> collection, int low, int high)
        {
            T pivot = collection[low];
            int left = low - 1;
            int right = high + 1;
            while (true)
            {
                do
                {
                    right--;
                } while (collection[right].CompareTo(pivot) > 0);

                do
                {
                    left++;
                } while (collection[left].CompareTo(pivot) < 0);

                if (left < right)
                {
                    Swap(collection, left, right);
                }
                else
                {
                    return right;
                }
            }
        }

        private void Swap(List<T> collection, int firstValue, int secondValue)
        {
            T swappedValue = collection[firstValue];
            collection[firstValue] = collection[secondValue];
            collection[secondValue] = swappedValue;
        }
    }
}
