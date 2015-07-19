namespace CalculateSequenceUsingQueue
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            queue.Enqueue(start);
            int count = 1;
            while (count <= 50)
            {
                int current = queue.Dequeue();
                Console.WriteLine("Number {0}: {1}", count, current);
                
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
                count++;
            }

        }
    }
}
