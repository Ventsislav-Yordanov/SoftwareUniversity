using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        int secretNum = int.Parse(Console.ReadLine());
        int targetBulls = int.Parse(Console.ReadLine());
        int targetCows = int.Parse(Console.ReadLine());

        List<int> results = new List<int>();
        char usedSecretNum = '*';
        char usedSearchedNum = '@';

        for (int searchedNum = 1111; searchedNum <= 9999; searchedNum++)
        {

            int foundedBulls = 0;
            int foundedCows = 0;
            char[] secretNumDigits = secretNum.ToString().ToCharArray();
            char[] searchedNumDigits = searchedNum.ToString().ToCharArray();

            if (searchedNumDigits[0] >= '1' &&
                searchedNumDigits[1] >= '1' &&
                searchedNumDigits[2] >= '1' &&
                searchedNumDigits[3] >= '1')
            {

                for (int i = 0; i < secretNumDigits.Length; i++)
                {
                    if (secretNumDigits[i] == searchedNumDigits[i])
                    {
                        foundedBulls++;
                        secretNumDigits[i] = usedSecretNum;
                        searchedNumDigits[i] = usedSearchedNum;
                    }
                }

                for (int indexSecretNum = 0; indexSecretNum < secretNumDigits.Length; indexSecretNum++)
                {
                    for (int indexSearchedNum = 0; indexSearchedNum < searchedNumDigits.Length; indexSearchedNum++)
                    {
                        if (searchedNumDigits[indexSearchedNum] == secretNumDigits[indexSecretNum])
                        {
                            foundedCows++;
                            secretNumDigits[indexSecretNum] = usedSecretNum;
                            searchedNumDigits[indexSearchedNum] = usedSearchedNum;
                        }
                    }
                }

                if (targetBulls == foundedBulls && targetCows == foundedCows)
                {
                    results.Add(searchedNum);
                }
            }
        }

        if (results.Count == 0)
        {
            Console.WriteLine("No");
        }

        else
        {
            for (int i = 0; i < results.Count; i++)
            {
                Console.Write(results[i] + " ");
            }
        }
    }
}