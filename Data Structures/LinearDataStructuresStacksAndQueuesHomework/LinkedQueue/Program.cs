namespace LinkedQueue
{
    class Program
    {
        static void Main()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Enqueue(3);
            linkedQueue.Enqueue(5);
            linkedQueue.Enqueue(-2);
            linkedQueue.Enqueue(7);
            var arr = linkedQueue.ToArray();
        }
    }
}
