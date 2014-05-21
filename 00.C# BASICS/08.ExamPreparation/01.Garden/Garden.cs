using System;
using System.Threading;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        double tomatoSeeds = double.Parse(Console.ReadLine());
        double tomatoArea = double.Parse(Console.ReadLine());
        double cucumberSeeds = double.Parse(Console.ReadLine());
        double cucumberArea = double.Parse(Console.ReadLine());
        double potatoSeeds = double.Parse(Console.ReadLine());
        double potatoArea = double.Parse(Console.ReadLine());
        double carrotSeeds = double.Parse(Console.ReadLine());
        double carrotArea = double.Parse(Console.ReadLine());
        double cabbageSeeds = double.Parse(Console.ReadLine());
        double cabbageArea = double.Parse(Console.ReadLine());

        double beansSeeds = double.Parse(Console.ReadLine());

        int totalArea = 250;

        double cost = tomatoSeeds * 0.5 + cucumberSeeds * 0.4 + potatoSeeds * 0.25 + carrotSeeds * 0.6
                      + cabbageSeeds * 0.3 + beansSeeds * 0.4;

        double beansArea = totalArea - (tomatoArea + cucumberArea + potatoArea + carrotArea + cabbageArea);

        Console.WriteLine("Total costs: {0:F2}", cost);

        if (beansArea > 0)
        {
            Console.WriteLine("Beans area: {0}",beansArea);
        }
        if (beansArea == 0)
        {
            Console.WriteLine("No area for beans");
        }
        if (beansArea < 0)
        {
            Console.WriteLine("Insufficient area");
        }
    }
}