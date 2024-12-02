using System.Diagnostics.Metrics;
using System.Linq;

namespace advent24;

public class Day2
{
    public static void SolveDay2()
    {
        Console.WriteLine("Solving Day 2");
        var input = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\2\\input.txt");
        var testInput = new List<string> { "7 6 4 2 1", "1 2 7 8 9", "9 7 6 2 1", "1 3 2 4 5", "8 6 4 4 1", "1 3 6 7 9" };
        Part1(input);
        Part2(testInput);
    }

    internal static void Part1(List<string> input)
    {
        Console.WriteLine("Solving Part1:");
        var splittedInput = input.Select(c => c.Split(' ')).Select(x => x.Select(int.Parse).ToList()).ToList();

        var sum = splittedInput.Count(c=> CountSafeFromList(c));

        Console.WriteLine($"Total Sum:{sum}");
    }

    internal static void Part2(List<string> input)
    {
        Console.WriteLine("Solving Part2:");
        var splittedInput = input.Select(c => c.Split(' ')).Select(x => x.Select(int.Parse).ToList()).ToList();

        var sum = splittedInput.Count(c => IsSafeWithDamper(c));

        Console.WriteLine($"Sum Part 2: {sum}");
    }

    internal static bool IsSafeWithDamper(List<int> list)
    {
        if (CountSafeFromList(list))
        {
            return true;
        }

        for (int i = 0; i < list.Count; i++)
        {
            var tempList = new List<int>(list);
            tempList.RemoveAt(i);
            if (CountSafeFromList(tempList))
            {
                return true;
            }
        }

        return false;
    }

    internal static bool CountSafeFromList(List<int> list)
    {
        var increasing = true;
        var decreasing = true;

        for (int i = 0; i < list.Count - 1; i++)
        {
            var diff = list[i + 1] - list[i];
            if (diff > 3 || diff < -3 || diff == 0)
            {
                increasing = false;
                decreasing = false;
                break;
            }
            if (diff < 0)
            {
                increasing = false;
            }
            if (diff > 0)
            {
                decreasing = false;
            }
        }

        return increasing || decreasing;
    }
}