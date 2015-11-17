using System;
using System.Collections.Generic;

public class Program
{
    private static int result = 0;
    private static int divisorsCount = int.MaxValue;

    private static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var digits = new int[n];
        for (int i = 0; i < n; i++)
        {
            digits[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(digits);

        PermuteRep(digits, 0, n);

        Console.WriteLine(result);
    }

    private static void PermuteRep(int[] arr, int start, int n)
    {
        Check(ConvertDigitArrayToNumber(arr));
        for (int left = n - 2; left >= start; left--)
        {
            for (int right = left + 1; right < n; right++)
                if (arr[left] != arr[right])
                {
                    Swap(ref arr[left], ref arr[right]);
                    PermuteRep(arr, left + 1, n);
                }
            var firstElement = arr[left];
            for (int i = left; i < n - 1; i++)
                arr[i] = arr[i + 1];
            arr[n - 1] = firstElement;
        }
    }

    private static void Swap<T>(ref T first, ref T second)
    {
        var old = first;
        first = second;
        second = old;
    }

    private static int ConvertDigitArrayToNumber(int[] arr)
    {
        int result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            result += (int)Math.Pow(10, i) * arr[i];
        }

        return result;
    }

    private static void Check(int number)
    {
        int divisors = 1;
        int half = number / 2 + 1;
        for (int i = 2; i <= half; i++)
        {
            if (number % i == 0)
            {
                divisors++;
            }
        }

        if (divisors < divisorsCount || (divisors == divisorsCount && number < result))
        {
            divisorsCount = divisors;
            result = number;
        }
    }

    private static void Print<T>(IEnumerable<T> collection)
    {
        Console.WriteLine(string.Join("", collection));
    }
}