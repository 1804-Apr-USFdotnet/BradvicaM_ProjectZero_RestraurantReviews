using System;

namespace Library
{
    public static class Palindrome
    {
        public static bool IsPalindrome(string value)
        {
            var str = CompressString(value);

            var asCharArray = str.ToCharArray();
            var reversed = string.Copy(str).ToCharArray();
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

        public static string CompressString(string value)
        {
            var str = value.ToLower();

            string returnString = null;

            foreach (var t in str)
            {
                if (!(char.IsPunctuation(t) || char.IsWhiteSpace(t)))
                {
                    returnString += t;
                }
            }

            return returnString;
        }
    }
}
