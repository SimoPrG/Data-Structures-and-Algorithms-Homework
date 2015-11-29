namespace Rabbis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var answers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = answers.Length - 1;
            var dict = new Dictionary<int, double>();
            for (int i = 0; i < n; i++)
            {
                int ansewer = answers[i] + 1;
                if (dict.ContainsKey(ansewer))
                {
                    dict[ansewer]++;
                }
                else
                {
                    dict.Add(ansewer, 1);
                }
            }

            double answer = 0;
            foreach (var kvp in dict)
            {
                answer += kvp.Key * Math.Ceiling(kvp.Value / kvp.Key);
            }

            Console.WriteLine(answer);
        }
    }
}