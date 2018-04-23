using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        public void IsPalindrome_GivenValidString_ReturnsTrue()
        {
            var result = Palindrome.IsPalindrome("racecar");

            const bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPalindrome_GivenValidStringWithSpecialCharacters_ReturnsTrue()
        {
            var result = Palindrome.IsPalindrome("never Odd, or Even");

            const bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPalindrome_GivenInValidString_ReturnsFalse()
        {
            var result = Palindrome.IsPalindrome("north american");

            const bool expected = false;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPalindrome_GivenValidInteger_ReturnsTrue()
        {
            var result = Palindrome.IsPalindrome(1331);

            const bool expected = true;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void IsPlaindrome_GivenInvalidInteger_ReturnsFalse()
        {
            var result = Palindrome.IsPalindrome(1475);

            const bool expected = false;

            Assert.AreEqual(expected, result);
        }
    }
}
