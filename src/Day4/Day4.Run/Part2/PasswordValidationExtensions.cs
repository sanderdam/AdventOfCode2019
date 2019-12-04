using System.Linq;

namespace Day4.Run.Part2
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

        public static bool TwoAdjacentDigitsAreTheSameButNotPartOfALargerGroupOfMatchingDigits(this string password)
        {
            // TODO SD: This probably should be more easy to write...
            for (int i = 0; i < password.Length - 1; i++)
            {
                char currentChar = password[i];

                if (i == 0) // when it is the first digit
                {
                    if (currentChar.Equals(password[i + 1]) && !currentChar.Equals(password[i + 2]))
                        return true;
                }

                if (i == password.Length - 2) // when this is the one before the last digit
                {
                    return currentChar.Equals(password[i + 1]) && !currentChar.Equals(password[i - 1]);
                }

                // and any other charachter in the password
                if (currentChar.Equals(password[i + 1])
                    && !currentChar.Equals(password[i + 2])
                    && !currentChar.Equals(password[i - 1]))
                    return true;
                continue;
            }

            return false;
        }
    }
}
