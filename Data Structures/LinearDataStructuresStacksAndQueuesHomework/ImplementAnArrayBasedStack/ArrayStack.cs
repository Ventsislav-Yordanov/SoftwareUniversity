namespace ImplementAnArrayBasedStack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ArrayStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public int Count { get; private set; }

        public ArrayStack()
            : this(InitialCapacity)
        {
        }

        public ArrayStack(int capacity)
        {
            this.elements = new T[capacity];
        }

        public void Push(T element)
        {
            if (this.Count == this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            var element = this.elements[this.Count - 1];
            var newElements = new T[this.elements.Length];
            Array.Copy(this.elements, 0, newElements, 0, this.elements.Length - 2);
            this.Count--;

            return element;
        }

        public T[] ToArray()
        {
            var resultArray = new T[this.Count];
            int resultIndex = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                resultArray[resultIndex] = elements[i];
                resultIndex++;
            }

            return resultArray;
        }

        private void Grow()
        {
            var newElements = new T[this.elements.Length * 2];
            this.CopyAllElementsTo(newElements);
            this.elements = newElements;
        }

        private void CopyAllElementsTo(T[] resultArray)
        {
            Array.Copy(this.elements, resultArray, this.Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            //for (int i = 0; i < this.Count; i++)
            //{
            //    yield return this.elements[i];
            //}
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
