using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent24;

public class Day4
{

    public static void SolveDay4()
    {
        var input = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\4\\input.txt");
        var testInput = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\4\\test.txt");
        Part1(testInput);
        Part2(input);
    }


    internal static void Part1(List<string> input)
    {
        int countXmas = 0;
        int matrixHeight = input.Count;
        int matrixWidth = input.First().Length;

        for (int j = 0; j < matrixHeight; j++)
        {
            for (int i = 0; i < matrixWidth; i++)
            {
                if (input[j][i] == 'X')
                {
                    //Check all directions possible:

                    //Høyre
                    if (i + 3 < matrixWidth && input[j][i + 1] == 'M' && input[j][i + 2] == 'A' && input[j][i + 3] == 'S') countXmas++;

                    //Venstre
                    if (i - 3 >= 0 && input[j][i - 1] == 'M' && input[j][i - 2] == 'A' && input[j][i - 3] == 'S') countXmas++;

                    //Nedover
                    if (j + 3 < matrixHeight && input[j + 1][i] == 'M' && input[j + 2][i] == 'A' && input[j + 3][i] == 'S') countXmas++;

                    //Opp
                    if (j - 3 >= 0 && input[j - 1][i] == 'M' && input[j - 2][i] == 'A' && input[j - 3][i] == 'S') countXmas++;

                    // Diagonal ned høyre
                    if (i + 3 < matrixWidth && j + 3 < matrixHeight && input[j + 1][i + 1] == 'M' && input[j + 2][i + 2] == 'A' && input[j + 3][i + 3] == 'S') countXmas++;

                    // Diagonal ned venstre
                    if (i - 3 >= 0 && j + 3 < matrixHeight && input[j + 1][i - 1] == 'M' && input[j + 2][i - 2] == 'A' && input[j + 3][i - 3] == 'S') countXmas++;

                    // Diagonal opp høyre
                    if (i + 3 < matrixWidth && j - 3 >= 0 && input[j - 1][i + 1] == 'M' && input[j - 2][i + 2] == 'A' && input[j - 3][i + 3] == 'S') countXmas++;

                    // Diagonal opp venstre
                    if (i - 3 >= 0 && j - 3 >= 0 && input[j - 1][i - 1] == 'M' && input[j - 2][i - 2] == 'A' && input[j - 3][i - 3] == 'S') countXmas++;

                }
            }
        }

        Console.WriteLine($"Total {countXmas}");
    }

    internal static void Part2(List<string> input)
    {
        int countMas = 0;
        int matrixHeight = input.Count;
        int matrixWidth = input.First().Length;

        for (int j = 1; j < matrixHeight - 1; j++)
        {
            for (int i = 1; i < matrixWidth - 1 ; i++)
            {
                if (input[j][i] == 'A')
                {
                    //Check all directions possible:
                    // Diagonal ned høyre ---- Kryss med M.S øverst
                    if (input[j-1][i - 1] == 'M' && input[j - 1][i + 1] == 'S' && input[j + 1][i + 1] == 'S' && input[j + 1][i - 1] == 'M') countMas++;

                    // Diagonal ned høyre ---- Kryss med S.M øverst
                    if (input[j - 1][i - 1] == 'S' && input[j - 1][i + 1] == 'M' && input[j + 1][i + 1] == 'M' && input[j + 1][i - 1] == 'S') countMas++;

                    // Diagonal ned høyre ---- Kryss med M.M øverst
                    if (input[j - 1][i - 1] == 'M' && input[j - 1][i + 1] == 'M' && input[j + 1][i + 1] == 'S' && input[j + 1][i - 1] == 'S') countMas++;

                    // Diagonal ned høyre ---- Kryss med S.S øverst
                    if (input[j - 1][i - 1] == 'S' && input[j - 1][i + 1] == 'S' && input[j + 1][i + 1] == 'M' && input[j + 1][i - 1] == 'M') countMas++;
                }
            }
        }

        Console.WriteLine($"Total X-MAS: {countMas}");

    }
}
