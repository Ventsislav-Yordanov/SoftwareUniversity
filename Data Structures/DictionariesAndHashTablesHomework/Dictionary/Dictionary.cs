using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary
{
    public class Dictionary<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const int InitialCapacity = 16;

        private HashTable<TKey, TValue> elements;

        public Dictionary()
            : this(InitialCapacity)
        {
        }

        public Dictionary(int capacity)
        {
            this.elements = new HashTable<TKey, TValue>(capacity);
        }

        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        public void Add(TKey key, TValue value)
        {
            this.elements.Add(key, value);
        }

        public bool Remove(TKey key)
        {
            return this.elements.Remove(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.elements[key];
            }
            set
            {
                this.elements[key] = value;
            }
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public bool ContainsKey(TKey key)
        {
            var element = this.elements.Find(key);
            return element != null;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (var element in this.elements)
            {
                if (element.Value.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.elements.Find(key);
            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.elements.Keys;
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.elements.Values;
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
