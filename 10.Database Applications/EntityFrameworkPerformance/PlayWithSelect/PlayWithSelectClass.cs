namespace PlayWithSelect
{
    using System;
    using System.Linq;

    using Ads.Entities;

    public class PlayWithSelectClass
    {
        static void Main()
        {
            var context = new AdsEntities();
            //var adsColumns = context.Ads;
            //foreach (var ad in adsColumns)
            //{
            //    Console.WriteLine("Title: {0}", ad.Title);
            //}

            var adsTitles = context.Ads.Select(a => a.Title);
            foreach (var title in adsTitles)
            {
                Console.WriteLine("Title: {0}", title);
            }
        }
    }
}
