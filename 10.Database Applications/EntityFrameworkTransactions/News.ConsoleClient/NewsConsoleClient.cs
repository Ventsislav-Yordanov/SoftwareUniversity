namespace News.ConsoleClient
{
    using System;
    using System.Linq;

    using News.Data;
    using News.Entities;
    using ConcurrentUpdates;

    public class NewsConsoleClient
    {
        static void Main()
        {
            var dbContext = new NewsDbContext();

            // Activating database
            Console.WriteLine("Connecting to database ...");
            dbContext.News.Count();

            Console.WriteLine("Application started.");
            ConcurrentUpdatesClass.MakeUpdate(); 
            //var db = new NewsDbContext();
            //var newForInsert = new New
            //{
            //    Content = "Днеска беше ограбена банка"
            //};

            //db.News.Add(newForInsert);
            //db.SaveChanges();

            //var savedNew = db.News.First();

            //Console.WriteLine("{0} {1}", savedNew.Id, savedNew.Content);
        }
    }
}
