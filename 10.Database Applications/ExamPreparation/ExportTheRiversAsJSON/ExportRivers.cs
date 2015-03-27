namespace ExportTheRiversAsJSON
{
    using System;
    using System.Linq;
    using System.Web.Script.Serialization;

    using Geography.Entities;
    using System.IO;

    public class ExportRivers
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries
                                .OrderBy(c => c.CountryName)
                                .Select(c => c.CountryName)
                })
                .ToList();
            var jsSerializer = new JavaScriptSerializer();
            var riversJson = jsSerializer.Serialize(rivers);
            File.WriteAllText("../../rivers.json", riversJson);
            Console.WriteLine("Rivers exported");
        }
    }
}
