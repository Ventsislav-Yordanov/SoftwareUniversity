namespace InterpolationSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SortableCollection{T}" class />
        /// </summary>
        /// <param name="items">The collection items</param>
        /// <param name="distanceFunction">A function which returns the "distance" between two items 
        /// (for example: the distance between the numbers 3 and -5 is -8, between 4 and 5.5 is 1.5)</param>
        public SortableCollection(IEnumerable<T> items, Func<T, T, double> distanceFunction)
        {
            this.Items = new List<T>(items);
            this.DistanceFunction = distanceFunction;
        }

        public SortableCollection(Func<T, T, double> distanceFunction, params T[] items)
            : this(items.AsEnumerable(), distanceFunction)
        {
        }

        public List<T> Items { get; } = new List<T>();

        public Func<T, T, double> DistanceFunction { get; set; }

        public int Count => this.Items.Count;

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int InterpolationSearch(T item)
        {
            if (this.Count == 0)
            {
                // No element can be found in a empty collection
                return -1;
            }

            int low = 0;
            int high = this.Count - 1;
            int middle;

            while (this.Items[low].CompareTo(item) < 0 && this.Items[high].CompareTo(item) >= 0)
            {
                double distanceToItem = this.DistanceFunction(this.Items[low], item);
                double intervalLength = this.DistanceFunction(this.Items[low], this.Items[high]);
                middle = (int)(low + distanceToItem * (high - low) / intervalLength);

                if (this.Items[middle].CompareTo(item) < 0)
                {
                    low = middle + 1;
                }
                else if (this.Items[middle].CompareTo(item) > 0)
                {
                    high = middle - 1;
                }
                else
                {
                    return this.GetFirstIndex(middle);
                }
            }

            if (this.Items[low].CompareTo(item) == 0)
            {
                return this.GetFirstIndex(low);
            }

            return -1;
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", this.Items)}]";
        }

        /// <summary>
        /// Gets the first index of the found element,
        /// for example, if the array is 0, 2, 2, 5 and the item is 2,
        /// it should return 1
        /// </summary>
        /// <param name="foundIndex"></param>
        /// <returns></returns>
        private int GetFirstIndex(int foundIndex)
        {
            while (foundIndex > 0 && this.Items[foundIndex - 1].CompareTo(this.Items[foundIndex]) == 0)
            {
                foundIndex--;
            }

            return foundIndex;
        }
    }
}
