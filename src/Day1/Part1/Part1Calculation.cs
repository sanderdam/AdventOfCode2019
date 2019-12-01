using System;
using System.Diagnostics;
using System.Linq;

namespace Day1.Part1
{
    public class Part1Calculation
    {
        public static void Part1(int[] moduleMasses)
        {
            Console.WriteLine("Starting calculations for part 1");

            Stopwatch sw1 = Stopwatch.StartNew();
            int totalFuelRequirement = moduleMasses.AsParallel().Sum(moduleMass => CalculateRequiredFuelForModule(moduleMass));
            sw1.Stop();

            Console.WriteLine($"Total fuel required: {totalFuelRequirement} and it tooks us {sw1.ElapsedMilliseconds}ms.");

            Console.WriteLine("End of part 1");
        }

        public static int CalculateRequiredFuelForModule(int mass)
        {
            double c1 = mass / 3;
            int c2 = (int)Math.Floor(c1);
            int c3 = c2 - 2;

            return c3;
        }
    }
}
