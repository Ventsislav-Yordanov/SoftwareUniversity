namespace ExtractArtistsAndAlbumsCountUsingXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractArtistsAndAlbumsCount
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            string xPathQuery = "/albums/album";
            XmlNodeList albumsList = doc.SelectNodes(xPathQuery);

            var artistsAndAlbumsCount2 = new Dictionary<string, int>();

            foreach (XmlNode album in albumsList)
            {
                var aritstName = album["artist"].InnerText;
                if (!artistsAndAlbumsCount2.ContainsKey(aritstName))
                {
                    artistsAndAlbumsCount2[aritstName] = 1;
                }
                else
                {
                    artistsAndAlbumsCount2[aritstName] += 1;
                }
            }

            Console.WriteLine("----- Artists and Number of Albums with XPath -----");
            foreach (var artistAlbumsCount in artistsAndAlbumsCount2)
            {
                Console.WriteLine("Artist: {0}, Number of albums: {1}", artistAlbumsCount.Key, artistAlbumsCount.Value);
            }
        }
    }
}
