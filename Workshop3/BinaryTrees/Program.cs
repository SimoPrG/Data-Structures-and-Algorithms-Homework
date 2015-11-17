namespace BinaryTrees
{
    using System;
    using System.Numerics;

    public class Program
    {
        private static long[] memo;
        private static long Trees(int n)
        {
            if (n == 0)
            {
                return 1L;
            }

            if (memo[n] > 0)
            {
                return memo[n];
            }

            long result = 0;
            for (int i = 0; i < n; i++)
            {
                result += Trees(i) * Trees((n - 1 - i));
            }

            memo[n] = result;
            return result;
        }

        public static void Main()
        {
            memo = new long[32];
            string input = Console.ReadLine();
            var groups = new int[26];

            foreach (var ball in input)
            {
                ++groups[ball - 'A'];
            }

            int n = input.Length;

            var factorials = new long[n + 1];
            factorials[0] = 1;
            for (int i = 0; i < n; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

            long result = factorials[n];
            foreach (var x in groups)
            {
                result /= factorials[x];
            }

            BigInteger total = result;
            total *= Trees(n);
            Console.WriteLine(total);
        }
    }
}
