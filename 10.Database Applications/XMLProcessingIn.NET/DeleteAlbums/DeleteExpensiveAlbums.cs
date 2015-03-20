namespace DeleteAlbums
{
    using System;
    using System.Xml;

    public class DeleteExpensiveAlbums
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode albumNode in rootNode)
            {
                if (Decimal.Parse(albumNode["price"].InnerText) > 20)
                {
                    albumNode.ParentNode.RemoveChild(albumNode);
                }
            }

            Console.WriteLine("Document has been modified.");

            doc.Save("../../../Cheap-albums-catalog.xml");

            Console.WriteLine("Document has been saved.");
        }
    }
}
