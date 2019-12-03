using Day2.Part1;
using Day2.Part2;

using System;
using System.IO;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ReadInputFile("input.txt");
            int[] integers = ConvertInputToArrayOfIntegers(input);

            int[] integersForPart1 = new int[integers.Length];
            integers.CopyTo(integersForPart1, 0);
            Part1Calculation.Part1(integersForPart1);

            int[] integersForPart2 = new int[integers.Length];
            integers.CopyTo(integersForPart2, 0);
            Part2Calculation.Part2(integersForPart2);
        }        

        private static int[] ConvertInputToArrayOfIntegers(string input)
        {
            int[] integers = Array.ConvertAll(input.Split(','), s => int.Parse(s));
            return integers;
        }

        private static string ReadInputFile(string fileName)
        {
            string input = File.ReadAllText(fileName);
            return input;
        }
    }
}
