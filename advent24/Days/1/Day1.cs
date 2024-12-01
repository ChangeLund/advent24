using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace advent24
{
    public class Day1
    {
        
        public static void SolveDay1()
        {
            var filePath = "C:\\Users\\Endre\\source\\repos\\advent24\\advent24\\Days\\1\\input.txt";
            var fileOutput = FileReaderUtil.ReadFile(filePath);
            Part1(fileOutput);
            Part2(fileOutput);
        }

        internal static void Part1(List<string> fileOutput)
        {
            Console.WriteLine("Running Day 1 part 1");
            

            var leftList = fileOutput.Select(c => c.Split("   ").First()).Order().ToList();
            var rightList = fileOutput.Select(c => c.Split("   ").Last()).Order().ToList();

            var sum = rightList.Select((c, i) =>
            {
                return CalculateDistane(int.Parse(c), int.Parse(leftList[i]));
            }).Sum();

            Console.WriteLine($"sum of Day part1: {sum}");
        }

        internal static void Part2(List<string> fileOutput)
        {
            Console.WriteLine("Running Day 1 part 2");

            var leftList = fileOutput.Select(c => c.Split("   ").First()).Order().ToList();
            var rightList = fileOutput.Select(c => c.Split("   ").Last()).Order().ToList();

            var sum = rightList.Select((c,i) =>
            {
                return CalculateSimelarity(int.Parse(c),leftList);
            }).Sum();

            Console.WriteLine($"Sum of Day1 part2 : {sum}");
        }

        internal static int CalculateDistane(int number1, int number2)
        {
            var calculatedNumber = Math.Abs(number1 - number2);

            return calculatedNumber;
        }

        internal static int CalculateSimelarity(int number1, List<string> list) {
            var count = list.Where(c => int.Parse(c) == number1).Count();

            var calculatedNumber = number1 * count;
            
            return calculatedNumber;
        }

    }
}