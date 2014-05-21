using System;

class ShipDamage
{
    static void Main()
    {
        int sx1 = int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());

        int h = int.Parse(Console.ReadLine());

        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());

        int minX = Math.Min(sx1, sx2);
        int maxX = Math.Max(sx1, sx2);
        int minY = Math.Min(sy1, sy2);
        int maxY = Math.Max(sy1, sy2);

        int damage = 0;

        cy1 = h + (h - cy1);
        cy2 = h + (h - cy2);
        cy3 = h + (h - cy3);

        //first catapult
        if ((cx1 > minX && cx1 < maxX) && (cy1 > minY && cy1 < maxY))
        {
            damage = damage + 100;
        }

        if (
            ((cx1 == minX || cx1 == maxX) && (cy1 > minY && cy1 < maxY)) ||
            ((cx1 > minX && cx1 < maxX) && (cy1 == minY || cy1 == maxY))
           )
        {
            damage = damage + 50;
        }

        if (
            (cx1 == minX && cy1 == minY) ||
            (cx1 == minX && cy1 == maxY) ||
            (cx1 == maxX && cy1 == minY) ||
            (cx1 == maxX && cy1 == maxY)
           )
        {
            damage = damage + 25;
        }

        //second catapult
        if ((cx2 > minX && cx2 < maxX) && (cy2 > minY && cy2 < maxY))
        {
            damage = damage + 100;
        }

        if (
            ((cx2 == minX || cx2 == maxX) && (cy2 > minY && cy2 < maxY)) ||
            ((cx2 > minX && cx2 < maxX) && (cy2 == minY || cy2 == maxY))
           )
        {
            damage = damage + 50;
        }

        if (
            (cx2 == minX && cy2 == minY) ||
            (cx2 == minX && cy2 == maxY) ||
            (cx2 == maxX && cy2 == minY) ||
            (cx2 == maxX && cy2 == maxY)
           )
        {
            damage = damage + 25;
        }

        //third catapult
        if ((cx3 > minX && cx3 < maxX) && (cy3 > minY && cy3 < maxY))
        {
            damage = damage + 100;
        }

        if (
            ((cx3 == minX || cx3 == maxX) && (cy3 > minY && cy3 < maxY)) ||
            ((cx3 > minX && cx3 < maxX) && (cy3 == minY || cy3 == maxY))
           )
        {
            damage = damage + 50;
        }

        if (
            (cx3 == minX && cy3 == minY) ||
            (cx3 == minX && cy3 == maxY) ||
            (cx3 == maxX && cy3 == minY) ||
            (cx3 == maxX && cy3 == maxY)
           )
        {
            damage = damage + 25;
        }

        Console.WriteLine(damage + "%");
    }
}