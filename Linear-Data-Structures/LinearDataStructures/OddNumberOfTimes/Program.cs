//Write a program that removes from given sequence all numbers that occur odd number of times.
//  - _Example_:
//      - `{ 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}` &rarr; `{5, 3, 3, 5}`

namespace OddNumberOfTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static void Main()
        {
            var sequence = new List<int> {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2};
            var resultSequence = RemoveOddOccuranceses(sequence);
            Console.WriteLine(string.Join(", ", resultSequence));
        }

        public static IEnumerable<int> RemoveOddOccuranceses(IEnumerable<int> sequence)
        {
            var areOcurancecesOdd = new Dictionary<int, bool>();
            foreach (int number in sequence)
            {
                if (areOcurancecesOdd.ContainsKey(number))
                {
                    areOcurancecesOdd[number] = !areOcurancecesOdd[number];
                }
                else
                {
                    areOcurancecesOdd.Add(number, true);
                }
            }

            return sequence.Where(number => !areOcurancecesOdd[number]).ToList();
        }
    }
}
