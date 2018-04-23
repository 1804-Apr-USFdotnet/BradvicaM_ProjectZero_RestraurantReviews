using System;

namespace Library
{
    public static class Palindrome
    {
        public static bool IsPalindrome(string value)
        {
            var str = value.ToLower();

            string compressed = null;

            foreach (var t in str)
            {
                if (!(char.IsPunctuation(t) || char.IsWhiteSpace(t)))
                {
                    compressed += t;
                }
            }

            var asCharArray = compressed.ToCharArray();
            var reversed = string.Copy(compressed).ToCharArray();
            Array.Reverse(reversed);

            return Compare(asCharArray, reversed);
        }

        public static bool IsPalindrome(int value)
        {
            var asCharArray = value.ToString().ToCharArray();

            var reversed = new char[asCharArray.Length];
            asCharArray.CopyTo(reversed, 0);

            Array.Reverse(reversed);

            return Compare(asCharArray, reversed);
        }

        private static bool Compare(char[] a, char[] b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
