using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Models
{
    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get
            {
                return this.articles;
            }
            set
            {
                this.articles = value;
            }
        }

        public void AddArticle(IArticle article)
        {
            this.articles.Add(article);
        }

        public void RemoveArticle(IArticle article) 
        {
            this.articles.Remove(article);
        }

        public string ListArticles()
        {
            var result = new StringBuilder();
            result.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name).AppendLine();
            if (this.Articles.Count == 0)
            {
                result.Append("The shop is empty. Come back soon.");
            }
            else
            {
                var menu = new List<string>();

                var microphones = this.Articles.Where(a => a is IMicrophone);
                AppendArticlesToMenu(menu, "Microphones", microphones);

                var drums = this.Articles.Where(a => a is IDrums);
                AppendArticlesToMenu(menu, "Drums", drums);

                var electricGuitars = this.Articles.Where(a => a is IElectricGuitar);
                AppendArticlesToMenu(menu, "Electric guitars", electricGuitars);

                var acousticGuitars = this.Articles.Where(a => a is IAcousticGuitar);
                AppendArticlesToMenu(menu, "Acoustic guitars", acousticGuitars);

                var bassGuitars = this.Articles.Where(a => a is IBassGuitar);
                AppendArticlesToMenu(menu, "Bass guitars", bassGuitars);

                result.Append(string.Join(Environment.NewLine, menu));
            }

            return result.ToString();
        }

        private void AppendArticlesToMenu(List<string> menu, string title, IEnumerable<IArticle> articles)
        {
            if (articles.Any())
            {
                var sortedArticles = articles.OrderBy(a => a.Make).ThenBy(a =>a.Model); // marka - model
                var recipeStr = string.Format("{0} {1} {0}{2}{3}",
                    new string('-', 5),
                    title,
                    Environment.NewLine,
                    string.Join(Environment.NewLine, sortedArticles));
                menu.Add(recipeStr);
            }
        }
    }
}
