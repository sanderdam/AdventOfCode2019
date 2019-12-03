using System;
using System.Diagnostics;

namespace Day2.Part2
{
    class Part2Calculation
    {
        public static void Part2(int[] integers)
        {
            Console.WriteLine("Starting calculations for day 2 - part 2");
            Stopwatch sw = Stopwatch.StartNew();

            int finalResult = 0;
            try
            {
                (int noun, int verb) = TryEveryNounAndVerb(integers, 19690720);
                finalResult = 100 * noun + verb;
            }
            catch (NoResultFoundException)
            {
                Console.WriteLine("No result was found for the input integers");
            }
                       
            sw.Stop();

            Console.WriteLine($"Result: {finalResult}, found in {sw.ElapsedMilliseconds}ms");
            Console.WriteLine("End of day 2 - part 2");
        }

        private static (int noun, int verb) TryEveryNounAndVerb(int[] originalArray, int outputToFind)
        {
            for (int noun = 0; noun <= 99; noun++)
            {
                for (int verb = 0; verb <= 99; verb++)
                {
                    // create copy of array to work with
                    int[] copyOfIntegers = new int[originalArray.Length];
                    originalArray.CopyTo(copyOfIntegers, 0);

                    RestoreState(copyOfIntegers, noun, verb);
                    int result = Calculate(copyOfIntegers);

                    if (result == outputToFind)
                    {
                        return (noun, verb);
                    }
                }
            }

            throw new NoResultFoundException("No result found for this input");
        }

        private static void RestoreState(int[] integers, int noun, int verb)
        {
            integers[1] = noun;
            integers[2] = verb;
        }

        public static int Calculate(int[] integers)
        {
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

            return integers[0];
        }
    }
}
