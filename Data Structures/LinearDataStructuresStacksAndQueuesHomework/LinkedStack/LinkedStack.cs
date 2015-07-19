namespace LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node<T> firstNode;
        public int Count { get; private set; }

        public void Push(T element)
        {
            //var newElement = new Node<T>(element);
            //if (this.firstNode == null)
            //{
            //    this.firstNode = newElement;
            //}
            //else
            //{
            //    newElement.NextNode = this.firstNode;
            //    this.firstNode = newElement;
            //}
            this.firstNode = new Node<T>(element, firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The LinkedStack is empty.");
            }

            var element = this.firstNode;
            this.firstNode = firstNode.NextNode;
            this.Count--;

            return element.value;
        }

        public T[] ToArray()
        {
            var arrayResult = new T[this.Count];
            var currentElement = this.firstNode;
            int count = 0;
            while(currentElement != null)
            {
                arrayResult[count] = currentElement.value;
                currentElement = currentElement.NextNode;
                count++;
            }

            return arrayResult;
        }

        private class Node<T>
        {
            public T value;
            public Node<T> NextNode { get; set; }

            public Node(T value, Node<T> nextNode = null)
            {
                this.value = value;
                this.NextNode = nextNode;
            }
        }
    }
}
