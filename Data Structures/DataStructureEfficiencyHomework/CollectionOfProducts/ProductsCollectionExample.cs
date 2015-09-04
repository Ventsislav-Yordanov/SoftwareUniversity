namespace CollectionOfProducts
{
    public class ProductsCollectionExample
    {
        public static void Main()
        {
            var products = new ProductsCollection();
            products.Add(11, "Audi", "Gecata", 7600m);
            products.Add(1, "Audi", "Pesho", 7600m);
            products.Add(2, "Audi", "Mitko", 12000m);
            products.Add(2, "Audi", "ЖЛЪЧКАТА", 13000m);
            products.Add(3, "Lada", "Gosho", 1400m);
            products.Add(4, "Mercedes", "Gosho", 3400m);
            products.Add(5, "Mercedes", "Another Gosho", 3400m);
            products.Add(6, "Bentley", "Pesho", 25999m);
            products.Add(7, "Low-end Porsche", "Pesho", 25999m);
            products.Add(8, "High-end Porsche", "Pesho", 250999m);

            var audiCars = products.FindByTitle("Audi2");
            var productsAudiPrice7600 = products.FindByTitleAndPrice("Audi", 7600m);
            var productByPriceRange = products.FindByPriceRange(7600m, 25000m);

            for (int id = 0; id < 9; id++)
            {
                products.Remove(id);
            }
        }
    }
}
