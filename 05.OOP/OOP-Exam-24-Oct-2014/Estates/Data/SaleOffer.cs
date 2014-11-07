namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class SaleOffer : Offer, ISaleOffer
    {
        public SaleOffer()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
