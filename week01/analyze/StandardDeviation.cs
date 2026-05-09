using System;
using System.Linq;

/// <summary>
/// These 3 functions calculate the standard deviation
/// in different ways.
/// </summary>
public static class StandardDeviation
{
    public static void Run()
    {
        var numbers = new[] { 600, 470, 170, 430, 300 };

        Console.WriteLine(StandardDeviation1(numbers)); // 147.322
        Console.WriteLine(StandardDeviation2(numbers)); // 147.322
        Console.WriteLine(StandardDeviation3(numbers)); // 147.322
    }

    /// <summary>
    /// Calculates standard deviation using two loops.
    /// Big O = O(n)
    /// </summary>
    private static double StandardDeviation1(int[] numbers)
    {
        var total = 0.0;
        var count = 0;

        // First loop:
        // Calculate total and count
        foreach (var number in numbers)
        {
            total += number;
            count += 1;
        }

        var avg = total / count;

        var sumSquaredDifferences = 0.0;

        // Second loop:
        // Calculate squared differences
        foreach (var number in numbers)
        {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;

        // Two separate O(n) loops
        // O(n) + O(n) = O(n)

        return Math.Sqrt(variance);
    }

    /// <summary>
    /// Calculates standard deviation using nested loops.
    /// Big O = O(n^2)
    /// </summary>
    private static double StandardDeviation2(int[] numbers)
    {
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;

        // Outer loop runs n times
        foreach (var number in numbers)
        {
            var total = 0;
            var count = 0;

            // Inner loop also runs n times
            foreach (var value in numbers)
            {
                total += value;
                count += 1;
            }

            var avg = total / count;

            sumSquaredDifferences += Math.Pow(number - avg, 2);

            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;

        // Nested loops:
        // n * n = O(n^2)

        return Math.Sqrt(variance);
    }

    /// <summary>
    /// Calculates standard deviation using Sum().
    /// Big O = O(n)
    /// </summary>
    private static double StandardDeviation3(int[] numbers)
    {
        var count = numbers.Length;

        // Sum() loops through the array once
        var avg = (double)numbers.Sum() / count;

        var sumSquaredDifferences = 0.0;

        // Another loop through the array
        foreach (var number in numbers)
        {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;

        // O(n) + O(n) = O(n)

        return Math.Sqrt(variance);
    }
}