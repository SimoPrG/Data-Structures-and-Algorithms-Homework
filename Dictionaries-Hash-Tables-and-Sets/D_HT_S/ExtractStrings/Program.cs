// Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.
//Example:
//    > {C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}
namespace ExtractStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = ExtractWordsMetOddTimes(new[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" });
            Console.WriteLine(string.Join(", ", result));
        }

        public static IEnumerable<string> ExtractWordsMetOddTimes(IEnumerable<string> sequence)
        {
            var dictionary = new Dictionary<string, bool>();
            foreach (var word in sequence)
            {
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word] = !dictionary[word];
                }
                else
                {
                    dictionary.Add(word, true);
                }
            }

            return dictionary.Where(p => p.Value).Select(p => p.Key);
        }
    }
}
