using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public static class MyExtensions
    {

        public static string Invert(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static int CountChar(this string str, char c)
        {
            if (string.IsNullOrEmpty(str)) return 0;
            return str.Count(x => x == c);
        }

        public static int CountOccurrences<T>(this T[] array, T value) where T : IEquatable<T>
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item.Equals(value)) count++;
            }
            return count;
        }

        public static T[] Unique<T>(this T[] array)
        {
            return array.Distinct().ToArray();
        }
    }
}