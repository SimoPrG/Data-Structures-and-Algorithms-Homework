// Write a method that finds the longest subsequence of equal numbers in given List<int> and returns
// the result as new `List<int>`.
// - Write a program to test whether the method works correctly.

namespace LongestSubSequence
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var sequence = new LongestSubSequenceFinder().FindLongestSubsequence(new List<int>() { 1, 1, 0, -1 });
            foreach (int number in sequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
