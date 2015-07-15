using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementALinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public class ListNode<T>
        {
            public T Value { get; private set; }

            public ListNode<T> NextNode { get; set; }

            public ListNode(T value)
            {
                this.Value = value;
            }
        }

        private ListNode<T> head;
        private ListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T element)
        {
            var newElement = new ListNode<T>(element);

            if (this.Count == 0)
            {
                this.head = this.tail = newElement;
            }
            else
            {
                this.tail.NextNode = newElement;
                this.tail = newElement;
            }

            this.Count++;
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot remove element from empty list.");
            }
            else if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int currentIndex = 0;
                var currentElement = this.head;
                while (currentElement != null)
                {
                    if (currentIndex == index - 1)
                    {
                        if (currentElement.NextNode.NextNode != null)
                        {
                            currentElement.NextNode = currentElement.NextNode.NextNode;
                        }
                        else
                        {
                            currentElement.NextNode = null;
                            this.tail = currentElement;
                        }

                        break;
                    }
                    else if (currentIndex == 0 && index == 0)
                    {
                        if (this.head.NextNode != null)
                        {
                            this.head = this.head.NextNode;
                        }
                        else
                        {
                            this.head = this.tail = null;
                        }

                        break;
                    }

                    currentIndex++;
                    currentElement = currentElement.NextNode;
                }

                this.Count--;
                return currentElement.Value;
            }
        }

        public int FirstIndexOf(T item)
        {
            int currentIndex = 0;
            var currentElement = this.head;
            while (currentElement != null)
            {
                if (currentElement.Value.Equals(item))
                {
                    return currentIndex;
                }

                currentIndex++;
                currentElement = currentElement.NextNode;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            int currentIndex = 0;
            int foundIndex = -1;
            var currentElement = this.head;
            while (currentElement != null)
            {
                if (currentElement.Value.Equals(item))
                {
                    foundIndex = currentIndex;
                }

                currentIndex++;
                currentElement = currentElement.NextNode;
            }

            return foundIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.head;
            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.NextNode;
            }
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
