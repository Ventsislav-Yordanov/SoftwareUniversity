namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        private bool isInitialized = false;

        private BinarySearchTree<T> elements;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (!this.isInitialized)
            {
                this.elements = new BinarySearchTree<T>(element);
                this.isInitialized = true;
            }
            else
            {
                this.elements.Add(element);
            }

            this.Count++;
        }

        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }

        public void Remove(T element)
        {
            this.elements.Remove(element);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
