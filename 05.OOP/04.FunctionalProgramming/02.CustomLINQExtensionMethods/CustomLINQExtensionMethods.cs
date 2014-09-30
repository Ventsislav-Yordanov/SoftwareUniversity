using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomLINQExtensionMethods
{
    public static class CustomLINQExtensionMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            var result = collection.Where(a => !predicate(a));
            return result;
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            for (int i = 0; i < count - 1; i++)
            {
                // http://stackoverflow.com/questions/9492404/add-object-collection-to-another-object-collection-without-iterating
                collection = collection.Concat(collection);
            }
            return collection as IEnumerable<T>;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            List<string> result = new List<string>();
            foreach (var item in collection)
            {
                foreach (var suffix in suffixes)
                {
                    if (item.EndsWith(suffix)) // http://www.dotnetperls.com/endswith
                    {
                        result.Add(item);
                    }
                }
            }
            return result as IEnumerable<string>;
        }
    }
}
