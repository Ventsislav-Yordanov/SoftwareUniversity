namespace ProductsInPriceRange
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class FindProductsInPriceRange
    {
        public static void Main()
        {
            // In the FillProducts() and GetProducts() methods, there are some lines of code
            // which have been commented out. If you uncomment them, the solution will use
            // OrderedMultiDictionary<decimal, Product> instead of OrderedBad<Product>.
            // I have found that the OrderedBad<Product> solution is much faster for the
            // purposes of this problem, but I have left the two solutions for comparison
            // and performance checking

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            using (var inputReader = new StreamReader("products-search.txt"))
            {
                using (var outputWriter = new StreamWriter("products-search-output.txt"))
                {
                    Console.SetIn(inputReader);
                    Console.SetOut(outputWriter);
                    OrderedBag<Product> productsPrices = FillProducts();

                    stopwatch.Stop();
                    Console.WriteLine("Elapsed time (input): {0}", stopwatch.Elapsed);
                    int numberOfSearches = int.Parse(Console.ReadLine());

                    stopwatch.Restart();
                    for (int i = 0; i < numberOfSearches; i++)
                    {
                        string line = Console.ReadLine();
                        string[] lineParts = line.Split(' ');
                        decimal start = decimal.Parse(lineParts[0]);
                        decimal end = decimal.Parse(lineParts[1]);

                        GetProducts(productsPrices, start, end);
                    }

                    stopwatch.Stop();
                    Console.WriteLine("Elapsed time (total search): {0}", stopwatch.Elapsed);
                }
            }
        }

        private static OrderedBag<Product> FillProducts()
        {
            int numberOfProducts = int.Parse(Console.ReadLine());
            // var productsPrices = new OrderedMultiDictionary<decimal, Product>(true);
            var productsPrices = new OrderedBag<Product>();
            string line = string.Empty;
            for (int i = 0; i < numberOfProducts; i++)
            {
                line = Console.ReadLine();
                string[] lineParts = line.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                string name = lineParts[0];
                decimal price = decimal.Parse(lineParts[1]);
                var product = new Product(name, price);
                // productsPrices.Add(price, product);
                productsPrices.Add(product);
            }

            return productsPrices;
        }

        private static void GetProducts(OrderedBag<Product> productsPrices, decimal start, decimal end)
        {
            var startProduct = new Product(string.Empty, start);
            var endProduct = new Product(string.Empty, end);
            var products = productsPrices.Range(startProduct, true, endProduct, true);
            // var products = productsPrices.Range(start, true, end, true);
            Console.WriteLine("Search in range {0} - {1}:", start, end);
            string separator = new string('-', 10);
            Console.WriteLine(separator);
            if (!products.Any())
            {
                Console.WriteLine("No products found");
            }
            else
            {
                foreach (var product in products.Take(20))
                {
                    Console.WriteLine("{0} -> {1}", product.Name, product.Price);
                }
            }

            Console.WriteLine(separator);
        }
    }
}
