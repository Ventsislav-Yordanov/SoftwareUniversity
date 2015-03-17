namespace ConcurrentUpdates
{
    using System;
    using System.Linq;

    using News.Data;

    public class ConcurrentUpdatesClass
    {
        public static void MakeUpdate()
        {
            var context = new NewsDbContext();
            var firstNew = context.News.FirstOrDefault();

            Console.WriteLine("Text from DB: {0}", firstNew.Content);
            Console.WriteLine("Enter the corrected text:");

            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    string userInput = Console.ReadLine();

                    firstNew.Content = userInput;
                    context.SaveChanges();
                    dbContextTransaction.Commit();

                    Console.WriteLine("Changes successfully saved in the DB.");
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    Console.WriteLine("Conflict!");

                    MakeUpdate();
                }
            }
        }
    }
}
