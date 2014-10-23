using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private const int RegistrationNumberLength = 10;
        private string name;
        private string registrationNumber;
        private List<IFurniture> furnitures = new List<IFurniture>();

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name
        {
            get 
            {
                return this.name;
            }

            private set
            {
                Validators.AssertNotEmpty(value, "Name");
                Validators.AssertStringSize(value, 5, "Name");

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value.Length != RegistrationNumberLength)
                {
                    throw new ArgumentOutOfRangeException("RegistrationNumber must be with exactly 10 characters");
                }

                if (value.Any(ch => !char.IsDigit(ch)))
                {
                    throw new ArgumentException("RegistrationNumber", "All character must be number!");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            // Finding furniture by model gets the first occurrence. 
            // If such is not found, return null. Searching is case insensitive.
            return this.furnitures
                .Where(furniture => furniture.Model.ToLowerInvariant() == model.ToLowerInvariant())
                .FirstOrDefault();
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();

            string catalogHeader = string.Format("{0} - {1} - {2} {3}",
            this.Name,
            this.RegistrationNumber,
            this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
            this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            catalog.Append(catalogHeader);

            var sortedFurnitures = this.furnitures
                .OrderBy(furniture => furniture.Price)
                .ThenBy(furniture => furniture.Model);

            foreach (var furniture in sortedFurnitures)
            {
                catalog.AppendLine();
                string furnitureString = furniture.ToString();
                catalog.Append(furnitureString);
            }

            return catalog.ToString();
        }
    }
}
