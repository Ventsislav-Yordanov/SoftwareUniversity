namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; } = new List<T>();

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            return this.BinarySearch(this.Items, item, 0, this.Items.Count - 1);
        }

        public int BinarySearch(List<T> collection, T SearchedItem, int minIndex, int maxIndex)
        {
            if (maxIndex < minIndex)
            {
                // The wanted item index is not found.
                return -1;
            }
            else
            {
                int middleIndex = (minIndex + maxIndex) / 2;
                if (collection[middleIndex].CompareTo(SearchedItem) > 0)
                {
                    return BinarySearch(collection, SearchedItem, minIndex, middleIndex - 1);
                }
                else if (collection[middleIndex].CompareTo(SearchedItem) < 0)
                {
                    return BinarySearch(collection, SearchedItem, middleIndex + 1, maxIndex);
                }
                else
                {
                    return middleIndex;
                }
            }
        }

        public int InterpolationSearch(T item)
        {
            throw new NotImplementedException();
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }
    }
}