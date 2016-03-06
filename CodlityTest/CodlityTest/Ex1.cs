using System;
using System.Collections;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution1
{
    public int solution(int N)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        
        return process(N);
    }
    
    public int process(int num)
    {
        int bestlen = 0;
        int curlen = 0;
        bool oneseen = false;

        while(num > 0)
        {
            bool iszero = !getLastBit(num);
            num = num >> 1;

            if (iszero) curlen += 1;
            else if (oneseen)
            {
                bestlen = curlen > bestlen ? curlen : bestlen;
                curlen = 0;
            }
            else curlen = 0;
            oneseen = oneseen || !iszero;
        }
        return bestlen;
    }

    public bool getLastBit(int num)
    {
        int rshifted = num >> 1;
        int rollback = rshifted << 1;
        return num != rollback;
    }
}
