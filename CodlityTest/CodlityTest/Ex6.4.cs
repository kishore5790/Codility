using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution64
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int[] leftExtremes = new int[A.Length];
        int[] rightExtremes = new int[A.Length];
        int[] leftExtremesSorted = new int[A.Length];
        int[] rightExtremesSorted = new int[A.Length];

        for (int i=0; i<A.Length; i++)
        {
            leftExtremes[i] = i - A[i];
            rightExtremes[i] = i + A[i];
            leftExtremesSorted[i] = leftExtremes[i];
            rightExtremesSorted[i] = rightExtremes[i];
        }

        Array.Sort(leftExtremesSorted);
        Array.Sort(rightExtremesSorted);

        int numIntersections = 0;
        for (int i = 0; i < A.Length;i++)
        {
            int currLeftExtreme = leftExtremes[i];
            int currRightExtreme = rightExtremes[i];

            int b = binarySearch(leftExtremesSorted, currRightExtreme + 1);
            int a = binarySearch(rightExtremesSorted, currLeftExtreme);

            numIntersections += (b - a);
        }
        numIntersections -= A.Length;
        numIntersections /= 2;
        if (numIntersections > (int)1e7) return -1;
        else return numIntersections;
    }

    /// <summary>
    /// Repeatedly searches within (left,right] using bin search.
    /// Returns the lowest index possible.
    /// </summary>
    /// <param name="A"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public int binarySearch(int[] A, int value)
    {
        int left = 0;
        int right = A.Length;
        int currentLength = right - left;

        while (currentLength > 16)
        {
            int midPoint = left + currentLength / 2;

            if (A[midPoint] < value) left = midPoint;
            else if (A[midPoint] >= value) right = midPoint + 1;

            currentLength = right - left;
        }

        for(int i = left; i < right; i++)
        {
            if (A[i] >= value) return i;
        }
        return A.Length;
    }
}
