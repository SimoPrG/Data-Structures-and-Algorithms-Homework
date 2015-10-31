//Write a program that finds in given array of integers(all belonging to the range[0..1000]) how many times each of them occurs.
//  - Example: `array = {3, 4, 4, 2, 3, 3, 4, 3, 2}`
//    - 2 &rarr; 2 times
//    - 3 &rarr; 4 times
//    - 4 &rarr; 3 times

namespace OcurancesesInAray
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        public static void Main()
        {
            var result = GetOcuranceses(new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 });
            foreach (var pair in result)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }

        public static IDictionary<int, int> GetOcuranceses(IEnumerable<int> sequence)
        {
            var result = new Dictionary<int, int>();
            foreach (int number in sequence)
            {
                if (result.ContainsKey(number))
                {
                    ++result[number];
                }
                else
                {
                    result.Add(number, 1);
                }
            }

            return result;
        }
    }
}
