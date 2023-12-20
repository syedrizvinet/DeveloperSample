using System;
using System.Xml.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n) {
            if (n < 0)
            {
                throw new ArgumentException("Input must be a non-negative integer.", nameof(n));
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }
            int result = 1;
            for (int i= n; i>0; i--)
            {
                result *=i;
            }
            return result;
        }

        public static string FormatSeparators(params string[] items) {
            
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            int length = items.Length;

            if (length == 0)
            {
                return String.Empty;
            }

            if (length == 1)
            {
                return items[0];
            }
            string result = String.Join(", ", items, 0, length - 1); 
            result += $" and {items[length - 1]}";

            return result;
        }
    }
}