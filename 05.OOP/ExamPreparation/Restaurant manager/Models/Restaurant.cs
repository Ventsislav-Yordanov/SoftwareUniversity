using RestaurantManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private IList<IRecipe> recipes;

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.Recipes = new List<IRecipe>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return this.recipes;
            }
            set
            {
                this.recipes = value;
            }
        }

        public void AddRecipe(IRecipe recipe)
        {
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0} {1} - {2} {0}", new string('*', 5), this.Name, this.Location).AppendLine();
            if (this.Recipes.Count == 0)
            {
                result.Append("No recipes... yet");
            }
            else
            {
                var menu = new List<string>();

                var drinks = this.Recipes.Where(r => r is IDrink);
                AppendRecipesToMenu(menu, "DRINKS", drinks);

                var salads = this.Recipes.Where(r => r is ISalad);
                AppendRecipesToMenu(menu, "SALADS", salads);

                var mainCourses = this.Recipes.Where(r => r is IMainCourse);
                AppendRecipesToMenu(menu, "MAIN COURSES", mainCourses);

                var desserts = this.Recipes.Where(r => r is IDessert);
                AppendRecipesToMenu(menu, "DESSERTS", desserts);

                result.Append(string.Join(Environment.NewLine, menu));
            }

            return result.ToString();
        }

        private void AppendRecipesToMenu(List<string> menu, string title, IEnumerable<IRecipe> recipes)
        {
            if (recipes.Any())
            {
                var sortedRecipes = recipes.OrderBy(r => r.Name);
                var recipeStr = string.Format("{0} {1} {0}{2}{3}",
                    new string('~', 5),
                    title,
                    Environment.NewLine,
                    string.Join(Environment.NewLine, sortedRecipes));
                menu.Add(recipeStr);
            }
        }
    }
}
