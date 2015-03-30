using Football.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ImportLeaguesAndTeamsFromXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var xmlDoc = XDocument.Load(@"../../leagues-and-teams.xml");
            var leagueNodes = xmlDoc.XPathSelectElements("/leagues-and-teams/league");
            foreach (var leagueNode in leagueNodes)
            {
                var leagueName = leagueNode.Descendants("league-name").FirstOrDefault();
            }
        }
    }
}
