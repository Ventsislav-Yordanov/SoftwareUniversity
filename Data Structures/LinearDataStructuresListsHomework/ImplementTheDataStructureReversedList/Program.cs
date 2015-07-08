namespace ImplementTheDataStructureReversedList
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    class Program
    {
        [ExcludeFromCodeCoverage]
        static void Main()
        {
            var reversedList = new ReversedList<int>() { 1, 5 };
            reversedList.Add(6);
            reversedList.Add(7);
            reversedList.Delete(3);
            reversedList.Delete(2);

            foreach (var item in reversedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
