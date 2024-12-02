using System.Diagnostics.Metrics;
using System.Linq;

namespace advent24;

public class Day2
{
    public static void SolveDay2()
    {
        Console.WriteLine("Solving Day 2");
        var input = FileReaderUtil.ReadFile("C:\\Users\\Endre\\source\\repos\\advent24\\advent24\\Days\\2\\input.txt");
        var testInput = new List<string> { "7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9" };
        Part1(input);
        Part2(input);
    }

    internal static void Part1(List<string> input)
    {
        Console.WriteLine("Starting Part1");
        var reports = input.Select(l => l.Split(" ").Select(x => int.Parse(x)).ToList()).ToList();

        var numberOfSafe = reports.Select(l =>
        {
            var isIncreasing = l.First() < l.Last();

            if (!isIncreasing) l.Reverse();

            if (CountSafeReports(l.ToList())) return 1;
            return 0;

        }).Sum();

        Console.WriteLine($"Total Safe reports: {numberOfSafe}");
    }


    internal static void Part2(List<string> input)
    {
        Console.WriteLine("Starting Part 2");
        var reports = input.Select(l => l.Split(" ").Select(x => int.Parse(x)).ToList()).ToList();

        var numberOfSafe = reports.Select(l =>
        {
            var isIncreasing = l.First() < l.Last();

            if (!isIncreasing) l.Reverse();

            if (CountSafeReports(l.ToList())) return 1;

            for (int i = 0; i < l.Count(); i++)
            {
                var tempList = new List<int>(l);
                tempList.RemoveAt(i);
                if (CountSafeReports(tempList.ToList())) return 1;
            }

            return 0;

        }).Sum();

        Console.WriteLine($"Total Safe reports: {numberOfSafe}");
    }

    private static bool CountSafeReports(List<int> input)
    {
        var countBool = true;

        for (int i = 0; i < input.Count - 1; i++)
        {
            if (Math.Abs(input[i] - input[i + 1]) <= 3)
            {
                if (!countBool) continue;
                if (input[i] > input[i + 1])
                {
                    countBool = false;
                    continue;
                }
                if (input[i] - input[i + 1] == 0)
                {
                    countBool = false;
                    continue;
                }
                countBool = true;
            }
            else
            {
                countBool = false;
            }

        }

        return countBool;

    }
}