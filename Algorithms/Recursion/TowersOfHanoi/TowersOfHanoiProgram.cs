namespace TowersOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TowersOfHanoiProgram
    {
        private static int stepsCount = 0;
        private static Stack<int> source;
        private static readonly Stack<int> destination = new Stack<int>();
        private static readonly Stack<int> spare = new Stack<int>();

        public static void Main()
        {
            int numberOfDisk = int.Parse(Console.ReadLine());
            source = new Stack<int>(Enumerable.Range(1, 3).Reverse());
            PrintRods();
            MoveDisks(numberOfDisk, source, destination, spare);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bottomDisk"></param>
        /// <param name="source">The rod to move a disk FROM</param>
        /// <param name="destination">The rod to move a disk TO</param>
        /// <param name="spare">The rod which does not participate in the current move</param>
        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                PerformMove(bottomDisk, source, destination);
            }
            else
            {
                // 1) move all disks from bottomDisk - 1 from source to spare;
                MoveDisks(bottomDisk - 1, source, spare, destination);

                // 2) move the bottomDisk from source to destination; 
                PerformMove(bottomDisk, source, destination);

                // 3) move all disks from bottomDisk – 1 from spare to destination.
                MoveDisks(bottomDisk - 1, spare, destination, source);
            }
        }

        private static void PerformMove(int bottomDisk, Stack<int> source, Stack<int> destination)
        {
            var disk = source.Pop();
            destination.Push(disk);
            stepsCount++;
            Console.WriteLine($"Step {stepsCount}: Moved disk {bottomDisk}");
            PrintRods();
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}
