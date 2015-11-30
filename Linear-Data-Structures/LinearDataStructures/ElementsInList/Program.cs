// Write a program that reads from the console a sequence of positive integer numbers.
   
// The sequence ends when empty line is entered.
// Calculate and print the sum and average of the elements of the sequence.
// Keep the sequence in List<int>.

namespace ElementsInList
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;


    internal class Program
    {
        private static void Main()
        {

            var reader = new StringReader(@"1223
234
124
234
4343
345

");
            Console.SetIn(reader);

            var list = new List<int>();

            string line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                list.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Average());
        }
    }
}