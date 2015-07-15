namespace ImplementALinkedList
{
    using System;

    class Program
    {
        static void Main()
        {
            var list = new ImplementALinkedList.LinkedList<int>();
            list.Add(1);
            list.Add(56);
            list.Add(20);
            list.Remove(1);
            list.Add(10);
            list.Add(36);
            list.Remove(2);
            list.Add(5);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
