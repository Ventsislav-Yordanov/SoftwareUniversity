namespace FurnitureManufacturer.Engine.Factories
{
    using System;

    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class FurnitureFactory : IFurnitureFactory
    {
        private const string Wooden = "wooden";
        private const string Leather = "leather";
        private const string Plastic = "plastic";
        private const string InvalidMaterialName = "Invalid material name: {0}";

        public ITable CreateTable(string model,
            string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            MaterialType matType = GetMaterialType(materialType);
            Table table = new Table(model, matType, price, height, length, width);
            return table;
        }

        public IChair CreateChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType matType = GetMaterialType(materialType);
            Chair chair = new Chair(model, matType, price, height, numberOfLegs);
            return chair;
        }

        public IAdjustableChair CreateAdjustableChair(string model,
            string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType matType = GetMaterialType(materialType);
            AdjustableChair chair = new AdjustableChair(model, matType, price, height, numberOfLegs);
            return chair;
        }

        public IConvertibleChair CreateConvertibleChair(string model
            , string materialType, decimal price, decimal height, int numberOfLegs)
        {
            MaterialType matType = GetMaterialType(materialType);
            ConvertibleChair chair = new ConvertibleChair(model, matType, price, height, numberOfLegs);
            return chair;
        }

        private MaterialType GetMaterialType(string material)
        {
            switch (material)
            {
                case Wooden:
                    return MaterialType.Wooden;
                case Leather:
                    return MaterialType.Leather;
                case Plastic:
                    return MaterialType.Plastic;
                default:
                    throw new ArgumentException(string.Format(InvalidMaterialName, material));
            }
        }
    }
}
