namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        public int Count { get; private set; }
        private QueueNode<T> head;
        private QueueNode<T> tail;

        public void Enqueue(T element)
        {
            var newElement = new QueueNode<T>(element);
            if (this.Count == 0)
            {
                this.head = this.tail = newElement;
            }
            else
            {
                this.tail.NextNode = newElement;
                newElement.PrevNode = this.tail;
                this.tail = newElement;
            }
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty.");
            }

            var element = this.head;
            this.head = this.head.NextNode;
            this.Count--;

            return element.Value;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            var currentElement = this.head;
            int count = 0;
            while (currentElement != null)
            {
                resultArray[count] = currentElement.Value;
                currentElement = currentElement.NextNode;
                count++;
            }

            return resultArray;
        }

        private class QueueNode<T>
        {
            public T Value { get; private set; }
            public QueueNode<T> NextNode { get; set; }
            public QueueNode<T> PrevNode { get; set; }

            public QueueNode(T value)
            {
                this.Value = value;
            }
        }
    }
}
