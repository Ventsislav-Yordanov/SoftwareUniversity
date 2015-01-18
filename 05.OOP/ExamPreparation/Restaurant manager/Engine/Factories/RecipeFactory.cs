namespace RestaurantManager.Engine.Factories
{
    using System;
    using RestaurantManager.Interfaces;
    using RestaurantManager.Interfaces.Engine;
    using RestaurantManager.Models;

    public class RecipeFactory : IRecipeFactory
    {
        public IDrink CreateDrink(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isCarbonated)
        {
            var drink = new Drink(name, price, calories, quantityPerServing, MetricUnit.Milliliters, timeToPrepare, isCarbonated);

            return drink;
        }

        public ISalad CreateSalad(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool containsPasta)
        {
            var salad = new Salad(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, true, containsPasta);

            return salad;
        }


        // string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type
        public IMainCourse CreateMainCourse(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan, string type)
        {
            MainCourseType courseType = GetMainCourseType(type);
            var mainCourse = new MainCourse(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, isVegan, courseType);

            return mainCourse;
        }

        public IDessert CreateDessert(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, bool isVegan)
        {
            var dessert = new Dessert(name, price, calories, quantityPerServing, MetricUnit.Grams, timeToPrepare, isVegan, true);

            return dessert;
        }

        public MainCourseType GetMainCourseType(string type)
        {
            MainCourseType result;
            switch (type)
            {
                case "Soup":
                    result = MainCourseType.Soup;
                    break;
                case "Entree":
                    result = MainCourseType.Entree;
                    break;
                case "Pasta":
                    result = MainCourseType.Pasta;
                    break;
                case "Side":
                    result = MainCourseType.Side;
                    break;
                case "Meat":
                    result = MainCourseType.Meat;
                    break;
                case "Other":
                    result = MainCourseType.Other;
                    break;
                default:
                    throw new Exception();
            }
            return result;
        }
    }
}
