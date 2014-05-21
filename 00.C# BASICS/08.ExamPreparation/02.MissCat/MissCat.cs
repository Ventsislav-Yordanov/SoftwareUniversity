using System;

class MissCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] catsScore = new int[11];
        for (int i = 0; i < n; i++)
        {
            byte vote = byte.Parse(Console.ReadLine());
            catsScore[vote]++;
        }
        int bestCatScore = int.MinValue;
        int indexOfBestCat = 1;
        for (int i = 1; i < 11; i++)
        {
            if (bestCatScore < catsScore[i])
            {
                bestCatScore = catsScore[i];
                indexOfBestCat = i;

            }
        }
        Console.WriteLine(indexOfBestCat);
    }
}