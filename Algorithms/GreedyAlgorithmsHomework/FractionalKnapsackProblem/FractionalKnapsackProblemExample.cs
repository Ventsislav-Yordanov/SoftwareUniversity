namespace FractionalKnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FractionalKnapsackProblemExample
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine().Split(':')[1]);
            int itemsCount = int.Parse(Console.ReadLine().Split(':')[1]);
            var items = new Item[itemsCount];
            for (int i = 0; i < itemsCount; i++)
            {
                var pairInfo = Console.ReadLine()
                    .Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                items[i] = new Item(pairInfo[0], pairInfo[1]);

            }

            Array.Sort(items, (a, b) => (b.Price / b.Weight).CompareTo(a.Price / a.Weight));
            var selectedItems = new Dictionary<Item, double>();
            double totalPrice = 0;
            foreach (var item in items)
            {
                if (capacity > 0)
                {
                    if (capacity > item.Weight)
                    {
                        selectedItems.Add(item, 1d);
                        totalPrice += item.Price;
                    }
                    else
                    {
                        var percentage = (double) capacity / item.Weight;
                        selectedItems.Add(item, percentage);
                        totalPrice += item.Price * percentage;
                    }

                    capacity -= item.Weight;
                }
            }

            foreach (var item in selectedItems)
            {
                Console.WriteLine($"Take {item.Value * 100:#.##}% of item with price {item.Key.Price:F2} and weight {item.Key.Weight:F2}");
            }

            Console.WriteLine($"Total price: {totalPrice:F2}");
        }
    }
}
