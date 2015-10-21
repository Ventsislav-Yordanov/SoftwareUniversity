namespace InsertionSort
{
    using System;
    using System.Linq;

    public class InsertionSortExample
    {
        public static void Main()
        {
            var sorter = new InsertionSorter<int>();
            var numbers = new int[] { 1, 22, 30, 50, 1, 33, 10 }.ToList();
            Console.WriteLine(string.Join(", ", numbers));
            sorter.Sort(numbers);
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
