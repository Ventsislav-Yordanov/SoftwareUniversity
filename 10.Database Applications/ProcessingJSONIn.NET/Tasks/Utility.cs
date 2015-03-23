namespace Tasks
{
    using System.IO;

    public class Utility
    {
        // "https://softuni.bg/Feed/News", "../../../output/news.xml"
        public const string NewsUrl = "https://softuni.bg/Feed/News";
        public const string OutputPath = "../../../output/";
        public const string XmlPath = "../../../output/news.xml";
        public const string HtmlPath = "../../../output/news.html";

        public static void CreateOutputDirectory()
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }
        }
    }
}
