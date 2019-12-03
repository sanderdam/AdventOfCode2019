using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = ReadInputFile("input.txt");
            Part1.Part1Calculation.Part1(lines);
            Part2.Part2Calculation.Part2(lines);
        }

        private static string[] ReadInputFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            return lines;
        }
    }
}
