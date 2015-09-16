namespace OnlineMarket
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class OnlineMarketExample
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            string inputLine = Console.ReadLine();
            var market = new OnlineMarket();
            while (inputLine != "end")
            {
                string commandResult = market.ProcessCommand(inputLine);
                Console.WriteLine(commandResult);
                inputLine = Console.ReadLine();
            }
        }
    }

    public class OnlineMarket
    {
        private MultiDictionary<string, Product> productsByType;
        private MultiDictionary<string, Product> productsByName;
        private OrderedMultiDictionary<decimal, Product> productsByPrice;

        public OnlineMarket()
        {
            this.productsByType = new MultiDictionary<string, Product>(false);
            this.productsByName = new MultiDictionary<string, Product>(false);
            this.productsByPrice = new OrderedMultiDictionary<decimal, Product>(false);
        }

        public string AddProduct(string name, decimal price, string type)
        {
            if (!this.productsByName.ContainsKey(name))
            {
                var newProduct = new Product(name, price, type);
                this.productsByName.Add(name, newProduct);
                this.productsByType.Add(type, newProduct);
                this.productsByPrice.Add(price, newProduct);

                return string.Format("Ok: Product {0} added successfully", name);
            }

            return string.Format("Error: Product {0} already exists", name);
        }

        public string FilterByType(string type)
        {
            //string result = "Ok: ";
            string result = string.Empty;
            var resultProducts = new List<Product>();
            if (this.productsByType.ContainsKey(type))
            {
                result += "Ok: ";
                var products = this.productsByType[type]; //TODO: Check if product are null or 0 Count
                foreach (var product in products)
                {
                    resultProducts.Add(product);
                }
                var sortedResultProducts = resultProducts
                    .OrderBy(p => p.Price)
                    .ThenBy(p => p.Name)
                    .ThenBy(p => p.Type)
                    .Take(10);

                result += string.Join(", ", sortedResultProducts);
            }
            else
            {
                result += string.Format("Error: Type {0} does not exists", type);
            }

            return result;
        }

        public string FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            string result = "Ok: ";
            var products = this.productsByPrice.Range(minPrice, true, maxPrice, true).Values;
            if (products.Any())
            {
                result += string.Join(", ", products.Take(10));
            }

            return result;
        }

        public string FilterByPriceFrom(decimal price)
        {
            string result = "Ok: ";
            var products = this.productsByPrice.RangeFrom(price, true).Values;
            if (products.Any())
            {
                result += string.Join(", ", products.Take(10));
            }

            return result;
        }

        public string FilterByPriceTo(decimal price)
        {
            string result = "Ok: ";
            var products = this.productsByPrice.RangeTo(price, true).Values;
            if (products.Any())
            {
                result += string.Join(", ", products.Take(10));
            }

            return result;
        }

        public string ProcessCommand(string inputLine)
        {
            string[] commandParts = inputLine.Split(' ');
            string command;
            if (commandParts[0] == "add")
            {
                command = "add";
            }
            else if (commandParts[0] == "filter")
            {
                string filterBy = commandParts[2];
                command = "filter by " + filterBy;
            }
            else
            {
                command = "End";
            }
            switch (command)
            {
                case "add":
                    return this.AddProduct(commandParts[1], decimal.Parse(commandParts[2]), commandParts[3]);
                case "filter by type":
                    return this.FilterByType(commandParts[3]);
                case "filter by price":
                    if (commandParts.Length == 7)
                    {
                        return this.FilterByPriceRange(decimal.Parse(commandParts[4]), decimal.Parse(commandParts[6]));
                    }
                    else
                    {
                        if (commandParts[3] == "from")
                        {
                            return this.FilterByPriceFrom(decimal.Parse(commandParts[4]));
                        }
                        else
                        {
                            return this.FilterByPriceTo(decimal.Parse(commandParts[4]));
                        }
                    }
                case "End":
                    return "End";
                default:
                    return "Invalid command";
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }
            if (result == 0)
            {
                result = this.Type.CompareTo(other.Type);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1:G29})", this.Name, this.Price);
        }
    }

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
        /// Appends a new value to the collection of values mapped to the specified
        /// dictionary key. If the collection does not exist for the specified key,
        /// a new empty collection is first created and mapped to this key.
        /// </summary>
        /// <param name="key">The key that holds a collection of values</param>
        /// <param name="value">The value to be added to the collection for this key</param>
        public static void AppendValueToKey<TKey, TCollection, TValue>(
            this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            TCollection collection;
            if (!dict.TryGetValue(key, out collection))
            {
                collection = new TCollection();
                dict.Add(key, collection);
            }

            collection.Add(value);
        }

        /// <summary>
        /// Get a sequence of values assigned to the specified dictionary key.
        /// If the key is missng, an empty sequence is returned.
        /// </summary>
        public static IEnumerable<TValue> GetValuesForKey<TKey, TValue>(
            this IDictionary<TKey, SortedSet<TValue>> dict, TKey key)
        {
            SortedSet<TValue> collection;
            if (dict.TryGetValue(key, out collection))
            {
                return collection;
            }

            return Enumerable.Empty<TValue>();
        }
    }
}
