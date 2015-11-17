using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(1L << Console.ReadLine().Count(c => c == '*'));
    }
}