using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoinLists
{
    static void Main()
    {
        string firstLine = Console.ReadLine();
        string secondLine = Console.ReadLine();
        string[] firstLineNums = firstLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string[] secondLineNums = secondLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> mainList = new List<int>();
        List<int> auxiliaryList = new List<int>();

        for (int i = 0; i < firstLineNums.Length; i++)
        {
            auxiliaryList.Add(int.Parse(firstLineNums[i]));
        }

        for (int i = 0; i < secondLineNums.Length; i++)
        {
            auxiliaryList.Add(int.Parse(secondLineNums[i]));
        }

        auxiliaryList.Sort();

        mainList = auxiliaryList.Distinct().ToList(); //LINQ - Distinct erases the duplicated elements

        foreach (int number in mainList)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}