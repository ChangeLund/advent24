using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent24;

public class Day5
{

    internal static void SolveDay5()
    {
        var testInput = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\5\\test.txt");
        var input = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\5\\input.txt");

        Part1(input);
        Part2(input);
    }

    internal static void Part1(List<string> input)
    {
        int splitIndex = input.IndexOf("");
        var sum = 0;
        var orderRules = input.Take(splitIndex).ToList();

        foreach (var line in input.Skip(splitIndex + 1).ToList())
        {
            var splittedPageList = line.Split(",");
            var tempList = splittedPageList.ToList();
            var matchSum = 0;

            for (int i = 0; i < splittedPageList.Length - 1; i++)
            {
                var matchingItems = orderRules.Where(c => c.Contains(splittedPageList[i]) && c.Contains(splittedPageList[i + 1])).ToList();
                var splittedMatchingItems = matchingItems.Select(c => c.Split('|')).ToList();

                if (splittedMatchingItems[0][1] == splittedPageList[i + 1]) matchSum++;
            }

            if (matchSum == splittedPageList.Length - 1)
            {
                int middleIndex = tempList.Count / 2;
                int middleNumber = int.Parse(tempList[middleIndex]);

                sum += middleNumber;
            }
        }
        Console.WriteLine(sum);
    }


    internal static void Part2(List<string> input)
    {
        int splitIndex = input.IndexOf("");
        var sum = 0;
        var orderRules = input.Take(splitIndex).ToList();

        var splittedOrderRules = orderRules.Select(c => c.Split("|")).ToList();

        foreach (var line in input.Skip(splitIndex + 1).ToList())
        {
            var splittedPageList = line.Split(",");
            var tempList = splittedPageList.ToList();
            var matchSum = 0;
            bool movedANumber = true;
            var loopIteration = 0;

            while (movedANumber)
            {
                movedANumber = false;
                matchSum = 0;

                for (int i = 0; i < tempList.Count - 1; i++)
                {
                    var matchingItems = orderRules.Where(c => c.Contains(tempList[i]) && c.Contains(tempList[i + 1])).ToList();
                    var splittedMatchingItems = matchingItems.Select(c => c.Split('|')).ToList();

                    if (splittedMatchingItems[0][1] == tempList[i])
                    {
                        var temp = tempList[i];
                        tempList[i] = tempList[i + 1];
                        tempList[i + 1] = temp;
                        movedANumber = true;
                        loopIteration++;
                    }
                    else
                    {
                        if (loopIteration == 0 && i == tempList.Count - 2) break;
                        matchSum++;
                    }
                }
            }

            if (matchSum == tempList.Count - 1)
            {
                int middleIndex = tempList.Count / 2;
                int middleNumber = int.Parse(tempList[middleIndex]);

                sum += middleNumber;
            }
        }

        Console.WriteLine(sum);
    }

}