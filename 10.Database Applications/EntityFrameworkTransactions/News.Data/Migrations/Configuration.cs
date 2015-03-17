namespace News.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using News.Entities;

    public sealed class Configuration : DbMigrationsConfiguration<NewsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "News.Data.NewsDbContext";
        }

        protected override void Seed(NewsDbContext context)
        {
            if (context.News.Any())
            {
                return;
            }

            var defautNew = new New
            {
                Content = "Default New"
            };

            context.News.Add(defautNew);
        }
    }
}
