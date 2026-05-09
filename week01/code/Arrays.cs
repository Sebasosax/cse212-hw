using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array with size equal to "length"
        // 2. Use a loop from 0 to length - 1
        // 3. In each position, store number * (i + 1)
        // 4. Return the completed array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Normalize the rotation amount using modulo to handle large values
        // 2. If amount is 0 after normalization, do nothing
        // 3. Find the split point: data.Count - amount
        // 4. Split the list into two parts:
        //    - tail (last elements)
        //    - head (remaining elements)
        // 5. Clear the original list
        // 6. Add tail first
        // 7. Then add head

        amount = amount % data.Count;

        if (amount == 0)
        {
            return;
        }

        int splitIndex = data.Count - amount;

        List<int> tail = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, tail);
    }
}