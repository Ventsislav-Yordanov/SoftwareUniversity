namespace Tasks
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Diagnostics;

    public class MainClass
    {
        static void Main()
        {
            Utility.CreateOutputDirectory();

            // Problem 1.	Download the content of the SoftUni RSS feed
            DownloadSoftUniRSS.DownloadFile(Utility.NewsUrl, Utility.XmlPath);

            // Problem 2.	Parse the XML from the feed to JSON
            var json = XmlToJson.ConvertXmlToJson();
            Console.WriteLine(json);

            // Problem 3.	Using LINQ-to-JSON select all the question titles and print them to the console
            var titles = LinqToJson.PrintQuestionTitles(json);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

            // Problem 4.	Parse the JSON string to POCO
            var jsonObject = JObject.Parse(json);
            var news = jsonObject["rss"]["channel"]["item"].ToList();
            var pocos = news.Select(item => JsonConvert.DeserializeObject<JsonToPoco>(item.ToString())).ToList();

            // Problem 5.	Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question’s page
            PocoToHtml.MakeHtml(pocos);
        }
    }
}
