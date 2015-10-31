//Write a program that removes from given sequence all negative numbers.

namespace NegativeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var result = new NegativeNumbersRemover().RemoveNegativeNumbers(new List<int> {-3, 2, 234, -234, 0});
            result.ToList().ForEach(Console.WriteLine);
        }
    }
}
