using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Entities;
using System.Xml.Linq;

namespace ExportInternationalMatchesAsXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var matches = context.InternationalMatches
                .OrderBy(m => m.MatchDate)
                .ThenBy(m => m.HomeCountry.CountryName)
                .ThenBy(m => m.AwayCountry.CountryName)
                .Select(im => new
                {
                    im.AwayCountry,
                    im.AwayCountryCode,
                    im.AwayGoals,
                    im.HomeCountry,
                    im.HomeCountryCode,
                    im.HomeGoals,
                    im.League,
                    im.MatchDate
                });

            var xmlRoot = new XElement("matches");
            foreach (var match in matches)
            {
                var matchXml = new XElement("match", /*new XAttribute("date-time", match.MatchDate.ToString()),*/
                    new XElement("home-country", match.HomeCountry.CountryName, new XAttribute("code", match.HomeCountryCode)),
                    new XElement("away-country", match.AwayCountry.CountryName, new XAttribute("code", match.AwayCountryCode)));

                if (match.MatchDate != null)
                {
                    string date = match.MatchDate.ToString().Substring(0, 11);
                    string time = match.MatchDate.ToString().Substring(12, match.MatchDate.ToString().Length - 15);
                    if (time.ToString() != ":00:00")
                    {
                        matchXml.SetAttributeValue("date-time", match.MatchDate);
                    }
                    else
                    {
                        matchXml.SetAttributeValue("date", date);
                    }
                }
                xmlRoot.Add(matchXml);
                if (match.HomeGoals != null)
                {
                    matchXml.SetElementValue("score", match.HomeGoals.ToString() + "-" + match.AwayGoals.ToString());
                }
                if (match.League != null)
                {
                    matchXml.SetElementValue("league", match.League.LeagueName);   
                }
            }
            xmlRoot.Save("../../Matches.xml");
            Console.WriteLine("Matches exported");
        }
    }
}
