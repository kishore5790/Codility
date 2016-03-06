using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution2
{
    /// <summary>
    /// The basic idea is that a string can be turned into a palindrome iff
    /// 1. If it has odd length and all characters except one appear an even number of times or
    /// 2. If it is even and each character appears an even number of times.
    /// The algorithm used here is:
    /// 1. Create an array of length 26 to store frequencies.
    /// 2. Iterate through the array to check the conditions mentioned above.
    /// </summary>
    /// <param name="S">The input string with atleast one character.</param>
    /// <returns>1 if S can be turned into a palindrome, 0 otherwise.</returns>
    public int solution(string S)
    {
        int asciiOffset = (int)'a'; // ascii value of a; 97
        int[] frequencies = new int[26];
        
        // Build up the frequency array. O(N) time, O(1) space.
        foreach (char ch in S)
        {
            int currentIndex = (int)ch - asciiOffset;
            frequencies[currentIndex] += 1;
        }

        int numUnpaired = 0;
        // To count the number of unpaired characters. O(1) time.
        foreach (int i in frequencies)
        {
            if (i % 2 == 1) numUnpaired += 1;
        }

        // Check conditions #1 and #2 for odd and even length and return the result.
        if (S.Length % 2 == 1 && numUnpaired == 1) return 1;
        else if (S.Length % 2 == 0 && numUnpaired == 0) return 1;
        else return 0;
    }
}