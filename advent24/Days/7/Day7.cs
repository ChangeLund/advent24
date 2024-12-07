using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace advent24;

public class Day7
{


    public static void SolveDay7()
    {
        var testInput = FileReaderUtil.ReadFile("C:\\Users\\Endre\\source\\repos\\advent24\\advent24\\Days\\7\\test.txt");
        var input = FileReaderUtil.ReadFile("C:\\Users\\Endre\\source\\repos\\advent24\\advent24\\Days\\7\\input.txt");

        Part1(input);
        Part2(input);
    }

    internal static void Part1(List<string> input)
    {
        Console.WriteLine("Starting Part1:");
        long totalSum = 0;
        var splittedInput = input.Select(x => x.Split(":").First()).ToList();
        var nums = input
            .Select(c => c.Split(":")
                          .Last()
                          .Trim()
                          .Split(" ")
                          .Where(x => !string.IsNullOrWhiteSpace(x))
                          .Select(long.Parse)
                          .ToList())
                          .ToList();

        for (int i = 0; i < splittedInput.Count(); i++)
        {
            if (DoCalculation(long.Parse(splittedInput[i]), nums[i])) totalSum += long.Parse(splittedInput[i]);
        }

        Console.WriteLine($"Sum of Part1: {totalSum}");
    }

    internal static void Part2(List<string> input)
    {
        Console.WriteLine("Starting Part2:");
        long totalSum = 0;
        var splittedInput = input.Select(x => x.Split(":").First()).ToList();

        var nums = input
            .Select(c => c.Split(":")
                          .Last()
                          .Trim()
                          .Split(" ")
                          .Where(x => !string.IsNullOrWhiteSpace(x))
                          .Select(long.Parse)
                          .ToList())
                          .ToList();

        for (int i = 0; i < splittedInput.Count(); i++)
        {
            if(DoAllOperations(long.Parse(splittedInput[i]), nums[i])) totalSum += long.Parse(splittedInput[i]);
        }

        Console.WriteLine($"Sum of Part2: {totalSum}");
    }

    private static bool DoAllOperations(long totalSum, List<long> nums)
    {
        bool Calculate(int index, string currentSum)
        {
            if (index == nums.Count)
                return long.Parse(currentSum) == totalSum;

            long nextNum = nums[index];

            return Calculate(index + 1, (long.Parse(currentSum) + nextNum).ToString()) || 
                   Calculate(index + 1, (long.Parse(currentSum) * nextNum).ToString()) || 
                   Calculate(index + 1, currentSum + nextNum.ToString());               
        }

        return Calculate(1, nums[0].ToString());
    }

    private static bool DoCalculation(long totalSum, List<long> nums)
    {
        bool Calculate(int index, long currentSum)
        {
            if (index == nums.Count)
                return currentSum == totalSum;

            long nextNum = nums[index];

            return Calculate(index + 1, currentSum + nextNum) ||
                   Calculate(index + 1, currentSum * nextNum);
        }

        return Calculate(1, nums[0]);
    }
}
