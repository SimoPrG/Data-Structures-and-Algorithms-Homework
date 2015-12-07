//We are given numbers N and M and the following operations:
//  * `N = N+1`
//  * `N = N+2`
//  * `N = N*2`

//  - Write a program that finds the shortest sequence of operations from the list above that starts from `N` and finishes in `M`.
//  - _Hint_: use a queue.
//  - Example: `N = 5`, `M = 16`
//  - Sequence: 5 &rarr; 7 &rarr; 8 &rarr; 16

namespace SequenceOfOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        public static void Main()
        {
            int start = 5;
            int end = 26;

            var sequence = GetShortestSequence(start, end);

            Console.WriteLine(string.Join(" -> ", sequence));
        }

        private static IEnumerable<int> GetShortestSequence(int start, int end)
        {
            var sequence = new Queue<int>();

            while (start <= end)
            {
                sequence.Enqueue(end);

                if (end / 2 > start)
                {
                    if (end % 2 == 0)
                    {
                        end /= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
                else
                {
                    if (end - 2 >= start)
                    {
                        end -= 2;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return sequence.Reverse();
        }
    }
}
