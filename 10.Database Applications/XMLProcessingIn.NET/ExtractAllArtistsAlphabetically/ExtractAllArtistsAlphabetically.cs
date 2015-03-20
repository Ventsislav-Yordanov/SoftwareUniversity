namespace ExtractAllArtistsAlphabetically
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class ExtractAllArtistsAlphabetically
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            var albums = rootNode.ChildNodes;

            var sortedArtists = new SortedSet<string>();
            foreach (XmlNode album in albums)
            {
                sortedArtists.Add(album["artist"].InnerText);
            }

            Console.WriteLine("----- All Artists Alphabetically -----");
            foreach (var artist in sortedArtists)
            {
                Console.WriteLine(artist);
            }
        }
    }
}
