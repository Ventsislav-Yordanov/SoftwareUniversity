using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.CustomLINQExtensionMethods
{
    public class Test
    {
        static void Main(string[] args)
        {
            // http://www.dotnetperls.com/lambda
            IEnumerable<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 6, 8, 9, 22, 13 };
            Console.WriteLine(string.Join(",", numbers.WhereNot<int>(a => a % 2 == 0)));
            Console.WriteLine(string.Join(", ", numbers.Repeat<int>(2)));

            IEnumerable<string> sports = new List<string>() { "Football", "Basketball", "Baseball", "Bowling", "Skiing", "Skating", 
                "Snowboarding", "Tennis", "Karate" };
            IEnumerable<string> suffixes = new List<string>() { "ate", "all" };
            Console.WriteLine(string.Join(", ", sports.WhereEndsWith(suffixes)));
        }
    }
}
