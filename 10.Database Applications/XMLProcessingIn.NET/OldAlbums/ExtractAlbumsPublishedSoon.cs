namespace OldAlbums
{
    using System;
    using System.Xml;

    public class ExtractAlbumsPublishedSoon
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            var albums = rootNode.ChildNodes;

            int yearAfter5Years = DateTime.Now.Year - 5;

            string albumsQuery = "/albums/album[year <= " + yearAfter5Years + "]";

            XmlNodeList albumsList = doc.SelectNodes(albumsQuery);

            foreach (XmlNode album in albumsList)
            {
                Console.WriteLine("Title: {0}, Price:{1}", album["name"].InnerText, album["price"].InnerText);
            }
        }
    }
}
