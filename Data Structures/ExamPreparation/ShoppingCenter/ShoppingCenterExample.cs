namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class ShoppingCenterExample
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var center = new ShoppingCenterFast();

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string command = Console.ReadLine();
                string commandResult = center.ProcessCommand(command);
                Console.WriteLine(commandResult);
            }
        }
    }

    public class Product : IComparable<Product>
    {
        public Product(string name, decimal price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            int result = this.Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = this.Producer.CompareTo(other.Producer);
            }

            if (result == 0)
            {
                result = this.Price.CompareTo(other.Price);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }

    public class ShoppingCenterFast
    {
        private const string NoProductsFound = "No products found";
        private const string ProductAdded = "Product added";
        private const string ProductsDeleted = " products deleted";
        private const string IncorrectCommand = "Incorrect command";

        private Dictionary<string, OrderedBag<Product>> productsByProducer = new Dictionary<string, OrderedBag<Product>>();
        private Dictionary<Tuple<string, string>, OrderedBag<Product>> productsByProducerAndName =
            new Dictionary<Tuple<string, string>, OrderedBag<Product>>();

        private Dictionary<string, OrderedBag<Product>> productsByName = new Dictionary<string, OrderedBag<Product>>();
        private OrderedDictionary<decimal, OrderedBag<Product>> productsByPrice =
            new OrderedDictionary<decimal, OrderedBag<Product>>();

        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parametersString = command.Substring(indexOfFirstSpace + 1);
            string[] parameters = parametersString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            switch (method)
            {
                case "AddProduct":
                    return this.AddProduct(parameters[0], decimal.Parse(parameters[1]), parameters[2]);
                case "DeleteProducts":
                    if (parameters.Length <= 1)
                    {
                        return this.DeleteProducts(parameters[0]);
                    }
                    else
                    {
                        return this.DeleteProducts(parameters[0], parameters[1]);
                    }

                case "FindProductsByName":
                    return this.FindProductsByName(parameters[0]);
                case "FindProductsByProducer":
                    return this.FindProductsByProducer(parameters[0]);
                case "FindProductsByPriceRange":
                    return this.FindProductsByPriceRange(decimal.Parse(parameters[0]), decimal.Parse(parameters[1]));
                default:
                    return IncorrectCommand;
            }
        }

        public string AddProduct(string name, decimal price, string producer)
        {
            var newProduct = new Product(name, price, producer);

            this.productsByProducer.EnsureKeyExists(producer);
            this.productsByProducer.AppendValueToKey(producer, newProduct);

            var producerAndNameKey = this.GenerateProducerAndNameKey(producer, name);
            this.productsByProducerAndName.EnsureKeyExists(producerAndNameKey);
            this.productsByProducerAndName.AppendValueToKey(producerAndNameKey, newProduct);

            this.productsByName.EnsureKeyExists(name);
            this.productsByName.AppendValueToKey(name, newProduct);

            this.productsByPrice.EnsureKeyExists(price);
            this.productsByPrice.AppendValueToKey(price, newProduct);

            return ProductAdded;
        }

        public string DeleteProducts(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var products = this.productsByProducer[producer];
                foreach (var product in products)
                {
                    var producerAndNameKey = this.GenerateProducerAndNameKey(product.Producer, product.Name);
                    this.productsByProducerAndName.Remove(producerAndNameKey);
                    this.productsByName[product.Name].Remove(product);
                    this.productsByPrice[product.Price].Remove(product);
                }

                this.productsByProducer.Remove(producer);
                return products.Count + ProductsDeleted;
            }

            return NoProductsFound;
        }

        public string DeleteProducts(string name, string producer)
        {
            var producerAndNameKey = this.GenerateProducerAndNameKey(producer, name);
            if (this.productsByProducerAndName.ContainsKey(producerAndNameKey))
            {
                var products = this.productsByProducerAndName[producerAndNameKey];
                foreach (var product in products)
                {
                    this.productsByName[product.Name].Remove(product);
                    this.productsByProducer[product.Producer].Remove(product);
                    this.productsByPrice[product.Price].Remove(product);
                }

                this.productsByProducerAndName.Remove(producerAndNameKey);

                return products.Count + ProductsDeleted;
            }

            return NoProductsFound;
        }

        public string FindProductsByName(string name)
        {
            if (this.productsByName.ContainsKey(name))
            {
                var products = this.productsByName[name];
                if (products == null || products.Count == 0)
                {
                    return NoProductsFound;
                }

                var result = string.Join(Environment.NewLine, products);
                return result.Trim();
            }

            return NoProductsFound;
        }

        public string FindProductsByProducer(string producer)
        {
            if (this.productsByProducer.ContainsKey(producer))
            {
                var products = this.productsByProducer[producer];
                if (products.Count == 0 || products == null)
                {
                    return NoProductsFound;
                }

                var result = string.Join(Environment.NewLine, products);
                return result.Trim();
            }

            return NoProductsFound;
        }

        public string FindProductsByPriceRange(decimal startPrice, decimal endPrice)
        {
            var productsInRange = this.productsByPrice.Range(startPrice, true, endPrice, true);
            if (productsInRange.Count > 0)
            {
                var products = new List<Product>();
                foreach (var productInRange in productsInRange)
                {
                    foreach (var product in productInRange.Value)
                    {
                        products.Add(product);
                    }
                }

                if (!products.Any())
                {
                    return NoProductsFound;
                }

                var resultProducts = products
                    .OrderBy(p => p.Name)
                    .ThenBy(p => p.Producer)
                    .ThenBy(p => p.Price);

                var result = string.Join(Environment.NewLine, resultProducts);
                return result.ToString().Trim();
            }

            return NoProductsFound;
        }

        private Tuple<string, string> GenerateProducerAndNameKey(string producer, string name)
        {
            var tuple = new Tuple<string, string>(producer, name);
            return tuple;
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
        /// dictionary key. If the collection does not exists for the specified key,
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