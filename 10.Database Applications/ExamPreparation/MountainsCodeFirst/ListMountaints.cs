
namespace MountainsCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using MountainsCodeFirst.Migrations;

    public class ListMountaints
    {
        static void Main()
        {
            //Database.SetInitializer
            //    (new MigrateDatabaseToLatestVersion<MountainsContext, MountainsDatabaseMigrationConfiguration>());

            var context = new MountainsContext();
            var mountains = context.Mountains.Select(m => new 
            {
                m.Name,
                Countries = m.Countries.Select(c => c.Name),
                Peaks = m.Peaks.Select(p => new { p.Name, p.Elevation })
            });
            foreach (var mountain in mountains)
            {
                Console.WriteLine("Mountain: {0}, Countries: {1}, Peaks: {2}",
                    mountain.Name,
                     string.Join(", ", mountain.Countries),
                     string.Join(", ", mountain.Peaks));
            }
        }
    }
}
