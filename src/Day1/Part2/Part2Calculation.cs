using System;
using System.Diagnostics;
using System.Linq;

namespace Day1.Part2
{
    public class Part2Calculation
    {
        public static void Part2(int[] moduleMasses)
        {
            Console.WriteLine("Starting calculations for day 1 - part 2");

            Stopwatch sw2 = Stopwatch.StartNew();
            int totalFuelRequirement = moduleMasses.AsParallel().Sum(moduleMass => CalculateRequiredFuelForMass(moduleMass));
            sw2.Stop();
            Console.WriteLine($"Total fuel required: {totalFuelRequirement} and it tooks us {sw2.ElapsedMilliseconds}ms.");

            Console.WriteLine("End of day 1 - part 2");
        }

        public static int CalculateRequiredFuelForMass(int mass)
        {
            double c1 = mass / 3;
            int c2 = (int)Math.Floor(c1);
            int c3 = c2 - 2;

            if (c3 <= 0) return 0;

            return c3 + CalculateRequiredFuelForMass(c3);
        }
    }
}
