namespace Estates.Data
{
    using Estates.Interfaces;

    class RentOffer : Offer, IRentOffer
    {
        public RentOffer()
        {
            this.Type = OfferType.Rent;
        }

        public decimal PricePerMonth
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
