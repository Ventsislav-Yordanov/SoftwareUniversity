using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    static class HTMLDispatch
    {
        public static string CreateImage(string imgSrc, string alt, string title)
        {
            ElementBuilder img = new ElementBuilder("img", true);
            img.AddAttribute("src", imgSrc);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);
            return img.ToString();
        }

        public static string CreateHyperlink(string url, string title, string text)
        {
            ElementBuilder hyperlink = new ElementBuilder("a");
            hyperlink.AddAttribute("url", url);
            hyperlink.AddAttribute("title", title);
            hyperlink.AddContent(text);
            return hyperlink.ToString();
        }

        public static string CreateDiv(string id, string style, string content)
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", id);
            div.AddAttribute("style", style);
            div.AddContent(content);
            return div.ToString();
        }
    }
}
