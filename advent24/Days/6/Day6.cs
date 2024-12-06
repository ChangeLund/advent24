using System;
using System.Collections.Generic;
using System.Linq;

namespace advent24
{
    public class Day6
    {
        public static void SolveDay6()
        {
            var testInput = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\6\\text.txt");
            var input = FileReaderUtil.ReadFile("C:\\Users\\enlund\\source\\repos\\advent24\\advent24\\Days\\6\\input.txt");

            Part1(testInput);
            //Part2(testInput);
        }

        internal static void Part1(List<string> input)
        {
            var matrix = input.Select(x => x.ToCharArray()).ToList();
            var matrixHeight = matrix.Count;
            var matrixWidth = matrix.First().Length;

            bool isStillInThere = true;
            int[] pointerArray = { 0, 0 };

            char pointer = '^';
            int xCount = 1;

            var pointerPosition = matrix
                .SelectMany((row, rowIndex) => row.Select((cell, colIndex) => new { cell, rowIndex, colIndex }))
                .FirstOrDefault(x => x.cell == pointer);

            pointerArray[0] = pointerPosition.rowIndex;
            pointerArray[1] = pointerPosition.colIndex;

            while (isStillInThere)
            {

                if (pointerArray[0] < 0 || pointerArray[0] >= matrixHeight || pointerArray[1] < 0 || pointerArray[1] >= matrixWidth) isStillInThere = false;
                else
                {
                    if (matrix[pointerArray[0]][pointerArray[1]] == '.')
                    {
                        matrix[pointerArray[0]][pointerArray[1]] = 'X';
                        xCount++;
                    }

                    if (matrix[pointerArray[0]][pointerArray[1]] == '#')
                    {
                        pointerArray = MoveBack(pointer, pointerArray);
                        pointer = TurnRight(pointer);
                    }

                    pointerArray = GetNextPosition(pointer, pointerArray);
                }
            }

            Console.WriteLine(xCount);
        }


        internal static void Part2(List<string> input)
        {

        }

        private static int[] GetNextPosition(char pointer, int[] pointerArray)
        {
            int[] directionRow = { -1, 1, 0, 0 };
            int[] directionCol = { 0, 0, -1, 1 };

            int[] newPosition = (int[])pointerArray.Clone();

            switch (pointer)
            {
                case '^':
                    newPosition[0] += directionRow[0];
                    newPosition[1] += directionCol[0];
                    break;
                case 'v':
                    newPosition[0] += directionRow[1];
                    newPosition[1] += directionCol[1];
                    break;
                case '<':
                    newPosition[0] += directionRow[2];
                    newPosition[1] += directionCol[2];
                    break;
                case '>':
                    newPosition[0] += directionRow[3];
                    newPosition[1] += directionCol[3];
                    break;
            }

            return newPosition;
        }

        private static int[] MoveBack(char pointer, int[] pointerArray)
        {
            int[] directionRow = { 1, -1, 0, 0 };
            int[] directionCol = { 0, 0, 1, -1 };

            switch (pointer)
            {
                case '^':
                    pointerArray[0] += directionRow[0];
                    pointerArray[1] += directionCol[0];
                    break;
                case 'v':
                    pointerArray[0] += directionRow[1];
                    pointerArray[1] += directionCol[1];
                    break;
                case '<':
                    pointerArray[0] += directionRow[2];
                    pointerArray[1] += directionCol[2];
                    break;
                case '>':
                    pointerArray[0] += directionRow[3];
                    pointerArray[1] += directionCol[3];
                    break;
            }

            return pointerArray;
        }

        private static char TurnRight(char pointer)
        {
            return pointer switch
            {
                '^' => '>',
                '>' => 'v',
                'v' => '<',
                '<' => '^',
                _ => pointer
            };
        }


        internal static int[] SwitchDirection(char pointer, int[] pointerArray)
        {
            int[] directionRow = { -1, 1, 0, 0 };
            int[] directionCol = { 0, 0, -1, 1 };
            switch (pointer)
            {
                case '^':
                    pointerArray[0] += directionRow[0];
                    pointerArray[1] += directionCol[0];
                    break;
                case 'v':
                    pointerArray[0] += directionRow[1];
                    pointerArray[1] += directionCol[1];
                    break;
                case '<':
                    pointerArray[0] += directionRow[2];
                    pointerArray[1] += directionCol[2];
                    break;
                case '>':
                    pointerArray[0] += directionRow[3];
                    pointerArray[1] += directionCol[3];
                    break;
            }

            return pointerArray;
        }


    }
}