namespace CollectionOfProducts
{
    using System.Collections.Generic;

    public interface IProductsCollection
    {
        void Add(int id, string title, string supplier, decimal price);

        bool Remove(int id);

        ICollection<Product> FindByPriceRange(decimal startPrice, decimal endPrice);

        ICollection<Product> FindByTitle(string title);

        ICollection<Product> FindByTitleAndPrice(string title, decimal price);

        ICollection<Product> FindByTitleAndPriceRange(string title, decimal startPrice, decimal endPrice);

        ICollection<Product> FindBySupplierAndPrice(string supplier, decimal price);

        ICollection<Product> FindBySupplierAndPriceRange(string supplier, decimal startPrice, decimal endPrice);
    }
}
