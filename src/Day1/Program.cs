using Day1.Part1;
using Day1.Part2;

using System;
using System.IO;

namespace Day1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = ReadInputFile("input.txt");
            Part1Calculation.Part1(input);
            Part2Calculation.Part2(input);
        }

        public static int[] ReadInputFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int[] moduleMasses = Array.ConvertAll(lines, line => int.Parse(line));

            return moduleMasses;
        }
    }
}
