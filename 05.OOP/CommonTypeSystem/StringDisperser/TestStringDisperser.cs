namespace StringDisperser
{
    using System;
    public class TestStringDisperser
    {
        static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("Mitko", "Pavcho", "Petur");
            StringDisperser stringDisperserCopy = (StringDisperser)stringDisperser.Clone();
            stringDisperser.TotalString.Append("Borko");
            stringDisperserCopy.TotalString.Append("Alex");

            foreach (var item in stringDisperser)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();

            foreach (var item in stringDisperserCopy)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
