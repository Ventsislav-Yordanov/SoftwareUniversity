namespace CollectionOfProducts
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Ensures the specified key exists in the dictionary.
        /// If the key does not exist, it is mapped to a new empty value.
        /// </summary>
        public static void EnsureKeyExists<TKey, TValue>(
            this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : new()
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new TValue());
            }
        }

        /// <summary>
        /// Updates a value in the specified dictionary
        /// </summary>
        /// <typeparam name="TDictionary">A type which extends the 
        /// <see cref="Wintellect.PowerCollections.MultiDictionaryBase{TKey, TValue}"></see> class</typeparam>
        /// <typeparam name="TKey">The type of the key in the dictionary</typeparam>
        /// <typeparam name="TValue">The type of the value in the dictionary</typeparam>
        /// <param name="dict">The target dictionary</param>
        /// <param name="oldKey">The old key</param>
        /// <param name="newKey">The new key</param>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        public static void UpdateValue<TDictionary, TKey, TValue>(
            this TDictionary dict,
            TKey oldKey,
            TKey newKey,
            TValue oldValue,
            TValue newValue)
            where TDictionary : MultiDictionaryBase<TKey, TValue>
        {
            dict.Remove(oldKey, oldValue);
            dict.Add(newKey, newValue);
        }
    }
}
