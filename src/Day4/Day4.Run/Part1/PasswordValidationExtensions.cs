using System.Linq;

namespace Day4.Run.Part1
{
    public static class PasswordValidationExtensions
    {
        /// <summary>
        /// Check if all characters in a given <paramref name="password"/> are digits
        /// </summary>
        /// <param name="password">The password to check for digits only</param>
        /// <returns>True if the given <paramref name="password"/> contains only digits</returns>
        public static bool AreAllDigits(this string password)
        {
            return password.All(ch => char.IsDigit(ch));
        }

        /// <summary>
        /// Check to see if the given <paramref name="password"/> length is 6
        /// </summary>
        /// <param name="password">A password to check if the length is six</param>
        /// <returns>True when the given <paramref name="password"/>'s length is six</returns>
        public static bool LengthIsSix(this string password)
        {
            return password.Length == 6;
        }

        /// <summary>
        /// Determine if digits only increase
        /// We do this by sorting the characters in the string, so '34256' will automatically be '23456'.
        /// The <paramref name="password"/> digits only increase or stay the same, if the sorted password equals the given <paramref name="password"/>
        /// </summary>
        /// <param name="password">A password to check for digits to increase or stay the same</param>
        /// <returns>True if the given<paramref name="password"/>'s digits only increases or stay the same</returns>
        public static bool DigitsOnlyIncreaseOrStayTheSame(this string password)
        {
            string sortedPassword = string.Concat(password.OrderBy(c => c));
            return password.Equals(sortedPassword);
        }

        public static bool TwoAdjacentDigitsAreTheSame(this string password)
        {
            // loop through all characters except the first one
            // foreach each loop, check to see if the previous characters matches the one in the current loop

            for (int i = 1; i < password.Length; i++)
            {
                char currentChar = password[i];

                if (currentChar.Equals(password[i - 1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
