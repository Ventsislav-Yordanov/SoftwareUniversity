namespace Knapsack_Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Knapsack
    {
        public static void Main()
        {
            var items = new[]
            {
                new Item { Weight = 5, Price = 30 },
                new Item { Weight = 8, Price = 120 },
                new Item { Weight = 7, Price = 10 },
                new Item { Weight = 0, Price = 20 },
                new Item { Weight = 4, Price = 50 },
                new Item { Weight = 5, Price = 80 },
                new Item { Weight = 2, Price = 10 }
            };

            var knapsackCapacity = 20;

            var itemsTaken = FillKnapsack(items, knapsackCapacity);

            Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
            Console.WriteLine("Take the following items in the knapsack:");
            foreach (var item in itemsTaken)
            {
                Console.WriteLine(
                    "  (weight: {0}, price: {1})",
                    item.Weight,
                    item.Price);
            }

            Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
            Console.WriteLine("Total price: {0}", itemsTaken.Sum(i => i.Price));
        }

        public static Item[] FillKnapsack(Item[] items, int capacity)
        {
            var maxPrice = new int[items.Length, capacity + 1];
            var isItemTaken = new bool[items.Length, capacity + 1];

            for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
            {
                if (items[0].Weight <= currentCapacity)
                {
                    maxPrice[0, currentCapacity] = items[0].Price;
                    isItemTaken[0, currentCapacity] = true;
                }
            }

            for (int currentItem = 1; currentItem < items.Length; currentItem++) { 
                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    // Don't take item i
                    maxPrice[currentItem, currentCapacity] = maxPrice[currentItem - 1, currentCapacity];

                    // Try to take item i (if it gives better price)
                    var capacityLeft = currentCapacity - items[currentItem].Weight;
                    if (capacityLeft >= 0 &&
                        maxPrice[currentItem - 1, capacityLeft] + items[currentItem].Price > maxPrice[currentItem - 1, currentCapacity])
                    {
                        maxPrice[currentItem, currentCapacity] = maxPrice[currentItem - 1, capacityLeft] + items[currentItem].Price;
                        isItemTaken[currentItem, currentCapacity] = true;
                    }
                }
            }

            var itemsTaken = new List<Item>();
            int itemIndex = items.Length - 1;
            while (itemIndex >= 0)
            {
                if (isItemTaken[itemIndex, capacity])
                {
                    itemsTaken.Add(items[itemIndex]);
                    capacity -= items[itemIndex].Weight;
                }

                itemIndex--;
            }

            itemsTaken.Reverse();
            return itemsTaken.ToArray();
        }
    }
}
