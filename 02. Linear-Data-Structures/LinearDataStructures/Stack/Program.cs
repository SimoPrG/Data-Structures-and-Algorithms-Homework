// Write a program that reads N integers from the console and reverses them using a stack.

// Use the Stack<int> class.

using System.Collections.Generic;

namespace ReverseIntegersWithStack
{
    using System;
    using System.IO;

    internal class Program
    {
        static void Main()
        {

            var reader = new StringReader(@"5
1
2
3
4
5
");
            Console.SetIn(reader);

            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
