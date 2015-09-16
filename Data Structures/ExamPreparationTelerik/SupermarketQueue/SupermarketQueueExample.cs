namespace SupermarketQueue
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class SupermarketQueueExample
    {
        private static StringBuilder result = new StringBuilder();

        public static void Main()
        {
            string inputLine = Console.ReadLine();
            var supermarketQueue = new SupermarketQueue();
            if (inputLine != "End")
            {
                while (inputLine != null && inputLine != "End")
                {
                    string commandResult = supermarketQueue.ProcessCommand(inputLine);
                    Console.WriteLine(commandResult);
                    inputLine = Console.ReadLine();
                }
            }
            else
            {
                return;
            }
        }
    }

    public class SupermarketQueue
    {
        private const string IncorrectCommand = "Incorrect command";
        private const string Ok = "OK";
        private const string Error = "Error";

        private BigList<string> repository;
        private Bag<string> names;

        public SupermarketQueue()
        {
            this.repository = new BigList<string>();
            this.names = new Bag<string>();
        }

        public string Append(string name)
        {
            this.repository.Add(name);
            this.names.Add(name);
            return Ok;
        }

        public string Insert(int position, string name)
        {
            try
            {
                this.repository.Insert(position, name);
                this.names.Add(name);
                return Ok;
            }
            catch (Exception)
            {
                return Error;
            }
        }

        public int Find(string name)
        {
            int count = this.names.NumberOfCopies(name);
            return count;
        }

        public string Serve(int count)
        {
            try
            {
                var servedPeople = this.repository.Range(0, count).ToList();
                this.repository.RemoveRange(0, count);
                this.names.RemoveMany(servedPeople);
                return string.Join(" ", servedPeople);
            }
            catch (Exception)
            {
                return Error;
            }
        }

        public string End()
        {
            return "End";
        }

        public string ProcessCommand(string inputLine)
        {
            if (inputLine == "End")
            {
                return "End";
            }

            int indexOfFirstSpace = inputLine.IndexOf(' ');
            string command = inputLine.Substring(0, indexOfFirstSpace);
            string paramtersString = inputLine.Substring(indexOfFirstSpace + 1);
            string[] paramets = paramtersString.Split(' ');
            switch (command)
            {
                case "Append":
                    return this.Append(paramets[0]);
                case "Insert":
                    return this.Insert(int.Parse(paramets[0]), paramets[1]);
                case "Find":
                    return this.Find(paramets[0]).ToString();
                case "Serve":
                    return this.Serve(int.Parse(paramets[0]));
                default:
                    return IncorrectCommand;
            }
        }
    }
}
