namespace ExtractArtistsAndNumberOfAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractArtistsAndNumberOfAlbums
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            var albums = rootNode.ChildNodes;

            var artistsAndAlbumsCount = new Dictionary<string, int>();
            foreach (XmlNode album in albums)
            {
                var aritstName = album["artist"].InnerText;
                if (!artistsAndAlbumsCount.ContainsKey(aritstName))
                {
                    artistsAndAlbumsCount[aritstName] = 1;
                }
                else
                {
                    artistsAndAlbumsCount[aritstName] += 1;
                }
            }

            Console.WriteLine("----- Artists and Number of Albums -----");
            foreach (var artistAlbumsCount in artistsAndAlbumsCount)
            {
                Console.WriteLine("Artist: {0}, Number of albums: {1}", artistAlbumsCount.Key, artistAlbumsCount.Value);
            }
        }
    }
}
