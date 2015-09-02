namespace ImplementBinaryHeap
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<TPriority, TValue> : ICollection<KeyValuePair<TPriority, TValue>>
    {
        private List<KeyValuePair<TPriority, TValue>> baseHeap;
        private IComparer<TPriority> comparer;

        public PriorityQueue()
            : this(Comparer<TPriority>.Default)
        {
        }

        public PriorityQueue(int capacity)
            : this(capacity, Comparer<TPriority>.Default)
        {
        }

        public PriorityQueue(int capacity, IComparer<TPriority> comparer)
        {
            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>(capacity);
            this.Comparer = comparer;
        }

        public PriorityQueue(IComparer<TPriority> comparer)
        {
            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>();
            this.Comparer = comparer;
        }

        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data)
            : this(data, Comparer<TPriority>.Default)
        {
        }

        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
        {
            if (data == null || comparer == null)
            {
                throw new ArgumentNullException();
            }

            this.Comparer = comparer;
            this.baseHeap = new List<KeyValuePair<TPriority, TValue>>(data);

            for (int position = (this.baseHeap.Count / 2) - 1; position >= 0; position--)
            {
                this.HeapifyFromBeginningToEnd(position);
            }
        }

        public int Count
        {
            get
            {
                return this.baseHeap.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.baseHeap.Count == 0;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        private IComparer<TPriority> Comparer
        {
            get
            {
                return this.comparer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("comparer");
                }

                this.comparer = value;
            }
        }

        public void CopyTo(KeyValuePair<TPriority, TValue>[] array, int arrayIndex)
        {
            this.baseHeap.CopyTo(array, arrayIndex);
        }

        public void Enqueue(TPriority priority, TValue value)
        {
            this.Insert(priority, value);
        }

        public KeyValuePair<TPriority, TValue> Dequeue()
        {
            if (!this.IsEmpty)
            {
                var result = this.baseHeap[0];
                this.DeleteRoot();

                return result;
            }
            else
            {
                throw new InvalidOperationException("Priority queue is empty");
            }
        }

        public TValue DequeueValue()
        {
            return this.Dequeue().Value;
        }

        public KeyValuePair<TPriority, TValue> Peek()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException("Priority queue is empty");
            }

            return this.baseHeap[0];
        }

        public TValue PeekValue()
        {
            return this.Peek().Value;
        }

        public void Add(KeyValuePair<TPriority, TValue> item)
        {
            this.Enqueue(item.Key, item.Value);
        }

        public void Clear()
        {
            this.baseHeap.Clear();
        }

        public bool Contains(KeyValuePair<TPriority, TValue> item)
        {
            return this.baseHeap.Contains(item);
        }

        public bool Remove(KeyValuePair<TPriority, TValue> item)
        {
            int elementIndex = this.baseHeap.IndexOf(item);
            if (elementIndex < 0)
            {
                return false;
            }

            this.baseHeap[elementIndex] = this.baseHeap[this.baseHeap.Count - 1];
            this.baseHeap.RemoveAt(this.baseHeap.Count - 1);

            int newPos = this.HeapifyFromEndToBeginning(elementIndex);
            if (newPos == elementIndex)
            {
                this.HeapifyFromBeginningToEnd(elementIndex);
            }

            return true;
        }

        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            return this.baseHeap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ExchangeElements(int firstIndex, int secondIndex)
        {
            var swap = this.baseHeap[firstIndex];
            this.baseHeap[firstIndex] = this.baseHeap[secondIndex];
            this.baseHeap[secondIndex] = swap;
        }

        private void Insert(TPriority priority, TValue value)
        {
            var newValue = new KeyValuePair<TPriority, TValue>(priority, value);
            this.baseHeap.Add(newValue);

            this.HeapifyFromEndToBeginning(this.baseHeap.Count - 1);
        }

        private int HeapifyFromEndToBeginning(int position)
        {
            if (position >= this.baseHeap.Count)
            {
                return -1;
            }

            while (position > 0)
            {
                int parentPosition = (position - 1) / 2;
                if (this.Comparer.Compare(this.baseHeap[parentPosition].Key, this.baseHeap[position].Key) <= 0)
                {
                    break;
                }
                else
                {
                    this.ExchangeElements(parentPosition, position);
                    position = parentPosition;
                }
            }

            return position;
        }

        private void DeleteRoot()
        {
            if (this.baseHeap.Count <= 1)
            {
                this.baseHeap.Clear();
            }
            else
            {
                this.baseHeap[0] = this.baseHeap[this.baseHeap.Count - 1];
                this.baseHeap.RemoveAt(this.baseHeap.Count - 1);

                this.HeapifyFromBeginningToEnd(0);
            }
        }

        private void HeapifyFromBeginningToEnd(int position)
        {
            if (position >= this.baseHeap.Count)
            {
                return;
            }

            while (true)
            {
                int smallest = position;
                int leftChild = (2 * position) + 1;
                int rightChild = (2 * position) + 2;
                if (leftChild < this.baseHeap.Count &&
                    this.Comparer.Compare(this.baseHeap[smallest].Key, this.baseHeap[leftChild].Key) > 0)
                {
                    smallest = leftChild;
                }

                if (rightChild < this.baseHeap.Count &&
                    this.Comparer.Compare(this.baseHeap[smallest].Key, this.baseHeap[rightChild].Key) > 0)
                {
                    smallest = rightChild;
                }

                if (smallest == position)
                {
                    break;
                }
                else
                {
                    this.ExchangeElements(smallest, position);
                    position = smallest;
                }
            }
        }
    }
}
