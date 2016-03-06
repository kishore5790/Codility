using System;
using System.Text;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    /// <summary>
    /// O(N^2) time solution.
    /// Checks all possible integer periods in [0, Length/2].
    /// </summary>
    /// <param name="N">The given integer</param>
    /// <returns>The smallest binary period P if it exists, -1 otherwise.</returns>
    public int solution(int N)
    {
        string binary = getBinary(N);
        
        // Analyze each period.
        for(int p=1; p <= binary.Length/2; p++)
        {
            int k = 0;
            // Test whether binary[k] = binary[k+p] for k in [0,length-p)
            while(k < binary.Length - p)
            {
                if (binary[k] != binary[k + p]) break;
                k += 1;
            }
            if (k == binary.Length - p) return p;
        }
        return -1;
    }

    /// <summary>
    /// Returns the binary representation of the given integer.
    /// The binary representation is reversed, but that would not affect the period.
    /// </summary>
    /// <param name="N">The given integer</param>
    /// <returns>A reversed binary representation</returns>
    public string getBinary(int N)
    {
        StringBuilder result = new StringBuilder();
        while (N > 0)
        {
            result.Append(N % 2 == 1 ? '1' : '0'); // Append the lsb
            N = N >> 1; // right shift
        }
        return result.ToString();
    }
}