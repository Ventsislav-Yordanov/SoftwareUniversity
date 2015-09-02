namespace EventsInGivenDateRange
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class PrintEventsInGivenDateRange
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var events = new OrderedMultiDictionary<DateTime, string>(true);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string eventEntry = Console.ReadLine();
                var eventTokens = eventEntry.Split('|');
                string eventName = eventTokens[0].Trim();
                DateTime eventDate = DateTime.Parse(eventTokens[1].Trim());
                events.Add(eventDate, eventName);
            }

            int numberOfRanges = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfRanges; i++)
            {
                string datesAsString = Console.ReadLine();
                var datesTokens = datesAsString.Split('|');
                DateTime startDate = DateTime.Parse(datesTokens[0].Trim());
                DateTime endDate = DateTime.Parse(datesTokens[1].Trim());
                var eventsInRange = events.Range(startDate, true, endDate, true);

                Console.WriteLine(new string('-', 70));
                Console.WriteLine("Events count between {0} and {1}: {2}", startDate, endDate, eventsInRange.KeyValuePairs.Count);
                foreach (var pair in eventsInRange)
                {
                    foreach (var name in pair.Value)
                    {
                        Console.WriteLine("{0} | {1}", name, pair.Key);
                    }
                }
            }
        }
    }
}