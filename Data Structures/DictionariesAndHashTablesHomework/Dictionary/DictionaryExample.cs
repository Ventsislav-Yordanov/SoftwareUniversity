namespace Dictionary
{
    using System;

    class DictionaryExample
    {
        static void Main()
        {
            var dictionary = new Dictionary<string, int>();
            dictionary.Add("Mitko", 2);
            dictionary.Add("Pesho", 5);
            dictionary.Add("Maria", 6);
            dictionary.Add("Gosho", 3);
            dictionary["Gosho"] = 24;
            Console.WriteLine(string.Join(",", dictionary));

            var mariaGrade = dictionary["Maria"];
            Console.WriteLine("dictionary[\"Maria\"]: {0}", mariaGrade);
            Console.WriteLine("dictionary.ContainsKey(\"hey\"): {0}", dictionary.ContainsKey("hey"));
            Console.WriteLine("dictionary.ContainsKey(\"Maria\"): {0}", dictionary.ContainsKey("Maria"));
            Console.WriteLine("dictionary.ContainsValue(6): {0}", dictionary.ContainsValue(6));
            Console.WriteLine("dictionary.ContainsValue(66): {0}", dictionary.ContainsValue(66));

            Console.WriteLine("Remove(\"Pesho\")");
            if (dictionary.Remove("Pesho"))
            {
                Console.WriteLine("Pesho removed.");
            }
            else
            {
                Console.WriteLine("Pesho != removed");
            }

            if (dictionary.Remove("Garga"))
            {
                Console.WriteLine("Garga removed.");
            }
            else
            {
                Console.WriteLine("Garga != removed");
            }

            var mitkoGrade = 0;
            if (dictionary.TryGetValue("Mitko", out mitkoGrade))
            {
                Console.WriteLine("Mitko has grade: {0}", mitkoGrade);
            }
            else
            {
                Console.WriteLine("Mitko doesn't have a grade");
            }

            var stefanGrade = 0;
            if (dictionary.TryGetValue("Stefan", out stefanGrade))
            {
                Console.WriteLine("Stefan have grade: {0}", stefanGrade);
            }
            else
            {
                Console.WriteLine("Stefan have not a grade");
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
