// Write a program that counts in a given array of `double` values the number of occurrences of each value.
// Use `Dictionary<TKey, TValue>`.
//    >Example: array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
//    >-2.5 -> 2 times
//    >3 -> 4 times
//    >4 -> 3 times

namespace CountDoubles
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public static void Main()
        {
            var result = CountDoublesInCollection(new [] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 });
            foreach (var pair in result)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }

        public static IDictionary<double, int> CountDoublesInCollection(IEnumerable<double> doubles)
        {
            var result = new Dictionary<double, int>();
            foreach (var d in doubles)
            {
                if (result.ContainsKey(d))
                {
                    ++result[d];
                }
                else
                {
                    result.Add(d, 1);
                }
            }

            return result;
        }
    }
}
