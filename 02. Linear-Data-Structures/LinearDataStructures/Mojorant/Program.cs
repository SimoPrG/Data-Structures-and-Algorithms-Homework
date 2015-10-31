//* The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.
//  - Write a program to find the majorant of given array(if exists).
//  - Example:
//    - `{2, 2, 3, 3, 2, 3, 4, 3, 3}` &rarr; `3`

namespace Mojorant
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static void Main()
        {
            var result = GetMajorant(new [] { 2, 2, 3, 3, 2, 3, 4, 3, 3 });
            Console.WriteLine(result?.ToString() ?? "No majorant");
        }

        public static int? GetMajorant(IEnumerable<int> sequence)
        {
            var occurances = new Dictionary<int, int>();
            foreach (int number in sequence)
            {
                if (occurances.ContainsKey(number))
                {
                    ++occurances[number];
                }
                else
                {
                    occurances.Add(number, 1);
                }
            }

            int count = sequence.Count();
            var majorant = occurances.FirstOrDefault(p => p.Value >= (count / 2) + 1);
            bool isMajorant = !majorant.Equals(default(KeyValuePair<int, int>));

            return isMajorant ? (int?)majorant.Key : null;
        }
    }
}
