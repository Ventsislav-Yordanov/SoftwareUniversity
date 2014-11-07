namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class Apartment : BuildingEstate, IApartment
    {
        public Apartment()
        {
            this.Type = EstateType.Apartment;
        }
    }
}
