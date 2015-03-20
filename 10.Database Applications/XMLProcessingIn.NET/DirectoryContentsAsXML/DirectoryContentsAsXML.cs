namespace DirectoryContentsAsXML
{
    using System;
using System.IO;
using System.Xml.Linq;

    public class DirectoryContentsAsXML
    {
        private const string DirectoryToTraverse = "../../";

        static void Main()
        {
            BuildXmlDirectoryTree();
        }

        private static void BuildXmlDirectoryTree()
        {
            var startupDirectory = new DirectoryInfo(DirectoryToTraverse);
            var xmlDirectoryTree = BuildXmlDirectoryTree(startupDirectory);
            var xDocument = new XDocument(xmlDirectoryTree);
            xDocument.Save("../../Directory.xml");
        }

        private static XElement BuildXmlDirectoryTree(DirectoryInfo directoryInfo)
        {
            var directoriesXml = new XElement("directories");
            var subtreeXml = BuildXmlForDirectoryRursively(directoryInfo);
            directoriesXml.Add(subtreeXml);
            return directoriesXml;
        }

        private static XElement BuildXmlForDirectoryRursively(DirectoryInfo direcotryInfo)
        {
            var directoryXml = new XElement("dir", new XAttribute("name", direcotryInfo.Name));

            foreach (var file in direcotryInfo.GetFiles())
            {
                var fileXml = new XElement("file", new XAttribute("name", file.Name));
                directoryXml.Add(fileXml);
            }

            foreach (var dir in direcotryInfo.GetDirectories())
            {
                directoryXml.Add(BuildXmlForDirectoryRursively(dir));
            }

            return directoryXml;
        }
    }
}
