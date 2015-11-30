//   Write a program that counts how many times each word from given text file `words.txt` appears in it.
// The character casing differences should be ignored.The result words should be ordered by their number of
// occurrences in the text.Example:
//    `This is the TEXT. Text, text, text – THIS TEXT! Is this the text?`
//	>is -> 2
//	>the -> 2
//	>this -> 3
//	>text -> 6

namespace CountWordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    internal class Program
    {
        public static void Main()
        {
            string filepath = "../../words.txt";
            var result = CountWordsInFile(filepath);
            Console.WriteLine(string.Join(Environment.NewLine, result.Select(p => $"{p.Key} -> {p.Value}")));
        }

        public static IDictionary<string, int> CountWordsInFile(string filepath)
        {
            var rgx = new Regex(@"\b\w+\b");

            using (var reader = new StreamReader(filepath))
            {
                var dictionary = new Dictionary<string, int>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    var words = rgx.Matches(line);
                    foreach (string wordToLower in from Match word in words select word.Value.ToLower())
                    {
                        if (dictionary.ContainsKey(wordToLower))
                        {
                            ++dictionary[wordToLower];
                        }
                        else
                        {
                            dictionary.Add(wordToLower, 1);
                        }
                    }
                }

                return dictionary;
            }
        }
    }
}
