using Newtonsoft.Json;
using System.Xml.Linq;
namespace Tasks
{
    public static class XmlToJson
    {
        public static string ConvertXmlToJson()
        {
            XDocument xmlDocument = XDocument.Load(Utility.XmlPath);
            string jsonFromXml = JsonConvert.SerializeXNode(xmlDocument, Formatting.Indented);
            return jsonFromXml;
        }
    }
}
