namespace ShowDataFromRelatedTables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;

    using Ads.Entities;

    public class ShowDataFromRelatedTables
    {
        static void Main()
        {
            var context = new AdsEntities();

            //Console.WriteLine("List ads (with N+1 query problem):");
            //foreach (var ad in context.Ads)
            //{
            //    Console.WriteLine("Title: " + ad.Title + ", Status: " + ad.AdStatus.Status +
            //                      ", Category: " + (ad.Category == null ? "(no category)" : ad.Category.Name) +
            //                      ", Town: " + (ad.Town == null ? "(no town)" : ad.Town.Name) +
            //                      ", User: " + ad.AspNetUser.Name);
            //}

            Console.WriteLine("List ads (without N+1 query problem):");
            foreach (var ad in context.Ads.Include(a => a.AdStatus)
                                          .Include(a => a.Category)
                                          .Include(a => a.Town)
                                          .Include(a => a.AspNetUser))
            {
                Console.WriteLine("Title: " + ad.Title + ", Status: " + ad.AdStatus.Status +
                                  ", Category: " + (ad.Category == null ? "(no category)" : ad.Category.Name) +
                                  ", Town: " + (ad.Town == null ? "(no town)" : ad.Town.Name) +
                                  ", User: " + ad.AspNetUser.Name);
            }
        }
    }
}
