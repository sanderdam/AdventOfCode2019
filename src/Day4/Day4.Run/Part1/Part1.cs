using System;
using System.Diagnostics;
using System.Linq;

namespace Day4.Run.Part1
{
    public static class Part1
    {
        public static void Run(int startIndex, int endIndex)
        {
            Console.WriteLine("Starting calculations for day 4 - part 1");
            Stopwatch sw = Stopwatch.StartNew();

            // build array of possible passwords
            string[] possiblePasswords = Array.ConvertAll(Enumerable.Range(startIndex, (endIndex - startIndex)).ToArray(), _ => _.ToString());

            // check if each password can be valid
            int numberOfPasswordsThatMeetsCriteria = possiblePasswords.AsParallel().Count(password => CheckPasswordCriteria(password));

            sw.Stop();
            Console.WriteLine($"Total number of possible passwords: {numberOfPasswordsThatMeetsCriteria} and it tooks us {sw.ElapsedMilliseconds}ms.");
            Console.WriteLine("End of day 4 - part 1");
        }

        private static bool CheckPasswordCriteria(string password)
        {
            return password.LengthIsSix()
                   && password.AreAllDigits()
                   && password.DigitsOnlyIncreaseOrStayTheSame()
                   && password.TwoAdjacentDigitsAreTheSame();
        }
    }
}
