using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution31
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        // We first consider the splitpoint = 1 case, and iterate through and return min(p)
        int leftSum = A[0];
        int rightSum = A[1];


        for(int i=2; i<A.Length; i++)
        {
            rightSum += A[i];
        }
        int diff = leftSum - rightSum;
        int best = diff;

        for(int i=2; i<A.Length; i++)
        {
            leftSum += A[i-1];
            rightSum -= A[i - 1];
            diff = Math.Abs(leftSum - rightSum);
            best = diff < best ? diff : best;
        }
        return best;
    }
}