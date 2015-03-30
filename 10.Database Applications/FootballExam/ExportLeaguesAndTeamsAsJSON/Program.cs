using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Football.Entities;
using System.Web.Script.Serialization;
using System.IO;

namespace ExportLeaguesAndTeamsAsJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var legues = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    l.LeagueName,
                    Teams = l.Teams
                        .OrderBy(t => t.TeamName)
                        .Select(t => new
                        {
                            t.TeamName
                        })
                }).ToList();

            var jsSerializer = new JavaScriptSerializer();
            var leguesJson = jsSerializer.Serialize(legues);
            File.WriteAllText("../../leagues-and-teams.json", leguesJson);
        }
    }
}
