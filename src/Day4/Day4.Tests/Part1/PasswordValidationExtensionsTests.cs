
using Day4.Run.Part1;

using NUnit.Framework;

namespace Day4.Tests.Part1
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

        [TestCase("11256")]
        [TestCase("54565512")]
        [TestCase("9754221")]
        [TestCase("21369884")]
        [TestCase("18898")]
        [TestCase("221")]
        [TestCase("988")]
        [TestCase("8945988")]
        public void TwoAdjacentDigitsAreTheSame_ShouldReturnTrue(string password)
        {
            Assert.IsTrue(password.TwoAdjacentDigitsAreTheSame());
        }

        [TestCase("975421")]
        [TestCase("5945613")]
        [TestCase("512154531")]
        [TestCase("897542158129898")]
        public void TwoAdjacentDigitsAreTheSame_ShouldReturnFalse(string password)
        {
            Assert.IsFalse(password.TwoAdjacentDigitsAreTheSame());
        }
    }
}