namespace Estates.Data
{
    using System;
    using Estates.Interfaces;

    public class Office : BuildingEstate, IOffice
    {
        public Office()
        {
            this.Type = EstateType.Office;
        }
    }
}
