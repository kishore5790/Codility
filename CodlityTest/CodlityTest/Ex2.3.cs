using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution23
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        Dictionary<int, int> B = new Dictionary<int, int>();
        foreach (int i in A)
        {
            if (!B.ContainsKey(i)) B.Add(i, 1);
            else B[i] += 1;
        }

		foreach (KeyValuePair<int, int> entry in B)
        {
            if (entry.Value % 2 == 1) return entry.Key;
        }

        throw new Exception("Unmatched entry not found");
    }
}