namespace Sortable_Collection
{
    using System;

    using Sorters;
    using System.Linq;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            // ---------- Quick Sort ----------
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var collection = new SortableCollection<int>(numbers);
            Console.WriteLine(collection);
            collection.Sort(new Quicksorter<int>());
            Console.WriteLine(collection);

            // ---------- Bucket Sort ----------
            //const int NumberOfElementsToSort = 22;
            //const int MaxValue = 150;

            //var array = new int[NumberOfElementsToSort];

            //for (int i = 0; i < NumberOfElementsToSort; i++)
            //{
            //    array[i] = Random.Next(MaxValue);
            //}

            //var collectionToSort = new SortableCollection<int>(array);
            //collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            //Console.WriteLine(collectionToSort);
        }
    }
}
