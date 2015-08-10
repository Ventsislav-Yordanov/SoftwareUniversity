namespace OrderedSet
{
    using System;

    public class OrderedSetExample
    {
        public static void Main()
        {
            var set = new OrderedSet<int>();
            //set.Add(17);
            //set.Add(9);
            //set.Add(12);
            //set.Add(19);
            //set.Add(6);
            //set.Add(25);

            //Console.WriteLine(set.Contains(12));
            //Console.WriteLine(set.Contains(60));

            //foreach (var child in set)
            //{
            //    Console.WriteLine(child);
            //}

            //// set.Remove(12);
            //set.Remove(9);

            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);

            //set.Remove(50);
        }
    }
}
