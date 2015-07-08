namespace ImplementTheDataStructureReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int defaultCapacity = 4;
        private T[] elements;

        public ReversedList()
        {
            this.Capacity = defaultCapacity;
            this.elements = new T[this.Capacity];
        }

        public int Count { get; private set; }

        public int Capacity { get; private set; }

        public void Add(T element)
        {
            if (this.Count >= this.Capacity)
            {
                EnsureCapacity();
            }

            elements[this.Count] = element;
            this.Count++;
        }

        public void Delete(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Could not remove element from empty list");
            }

            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            index = this.Count - index - 1;

            var newArray = new T[Capacity];
            Array.Copy(this.elements, 0, newArray, 0, index);
            Array.Copy(this.elements, index + 1, newArray, index, this.Count - index - 1);
            this.Count--;
            this.elements = newArray;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.elements[this.Count - index - 1];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.elements[this.Count - index - 1] = value;
            }
        }

        public void EnsureCapacity()
        {
            this.Capacity += this.Capacity;
            var newArray = new T[this.Capacity];
            Array.Copy(this.elements, newArray, this.Count);
            this.elements = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[this.Count - i - 1];
            }
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
