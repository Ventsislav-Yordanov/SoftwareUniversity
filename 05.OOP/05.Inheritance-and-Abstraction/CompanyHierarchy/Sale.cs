namespace CompanyHierarchy
{
    using System;
    public class Sale : ISale
    {
        private string productName;
        private DateTime saleDate;
        private decimal price;

        public Sale(string productName, DateTime saleDate, decimal price)
        {
            this.ProductName = productName;
            this.SaleDate = saleDate;
            this.Price = price;
        }


        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative!");
                }

                this.price = value;
            }
        }

        public DateTime SaleDate
        {
            get { return this.saleDate; }
            set { this.saleDate = value; }
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ProductName cannot be null!");
                }

                this.productName = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Product Name : {0}, Sale Date {1:dd.MM.yyyy}, Price : {2:F2}",
                this.ProductName,
                this.SaleDate,
                this.Price);
        }
    }
}