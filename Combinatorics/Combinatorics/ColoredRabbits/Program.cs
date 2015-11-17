using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var dict = new Dictionary<int, double>();
        for (int i = 0; i < n; i++)
        {
            int ansewer = int.Parse(Console.ReadLine()) + 1;
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
