using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class GenericListClass
    {
        public static void Main()
        {
            var customAttributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), true);
            Console.WriteLine("This GenericList<T> class's version is {0}", customAttributes[0]);

            GenericList<int> numbers = new GenericList<int>();
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);
            numbers.Add(10);

            Console.WriteLine("GenericList : {0}", numbers);
            Console.WriteLine("Index of 6 : {0}", numbers.IndexOf(6));
            Console.WriteLine("Capacity : {0}", numbers.Capacity);
            Console.WriteLine("Size : {0}", numbers.Size);
            Console.WriteLine();

            numbers.Remove(3); // remove element at index 3 
            numbers.Insert(100, 4); // insert number 100 at index 4
            Console.WriteLine("GenericList : {0}", numbers);
            Console.WriteLine("Size : {0}", numbers.Size);
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i * 3);
            }

            Console.WriteLine("GenericList : {0}", numbers);
            Console.WriteLine("Capacity : {0}", numbers.Capacity);            
        }
    }
}
