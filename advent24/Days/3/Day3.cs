using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace advent24;

public class Day3
{
    internal static void SolveDay3()
    {
        var readFile = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\3\\input.txt");
        var testFile = new List<string>() { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))" };
        var testFile2 = new List<string>() { "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))" };
        Part1(readFile);
        Part2(testFile2);
    }

    internal static void Part1(List<string> input)
    {
        Console.WriteLine("Starting Day 3 part 1:");
        var regex = new Regex(@"mul\(\d+,\d+\)");

        var sanitizedContent = DoRegex(input, regex);

        var splittedContent = sanitizedContent.Select(c => c.Trim(new char[] { 'm', 'u', 'l', '(', ')' }).Split(",")).ToList();

        var sum = splittedContent.Select(c =>
        {
            var numb1 = int.Parse(c.First());
            var numb2 = int.Parse(c.Last());

            return numb1 * numb2;
        }).Sum();


        Console.WriteLine($"Sum : {sum}");
    }
    private static List<string> DoRegex(List<string> input, Regex regex)
    {
        var sanitizedContent = input
        .SelectMany(c => regex.Matches(c).Cast<Match>().Select(m => m.Value))
        .ToList();

        return sanitizedContent;

    }

    private static List<int> DoRegexWithIndex(List<string> input, Regex regex)
    {
        var sanitizedContent = input
            .SelectMany(c => regex.Matches(c).Cast<Match>().Select(m => m.Index))
            .ToList();

        sanitizedContent.Sort();

        return sanitizedContent;
    }

    internal static void Part2(List<string> input)
    {
        Console.WriteLine("Starting Day 3 part 2:");

        // Regex to identify mul(), don't(), and do() instructions
        var mulRegex = new Regex(@"mul\((\d+),(\d+)\)");
        var dontRegex = new Regex(@"don't\(\)");
        var doRegex = new Regex(@"do\(\)");

    }

}