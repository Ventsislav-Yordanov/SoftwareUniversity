namespace News.Data
{
    using System.Data.Entity;

    using News.Entities;
    using News.Data.Migrations;

    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("NewsDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public IDbSet<New> News { get; set; }
    }
}
