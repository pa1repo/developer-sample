using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {

            if (n <= 1) return 1;

            return n * GetFactorial(n - 1);
        }

        public static string FormatSeparators(params string[] items)
        {
            int itemCount = items.Length;

            if (itemCount == 0)
                return string.Empty;

            if (itemCount == 1)
                return items[0];

            if (itemCount == 2)
                return $"{items[0]} and {items[1]}";


            string joinedItems = string.Join(", ", items.Take(itemCount - 1));
            return $"{joinedItems} and {items[itemCount - 1]}";
        }
    }
}