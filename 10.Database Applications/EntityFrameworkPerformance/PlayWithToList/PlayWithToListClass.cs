namespace PlayWithToList
{
    using System;
    using System.Linq;

    using Ads.Entities;

    public class PlayWithToListClass
    {
        static void Main()
        {
            var context = new AdsEntities();
            var getAdsSlow = context.Ads
                .ToList()
                .Where(a => a.AdStatus.Status == "Published")
                .OrderBy(a => a.Date)
                .Select(a =>
                    new
                    {
                        Title = a.Title,
                        Category = a.Category,
                        Town = a.Town
                    }
                )
                .ToList();

            foreach (var ad in getAdsSlow)
            {
                Console.WriteLine("Title: {0}, Category: {1}, Town: {2}",
                    ad.Title,
                    (ad.Category == null ? "(no category)" : ad.Category.Name),
                    (ad.Town == null ? "(no town)" : ad.Town.Name));
            }

            //var getAdsFast = context.Ads
            //    .Where(a => a.AdStatus.Status == "Published")
            //    .OrderBy(a => a.Date)
            //    .Select(a =>
            //        new
            //        {
            //            Title = a.Title,
            //            Category = a.Category,
            //            Town = a.Town
            //        }
            //    ).ToList();

            //foreach (var ad in getAdsFast)
            //{
            //    Console.WriteLine("Title: {0}, Category: {1}, Town: {2}",
            //        ad.Title,
            //        (ad.Category == null ? "(no category)" : ad.Category.Name),
            //        (ad.Town == null ? "(no town)" : ad.Town.Name));
            //}
        }
    }
}
