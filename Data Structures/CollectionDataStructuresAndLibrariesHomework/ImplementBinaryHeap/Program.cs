namespace ImplementBinaryHeap
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var peopleComparer = new PeoplePriorityComparer();
            var priorityQueue = new PriorityQueue<int, string>(peopleComparer);
            priorityQueue.Enqueue(19, "Pesho");
            priorityQueue.Enqueue(1, "Gosho");
            priorityQueue.Enqueue(2, "Stanimir");
            priorityQueue.Enqueue(17, "Dimitar");
            priorityQueue.Enqueue(100, "Grandmother Stanka");

            while (!priorityQueue.IsEmpty)
            {
                Console.WriteLine(priorityQueue.Dequeue());
            }
        }
    }
}
