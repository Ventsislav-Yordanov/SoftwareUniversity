namespace CollectionOfProducts.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;

    // Replace when id is same (id = 2) ✔
    // All results must be ordered by id (id = 1 is before id = 11, etc.) ✔
    // Many products with the same title (id = 1, 2, 11) ✔
    // Many products with the same price (id = 1, 11) ✔
    // Many products with the same supplier (id = 6, 7, 8) ✔
    // Many products with the same title + price (id = 4, 5) ✔
    // Many products with the same title + price range ✔
    // Many products with the same supplier + price (id = 6, 7) ✔
    // Many products with the same supplier + price range (id = 6, 7) ✔
    [TestClass]
    public class CollectionOfProductsUnitTests
    {
        private IProductsCollection products;

        [TestInitialize]
        public void SeedProductCollection()
        {
            this.products = new ProductsCollection();
            products.Add(11, "Audi", "Gecata", 7600m);
            products.Add(1, "Audi", "Pesho", 7600m);
            products.Add(2, "Audi", "Mitko", 12000m);
            products.Add(2, "Audi", "ЖЛЪЧКАТА", 13000m);
            products.Add(3, "Lada", "Gosho", 1400m);
            products.Add(6, "Bentley", "Pesho", 25999m);
            products.Add(8, "High-end Porsche", "Pesho", 250999m);
            products.Add(4, "Mercedes", "Gosho", 3400m);
            products.Add(5, "Mercedes", "Another Gosho", 3400m);
            products.Add(7, "Low-end Porsche", "Pesho", 25999m);
        }

        [TestMethod]
        public void FindByTitle_WithValidTitle_ShouldReturnProductsWithProvidedTitle()
        {
            var products = this.products.FindByTitle("Audi").ToList();
            var expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m),
                new Product(2, "Audi", "ЖЛЪЧКАТА", 13000m),
                new Product(11, "Audi", "Gecata", 7600m)
            };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByTitle_WithNonExistingTitle_ShouldReturnNoProducts()
        {
            var products = this.products.FindByTitle("Invalid").ToList();
            var expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByTitleAndPrice_WithValidTitleAndPrice_ShouldReturnProductsWithProvidedTitleAndPrice()
        {
            var products = this.products.FindByTitleAndPrice("Audi", 7600m).ToList();
            var expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m),
                new Product(11, "Audi", "Gecata", 7600m)
            };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByTitleAndPrice_WithNonExistingTitleAndPrice_ShouldReturnNoProducts()
        {
            var products = this.products.FindByTitleAndPrice("Invalid", 7600m).ToList();
            var expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindByTitleAndPrice("Audi", 76000m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindByTitleAndPrice("Trabant :D", 7m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByTitleAndPriceRange_WithValidTitleAndPriceRange_ShouldReturnProductsWithProvidedTitleAndPriceRange()
        {
            var products = this.products.FindByTitleAndPriceRange("Audi", 7600m, 7600m).ToList();
            var expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m),
                new Product(11, "Audi", "Gecata", 7600m)
            };

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindByTitleAndPriceRange("Audi", 7600m, 13000m).ToList();
            expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m),
                new Product(11, "Audi", "Gecata", 7600m),
                new Product(2, "Audi", "ЖЛЪЧКАТА", 13000m)
            };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByTitleAndPriceRange_WithNonExistingTitleAndPriceRange_ShouldReturnNoProducts()
        {
            var products = this.products.FindByTitleAndPriceRange("Invalid", 7600m, 8000m).ToList();
            var expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindByTitleAndPriceRange("Audi2", 76m, 2650m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindByTitleAndPriceRange("Trabant :D", 7m, 9m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByPriceRange_WithValidPriceRange_ShouldReturnProductsWithProvidedPriceRange()
        {
            var products = this.products.FindByPriceRange(7600m, 25999m).ToList();
            var expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m),
                new Product(11, "Audi", "Gecata", 7600m),
                new Product(2, "Audi", "ЖЛЪЧКАТА", 13000m),
                new Product(6, "Bentley", "Pesho", 25999m),
                new Product(7, "Low-end Porsche", "Pesho", 25999m)
        };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindByPriceRange_WithInValidPriceRange_ShouldReturnNoProducts()
        {
            var products = this.products.FindByPriceRange(0m, 1m).ToList();
            var expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindBySupplierAndPrice_WithValidSupplierAndPrice_ShouldReturnProductsWithProvidedSupplierAndPrice()
        {
            var products = this.products.FindBySupplierAndPrice("Pesho", 7600m).ToList();
            var expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m)
            };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindBySupplierAndPrice_WithInvalidSupplierAndPrice_ShouldReturnNoProducts()
        {
            var products = this.products.FindBySupplierAndPrice("Pesho666", 7600m).ToList();
            var expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindBySupplierAndPrice("Pesho", 16m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindBySupplierAndPrice("aaaaa", 13m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindBySupplierAndPriceRange_WithValidSupplierAndPriceRange_ShouldReturnProductsWithProvidedSupplierAndPriceRange()
        {
            var products = this.products.FindBySupplierAndPriceRange("Pesho", 7600m, 30000m).ToList();
            var expectedProducts = new List<Product>()
            {
                new Product(1, "Audi", "Pesho", 7600m),
                new Product(6, "Bentley", "Pesho", 25999m),
                new Product(7, "Low-end Porsche", "Pesho", 25999m)
            };

            CollectionAssert.AreEqual(expectedProducts, products);
        }

        [TestMethod]
        public void FindBySupplierAndPriceRange_WithInvalidSupplierAndPriceRange_ShouldReturnNoProducts()
        {
            var products = this.products.FindBySupplierAndPriceRange("Pesho666", 7600m, 30000m).ToList();
            var expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindBySupplierAndPriceRange("Pesho", 16m, 18m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);

            products = this.products.FindBySupplierAndPriceRange("aaaaa", 16m, 18m).ToList();
            expectedProducts = new List<Product>();

            CollectionAssert.AreEqual(expectedProducts, products);
        }
    }
}
