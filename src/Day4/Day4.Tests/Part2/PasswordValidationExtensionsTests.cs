
using Day4.Run.Part2;

using NUnit.Framework;

namespace Day4.Tests.Part2
{
    [TestFixture]
    public class PasswordValidationExtensionsTests
    {
        [TestCase("22")]
        public void AreAllDigits_ShouldReturnTrue(string password)
        {
            Assert.IsTrue(password.AreAllDigits());
        }

        [TestCase("ggg")]
        [TestCase("a6d7848")]
        public void AreAllDigits_ShouldReturnFalse(string password)
        {
            Assert.IsFalse(password.AreAllDigits());
        }


        [TestCase("666666")]
        
        [TestCase("7777a7")]
        [TestCase("7777a7")]
        public void LengthIsSix_ShouldReturnTrue(string password)
        {
            Assert.IsTrue(password.LengthIsSix());
        }

        [TestCase("7777777")]
        [TestCase("11111")]
        [TestCase("77aa7")]
        [TestCase("7777777")]        
        [TestCase("77aa7")]
        [TestCase("77aa777")]
        [TestCase("11111")]
        [TestCase("666")]
        public void LengthIsSix_ShouldReturnFalse(string password)
        {
            Assert.IsFalse(password.LengthIsSix());
        }

        [TestCase("1234")]
        [TestCase("239")]        
        [TestCase("111189")]
        [TestCase("12")]
        [TestCase("89")]
        [TestCase("5556789")]
        public void DigitsOnlyIncreaseOrStayTheSame_ShouldReturnTrue(string password)
        {
            Assert.IsTrue(password.DigitsOnlyIncreaseOrStayTheSame());
        }

        [TestCase("8945")]
        [TestCase("988")]
        [TestCase("784556")]
        [TestCase("123321")]
        [TestCase("18898")]
        [TestCase("21")]
        [TestCase("98")]
        [TestCase("4562333321")]
        public void DigitsOnlyIncreaseOrStayTheSame_ShouldReturnFalse(string password)
        {
            Assert.IsFalse(password.DigitsOnlyIncreaseOrStayTheSame());
        }

        [TestCase("112233")]
        [TestCase("54565512")]
        [TestCase("9754221")]
        [TestCase("21369884")]
        [TestCase("18898")]
        [TestCase("8945988")]
        [TestCase("111122")]
        public void TwoAdjacentDigitsAreTheSameButNotPartOfALargerGroupOfMatchingDigits_ShouldReturnTrue(string password)
        {
            Assert.IsTrue(password.TwoAdjacentDigitsAreTheSameButNotPartOfALargerGroupOfMatchingDigits());
        }

        [TestCase("975421")]
        [TestCase("5945613")]
        [TestCase("512154531")]
        [TestCase("123444")]
        [TestCase("368889")]
        public void TwoAdjacentDigitsAreTheSameButNotPartOfALargerGroupOfMatchingDigits_ShouldReturnFalse(string password)
        {
            Assert.IsFalse(password.TwoAdjacentDigitsAreTheSameButNotPartOfALargerGroupOfMatchingDigits());
        }
    }
}