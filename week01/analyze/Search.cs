using System;
using System.Diagnostics;
using System.Linq;

public static class Search
{
    public static void Run()
    {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}",
            "n",
            "sort1-count",
            "sort2-count",
            "sort1-time",
            "sort2-time");

        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}",
            "----------");

        for (int n = 0; n <= 25000; n += 1000)
        {
            var testData = Enumerable.Range(0, n).ToArray();

            int count1 = SearchSorted1(testData, n);

            int count2 = SearchSorted2(
                testData,
                n,
                0,
                testData.Length - 1
            );

            double time1 = Time(() => SearchSorted1(testData, n), 100);

            double time2 = Time(() =>
                SearchSorted2(testData, n, 0, testData.Length - 1), 100);

            Console.WriteLine(
                "{0,15}{1,15}{2,15}{3,15:0.00000}{4,15:0.00000}",
                n,
                count1,
                count2,
                time1,
                time2
            );
        }
    }

    private static double Time(Action executeAlgorithm, int times)
    {
        var sw = Stopwatch.StartNew();

        for (var i = 0; i < times; ++i)
        {
            executeAlgorithm();
        }

        sw.Stop();

        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// Search for 'target' in the list 'data'.
    /// Returns the number of operations performed.
    /// Big O = O(n)
    /// </summary>
    private static int SearchSorted1(int[] data, int target)
    {
        var count = 0;

        // Linear search:
        // Checks each element one by one.
        // Worst case = checks every item in the array.
        // Performance = O(n)

        foreach (var item in data)
        {
            count += 1;

            if (item == target)
                return count; // Found it
        }

        return count; // Didn't find it
    }

    /// <summary>
    /// Search for 'target' using binary search.
    /// Returns the number of operations performed.
    /// Big O = O(log n)
    /// </summary>
    private static int SearchSorted2(
        int[] data,
        int target,
        int start,
        int end)
    {
        // Binary search:
        // Each recursive call cuts the search space in half.
        // Performance = O(log n)

        if (end < start)
            return 1;

        var middle = (end + start) / 2;

        if (data[middle] == target)
            return 1;

        if (data[middle] < target)
        {
            // Search upper half
            return 1 + SearchSorted2(
                data,
                target,
                middle + 1,
                end
            );
        }

        // Search lower half
        return 1 + SearchSorted2(
            data,
            target,
            start,
            middle - 1
        );
    }
}