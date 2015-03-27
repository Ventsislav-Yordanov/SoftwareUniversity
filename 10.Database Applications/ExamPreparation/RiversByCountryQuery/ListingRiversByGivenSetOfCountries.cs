namespace RiversByCountryQuery
{
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using Geography.Entities;

    public class ListingRiversByGivenSetOfCountries
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var riversQueryXml = XDocument.Load(@"..\..\rivers-queries.xml");
            var queryNodes = riversQueryXml.XPathSelectElements("/queries/query");
            var allResultsXml = new XElement("results");
            foreach (var queryNode in queryNodes)
            {
                var countries = queryNode.XPathSelectElements("country").Select(c => c.Value);

                // Build the "river names by given countries" query

                var riversQuery = context.Rivers.AsQueryable();
                foreach (var country in countries)
                {
                    riversQuery = 
                        riversQuery.Where(r => r.Countries.Any(c => c.CountryName == country));
                }

                riversQuery = riversQuery.OrderBy(r => r.RiverName);
                var riversNamesQuery = riversQuery.Select(r => r.RiverName);

                // Build the query results 
                var totalCount = riversNamesQuery.Count();
                var maxResults = queryNode.Attribute("max-results");
                if (maxResults != null)
                {
                    riversNamesQuery = riversNamesQuery.Take(int.Parse(maxResults.Value));
                }

                var riverNames = riversNamesQuery.ToList();
                var listedCount = riverNames.Count();

                var resultXml = new XElement("rivers",
                    new XAttribute("total-count", totalCount),
                    new XAttribute("listed-count", listedCount),
                    riverNames.Select(river => new XElement("river", river)));
                allResultsXml.Add(resultXml);
            }
            System.Console.WriteLine(allResultsXml);
        }
    }
}
