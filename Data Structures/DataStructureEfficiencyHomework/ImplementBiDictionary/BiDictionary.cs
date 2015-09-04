namespace ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<TKey1, TKey2, TValue>
    {
        private Dictionary<TKey1, List<TValue>> valuesByFirstKey = new Dictionary<TKey1, List<TValue>>();
        private Dictionary<TKey2, List<TValue>> valuesBySecondKey = new Dictionary<TKey2, List<TValue>>();
        private Dictionary<Tuple<TKey1, TKey2>, List<TValue>> valuesByBothKeys = new Dictionary<Tuple<TKey1, TKey2>, List<TValue>>();

        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            this.valuesByFirstKey.AppendValueToKey(key1, value);

            this.valuesBySecondKey.AppendValueToKey(key2, value);

            var tuple = new Tuple<TKey1, TKey2>(key1, key2);
            this.valuesByBothKeys.AppendValueToKey(tuple, value);
        }

        public IEnumerable<TValue> Find(TKey1 key1, TKey2 key2)
        {
            var tuple = new Tuple<TKey1, TKey2>(key1, key2);
            return this.valuesByBothKeys.GetValuesForKey(tuple);
        }

        public IEnumerable<TValue> FindByKey1(TKey1 key1)
        {
            return this.valuesByFirstKey.GetValuesForKey(key1);

        }

        public IEnumerable<TValue> FindByKey2(TKey2 key2)
        {
            return this.valuesBySecondKey.GetValuesForKey(key2);
        }

        public bool Remove(TKey1 key1, TKey2 key2)
        {
            var tuple = new Tuple<TKey1, TKey2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                return false;
            }

            var values = this.valuesByBothKeys[tuple];
            this.valuesByBothKeys.Remove(tuple);
            foreach (var value in values)
            {
                if (this.valuesByFirstKey[key1].Contains(value))
                {
                    this.valuesByFirstKey[key1].Remove(value);
                }

                if (this.valuesBySecondKey[key2].Contains(value))
                {
                    this.valuesBySecondKey[key2].Remove(value);
                }
            }

            return true;
        }
    }
}
