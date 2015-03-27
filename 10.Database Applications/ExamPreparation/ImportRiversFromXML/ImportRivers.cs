namespace ImportRiversFromXML
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using Geography.Entities;

    public class ImportRivers
    {
        static void Main()
        {
            var xmlDoc = XDocument.Load(@"../../rivers.xml");
            var riverNodes = xmlDoc.XPathSelectElements("/rivers/river");
            var context = new GeographyEntities();
            foreach (var riverNode in riverNodes)
            {
                var river = new River();
                river.RiverName = riverNode.Descendants("name").First().Value;
                river.Length = int.Parse(riverNode.Descendants("length").First().Value);
                river.Outflow = riverNode.Descendants("outflow").First().Value;
                var drainageArea = riverNode.Descendants("drainage-area").FirstOrDefault();
                if (drainageArea != null)
                {
                    river.DrainageArea = int.Parse(drainageArea.Value);
                }

                var averageDischarge = riverNode.Descendants("average-discharge").FirstOrDefault();
                if (averageDischarge != null)
                {
                    river.AverageDischarge = int.Parse(averageDischarge.Value);
                }

                // Parse the countries for the river
                var countryNodes = riverNode.XPathSelectElements("countries/country");
                foreach (var countryNode in countryNodes)
                {
                    var country = context.Countries
                        .FirstOrDefault(c => c.CountryName == countryNode.Value);
                    if (country == null)
                    {
                        throw new Exception("Cannot find country: " + countryNode.Value);
                    }
                    river.Countries.Add(country);
                }

                context.Rivers.Add(river);
                context.SaveChanges();
            }
            Console.WriteLine("Rivers imported from rivers.xml");
        }
    }
}
