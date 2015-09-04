namespace CollectionOfProducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;
    using CompositeKey = System.Tuple<string, decimal>;

    public class ProductsCollection : IProductsCollection
    {
        private Dictionary<int, Product> productsById;
        private OrderedMultiDictionary<decimal, Product> productsByPriceRange;
        private Dictionary<string, SortedSet<Product>> productsByTitle;
        private Dictionary<CompositeKey, SortedSet<Product>> productsByTitleAndPrice;
        private Dictionary<string, OrderedMultiDictionary<decimal, Product>> productsByTitleAndPriceRange;
        private Dictionary<CompositeKey, SortedSet<Product>> productsBySupplierAndPrice;
        private Dictionary<string, OrderedMultiDictionary<decimal, Product>> productsBySupplierAndPriceRange;

        public ProductsCollection()
        {
            this.productsById = new Dictionary<int, Product>();
            this.productsByPriceRange = new OrderedMultiDictionary<decimal, Product>(false);
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.productsByTitleAndPriceRange = new Dictionary<string, OrderedMultiDictionary<decimal, Product>>();
            this.productsBySupplierAndPrice = new Dictionary<Tuple<string, decimal>, SortedSet<Product>>();
            this.productsBySupplierAndPriceRange = new Dictionary<string, OrderedMultiDictionary<decimal, Product>>();
        }

        public void Add(int id, string title, string supplier, decimal price)
        {
            var newProduct = new Product(id, title, supplier, price);
            var titlePriceKey = GenerateCompositeKey(title, price);
            var supplierPriceKey = GenerateCompositeKey(supplier, price);

            if (!this.productsById.ContainsKey(id))
            {
                this.AddNewProduct(id, title, supplier, price, newProduct, titlePriceKey, supplierPriceKey);
            }
            else
            {
                this.UpdateExistingProduct(id, title, supplier, price, newProduct, titlePriceKey, supplierPriceKey);
            }
        }

        public bool Remove(int id)
        {
            if (!this.productsById.ContainsKey(id))
            {
                return false;
            }
            else
            {
                var existingProduct = this.productsById[id];
                this.productsById.Remove(id);
                this.productsByPriceRange[existingProduct.Price].Remove(existingProduct);
                this.productsByTitle[existingProduct.Title].Remove(existingProduct);
                var titlePriceKey = GenerateCompositeKey(existingProduct.Title, existingProduct.Price);
                this.productsByTitleAndPrice[titlePriceKey].Remove(existingProduct);
                this.productsByTitleAndPriceRange[existingProduct.Title][existingProduct.Price].Remove(existingProduct);
                var supplierPriceKey = GenerateCompositeKey(existingProduct.Supplier, existingProduct.Price);
                this.productsBySupplierAndPrice[supplierPriceKey].Remove(existingProduct);
                this.productsBySupplierAndPriceRange[existingProduct.Supplier][existingProduct.Price].Remove(existingProduct);
                return true;
            }
        }

        public ICollection<Product> FindByTitle(string title)
        {
            if (!this.productsByTitle.ContainsKey(title))
            {
                return new List<Product>();
            }

            return this.productsByTitle[title];
        }

        public ICollection<Product> FindByPriceRange(decimal startPrice, decimal endPrice)
        {
            var products = this.productsByPriceRange
                .Range(startPrice, true, endPrice, true)
                .Values;

            return products;
        }

        public ICollection<Product> FindByTitleAndPrice(string title, decimal price)
        {
            var titlePriceKey = GenerateCompositeKey(title, price);
            if (!this.productsByTitleAndPrice.ContainsKey(titlePriceKey))
            {
                return new List<Product>();
            }

            return this.productsByTitleAndPrice[titlePriceKey];
        }

        public ICollection<Product> FindByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice)
        {
            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                return new List<Product>();
            }

            var products = this.productsByTitleAndPriceRange[title]
                .Range(startPrice, true, endPrice, true)
                .Values;
            return products;
        }

        public ICollection<Product> FindBySupplierAndPrice(string supplier, decimal price)
        {
            var supplierPriceKey = GenerateCompositeKey(supplier, price);
            if (!this.productsBySupplierAndPrice.ContainsKey(supplierPriceKey))
            {
                return new List<Product>();
            }

            return this.productsBySupplierAndPrice[supplierPriceKey];
        }

        public ICollection<Product> FindBySupplierAndPriceRange(string supplier, decimal startPrice, decimal endPrice)
        {
            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                return new List<Product>();
            }

            var products = this.productsBySupplierAndPriceRange[supplier]
                .Range(startPrice, true, endPrice, true)
                .Values;
            return products;
        }

        private static CompositeKey GenerateCompositeKey(string key, decimal price)
        {
            return new CompositeKey(key, price);
        }

        private void AddNewProduct(
            int id, string title, string supplier, decimal price,
            Product newProduct, CompositeKey titlePriceKey, CompositeKey supplierPriceKey)
        {
            this.productsById.Add(id, newProduct);

            this.productsByPriceRange.Add(price, newProduct);

            this.productsByTitle.EnsureKeyExists(title);
            this.productsByTitle[title].Add(newProduct);

            this.productsByTitleAndPrice.EnsureKeyExists(titlePriceKey);
            this.productsByTitleAndPrice[titlePriceKey].Add(newProduct);

            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                this.productsByTitleAndPriceRange[title] = new OrderedMultiDictionary<decimal, Product>(false);
            }

            this.productsByTitleAndPriceRange[title][price].Add(newProduct);

            this.productsBySupplierAndPrice.EnsureKeyExists(supplierPriceKey);
            this.productsBySupplierAndPrice[supplierPriceKey].Add(newProduct);

            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                this.productsBySupplierAndPriceRange[supplier] = new OrderedMultiDictionary<decimal, Product>(false);
            }

            this.productsBySupplierAndPriceRange[supplier][price].Add(newProduct);
        }

        private void UpdateExistingProduct(
            int id, string title, string supplier, decimal price,
            Product newProduct, CompositeKey titlePriceKey, CompositeKey supplierPriceKey)
        {
            var existingProduct = this.productsById[id];

            this.productsById.Remove(id);
            this.productsById[newProduct.Id] = newProduct;

            this.productsByPriceRange.UpdateValue(existingProduct.Price, newProduct.Price, existingProduct, newProduct);

            this.productsByTitle[existingProduct.Title].Remove(existingProduct);
            this.productsByTitle.EnsureKeyExists(newProduct.Title);
            this.productsByTitle[newProduct.Title].Add(newProduct);

            var oldTitlePriceKey = GenerateCompositeKey(existingProduct.Title, existingProduct.Price);
            var newTitlePriceKey = GenerateCompositeKey(newProduct.Title, newProduct.Price);
            this.productsByTitleAndPrice[oldTitlePriceKey].Remove(existingProduct);
            this.productsByTitleAndPrice.EnsureKeyExists(newTitlePriceKey);
            this.productsByTitleAndPrice[newTitlePriceKey].Add(newProduct);

            this.productsByTitleAndPriceRange[existingProduct.Title][existingProduct.Price].Remove(existingProduct);
            if (!this.productsByTitleAndPriceRange.ContainsKey(title))
            {
                this.productsByTitleAndPriceRange[title] = new OrderedMultiDictionary<decimal, Product>(false);
            }

            this.productsByTitleAndPriceRange[title][price].Add(newProduct);

            var oldSupplierPriceKey = GenerateCompositeKey(existingProduct.Supplier, existingProduct.Price);
            var newSupplierPriceKey = GenerateCompositeKey(newProduct.Supplier, newProduct.Price);
            this.productsBySupplierAndPrice[oldSupplierPriceKey].Remove(existingProduct);
            this.productsBySupplierAndPrice.EnsureKeyExists(newSupplierPriceKey);
            this.productsBySupplierAndPrice[newSupplierPriceKey].Add(newProduct);

            if (!this.productsBySupplierAndPriceRange.ContainsKey(supplier))
            {
                this.productsBySupplierAndPriceRange[supplier] = new OrderedMultiDictionary<decimal, Product>(false);
            }

            this.productsBySupplierAndPriceRange[existingProduct.Supplier][existingProduct.Price].Remove(existingProduct);
            this.productsBySupplierAndPriceRange[supplier][price].Add(newProduct);
        }
    }
}
