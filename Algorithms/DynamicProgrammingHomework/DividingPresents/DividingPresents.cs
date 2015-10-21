namespace DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DividingPresents
    {
        public static void Main()
        {
            var giftPrices = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            //var giftPrices = new int[] { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };
            var knapsackCapacity = giftPrices.Sum() / 2;
            var itemsTaken = FillKnapsack(giftPrices, knapsackCapacity);

            int alanSum = itemsTaken.Sum();
            int bobSum = giftPrices.Sum() - alanSum;
            int difference = bobSum - alanSum;
            Console.WriteLine("Difference: {0}", difference);
            Console.Write("Alan: {0} ", alanSum);
            Console.WriteLine("Bob: {0}", bobSum);
            Console.WriteLine("Alan takes: {0}", string.Join(", ", itemsTaken));
            Console.WriteLine("Bob takes the rest.");
        }

        public static int[] FillKnapsack(int[] items, int capacity)
        {
            var maxPrice = new int[items.Length, capacity + 1];
            var isItemTaken = new bool[items.Length, capacity + 1];

            for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
            {
                if (items[0] <= currentCapacity)
                {
                    maxPrice[0, currentCapacity] = items[0];
                    isItemTaken[0, currentCapacity] = true;
                }
            }

            for (int currentItem = 1; currentItem < items.Length; currentItem++)
            {
                for (int currentCapacity = 0; currentCapacity <= capacity; currentCapacity++)
                {
                    // Don't take item i
                    maxPrice[currentItem, currentCapacity] = maxPrice[currentItem - 1, currentCapacity];

                    // Try to take item i (if it gives better price)
                    var capacityLeft = currentCapacity - items[currentItem];
                    if (capacityLeft >= 0 &&
                        maxPrice[currentItem - 1, capacityLeft] + items[currentItem] > maxPrice[currentItem - 1, currentCapacity])
                    {
                        maxPrice[currentItem, currentCapacity] = maxPrice[currentItem - 1, capacityLeft] + items[currentItem];
                        isItemTaken[currentItem, currentCapacity] = true;
                    }
                }
            }

            var itemsTaken = new List<int>();
            int itemIndex = items.Length - 1;
            while (itemIndex >= 0)
            {
                if (isItemTaken[itemIndex, capacity])
                {
                    itemsTaken.Add(items[itemIndex]);
                    capacity -= items[itemIndex];
                }

                itemIndex--;
            }

            itemsTaken.Reverse();
            return itemsTaken.ToArray();
        }
    }
}
