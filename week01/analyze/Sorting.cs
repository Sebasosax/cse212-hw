using System;

public static class Sorting
{
    public static void Run()
    {
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };

        SortArray(numbers);

        Console.WriteLine(
            "int[]{{{0}}}",
            string.Join(", ", numbers)
        );

        // Output:
        // int[]{1, 2, 3, 4, 6, 8, 9}
    }

    /// <summary>
    /// Sorts an array using Bubble Sort.
    /// Big O = O(n^2)
    /// </summary>
    private static void SortArray(int[] data)
    {
        // Outer loop runs n times
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--)
        {
            // Inner loop also runs up to n times
            for (var swapPos = 0; swapPos < sortPos; ++swapPos)
            {
                // Compare adjacent values
                if (data[swapPos] > data[swapPos + 1])
                {
                    // Swap values
                    (data[swapPos + 1], data[swapPos]) =
                        (data[swapPos], data[swapPos + 1]);
                }
            }
        }

        // Because there are two nested loops:
        // Total performance = O(n^2)
    }
}