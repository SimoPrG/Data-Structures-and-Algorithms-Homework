// Write a program that reads a sequence of integers(`List<int>`) ending with an empty line and
// sorts them in an increasing order.

namespace SortNumbersWithList
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class Program
    {
        private static void Main()
        {

            var reader = new StringReader(@"987
1675
987
38
896
987

");
            Console.SetIn(reader);

            var list = new List<int>();

            string line = Console.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                list.Add(int.Parse(line));
                line = Console.ReadLine();
            }

            list.Sort();

            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
        }
    }
}