using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public static class PocoToHtml
    {
        public static void MakeHtml(List<JsonToPoco> pocos)
        {
            var result = new StringBuilder();
            result.Append("<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body>");
            foreach (var jsonToPoco in pocos)
            {
                result.AppendLine(jsonToPoco.ToString());
            }

            result.Append("</body></html>");
            File.WriteAllText(Utility.HtmlPath, result.ToString());
        }
    }
}
