using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLDispatcher
{
    class HTMLDispatcherClass
    {
        static void Main(string[] args)
        {
            string div = HTMLDispatch.CreateDiv("welcome", "color:#0000FF", "<h1>Hello<h1>");
            string img = HTMLDispatch.CreateImage("../Logo.png", "logo", "logo");
            string hyperlink = HTMLDispatch.CreateHyperlink("https://www.google.bg/", "google", "google");
            Console.WriteLine(div.ToString());
            Console.WriteLine(img.ToString());
            Console.WriteLine(hyperlink.ToString());
        }
    }
}
