namespace OldAlbumsLINQToXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    public class ExtractAlbumsPublishedSoon
    {
        static void Main()
        {
            var doc = XDocument.Load("../../../Catalog.xml");

            var yearBefore5Years = DateTime.Now.Year - 5;

            var oldAlbumsTitlesAndPrices =
                (from album in doc.Descendants("album")
                 where Decimal.Parse(album.Element("year").Value) <= yearBefore5Years
                 select new
                 {
                     Title = album.Element("name").Value,
                     Price = album.Element("price").Value
                 }).ToList();

            foreach (var album in oldAlbumsTitlesAndPrices)
            {
                Console.WriteLine("Title: {0}, Price: {1}", album.Title, album.Price);
            }
        }
    }
}
