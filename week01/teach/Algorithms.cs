using System.Diagnostics;

public static class Algorithms
{
    public static void Run()
    {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}", "n", "alg1-count", "alg2-count", "alg3-count",
            "alg1-time", "alg2-time", "alg3-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n < 15001; n += 1000)
        {
            int count1 = Algorithm1(n);
            int count2 = Algorithm2(n);
            int count3 = Algorithm3(n);
            double time1 = Time(Algorithm1, n, 10);
            double time2 = Time(Algorithm2, n, 10);
            double time3 = Time(Algorithm3, n, 10);
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15:0.00000}{5,15:0.00000}{6,15:0.00000}", n, count1, count2,
                count3, time1, time2,
                time3);
        }
    }

    private static double Time(Func<int, int> algorithm, int input, int times)
    {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i)
        {
            algorithm(input);
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm1(int size)
    {
        var count = 0;
        for (var i = 0; i < size; ++i)
            count += 1;

        return count;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm2(int size)
    {
        var count = 0;
        for (var i = 0; i < size; ++i)
            for (var j = 0; j < size; ++j)
                count += 1;

        return count;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm3(int size)
    {
        var count = 0;
        var start = 0;
        var end = size - 1;
        while (start <= end)
        {
            var middle = (end - start) / 2 + start;
            start = middle + 1;
            count += 1;
        }

        return count;
    }
}
// Questions and Answers

// 1. Did the actual results match the predicted Big O complexity?
// Yes, the results matched the predicted complexities.
// Algorithm1 increased linearly, Algorithm2 increased quadratically,
// and Algorithm3 increased logarithmically as the input size grew.

// 2. Which algorithm had the best and worst performance?
// Algorithm3 had the best performance because O(log n)
// grows very slowly even for large values of n.
//
// Algorithm2 had the worst performance because O(n^2)
// grows much faster than the other algorithms.

// 3. Why do we say that Big O notation only matters when n is large?
// Big O is most important when the input size becomes large.
// With small values of n, the execution times may look similar
// and can be affected by the computer or operating system.
// As n increases, the growth rate of the algorithm becomes clear.