namespace Phonebook
{
    using System;

    using Dictionary;

    class Program
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var phoneBook = new Dictionary<string, string>();

            while (inputLine != "search")
            {
                var pair = inputLine.Split(new Char[] { '-' });
                phoneBook[pair[0]] = pair[1];
                inputLine = Console.ReadLine();
            }

            if (inputLine == "search" && inputLine != string.Empty)
            {
                while (inputLine != string.Empty)
                {
                    var searchName = Console.ReadLine();
                    if (phoneBook.ContainsKey(searchName))
                    {
                        var contactNumber = phoneBook[searchName];
                        Console.WriteLine("{0} -> {1}", searchName, contactNumber);
                    }
                    else
                    {
                        Console.WriteLine("Contact {0} does not exists.", searchName);
                    }
                }
            }
        }
    }
}
