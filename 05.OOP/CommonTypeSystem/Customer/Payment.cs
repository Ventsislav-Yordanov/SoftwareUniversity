namespace Customer
{
    using System;
    using System.Text;
    public class Payment : ICloneable
    {
        private string productName;
        private decimal price;

        public Payment(string productName, decimal price)
        {
            this.ProductName = productName;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("ProductName cannot be null or empty!");
                }

                this.productName = value;
            }
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

        public object Clone()
        {
            Payment paymentClone = this.MemberwiseClone() as Payment;
            if (paymentClone == null)
            {
                throw new ArgumentNullException("The cloned object cannot be casted as payment type!");
            }

            return paymentClone;
        }

        public override string ToString()
        {
            StringBuilder paymentToString = new StringBuilder("");
            paymentToString.AppendLine(string.Format("[ name: {0}, price: {1} ]", this.ProductName, this.Price));
            return paymentToString.ToString();
        }
    }
}
