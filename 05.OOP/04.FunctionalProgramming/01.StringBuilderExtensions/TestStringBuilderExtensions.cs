using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StringBuilderExtensions
{
    class TestStringBuilderExtensions
    {
        static void Main(string[] args)
        {
            StringBuilder test = new StringBuilder("I love TECH-MINIMAL music!");
            Console.WriteLine(test.SubString(7, 12));
            Console.WriteLine(test.RemoveText("music"));
            IEnumerable<string> styles = new List<string>() { "House", "Minimal", "Progressive", "Trance", "Chill Out" };
            Console.WriteLine(test.AppendAll(styles));
        }
    }
}
