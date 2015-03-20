namespace ExtractAlbumNames
{
    using System;
    using System.Xml;
    
    public class ExtractAlbumNames
    {
        static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("../../../Catalog.xml");
            XmlNode rootNode = doc.DocumentElement;

            var albums = rootNode.ChildNodes;
            Console.WriteLine("----- Album Names -----");
            foreach (XmlNode album in albums)
            {
                Console.WriteLine("Album name: {0}", album["name"].InnerText);
            }
        }
    }
}
