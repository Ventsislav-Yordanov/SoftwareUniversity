namespace Tasks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json.Linq;

    public static class LinqToJson
    {
        public static List<JToken> PrintQuestionTitles(string json)
        {
            var jsonObject = JObject.Parse(json);
            var titles = 
                jsonObject["rss"]["channel"]["item"]
                .Select(n => n["title"])
                .ToList();

            return titles;
        }
    }
}
