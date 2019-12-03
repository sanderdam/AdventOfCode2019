using System;
using System.Diagnostics;

namespace Day2.Part1
{
    class Part1Calculation
    {
        public static void Part1(int[] integers)
        {
            RestoreState(integers);
            Calculate(integers);
        }

        private static void RestoreState(int[] integers)
        {
            integers[1] = 12;
            integers[2] = 2;
        }

        public static void Calculate(int[] integers)
        {
            Console.WriteLine("Starting calculations for day 2 - part 1");
            Stopwatch sw = Stopwatch.StartNew();

            int position = 0;

            while (integers[position] != 99)
            {
                int opCode = integers[position];
                int positionOfValue1 = integers[position + 1];
                int positionOfValue2 = integers[position + 2];
                int positionOfOutput = integers[position + 3];

                int value1 = integers[positionOfValue1];
                int value2 = integers[positionOfValue2];

                int result = 0;
                switch (opCode)
                {
                    case 1: // add values

                        result = value1 + value2;
                        break;
                    case 2: // multiple values

                        result = value1 * value2;
                        break;
                }

                integers[positionOfOutput] = result;

                position = position + 4; // set position for next iteration
            }

            sw.Stop();

            Console.WriteLine($"Result: {integers[0]}, found in {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("End of day 2 - part 1");
        }
    }
}
