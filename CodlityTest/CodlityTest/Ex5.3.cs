using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution53
{
    public int[] solution(string S, int[] P, int[] Q)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        // A - 1,
        // C - 2,
        // G - 3,
        // T - 4

        int[] AsUptoIndex = new int[S.Length];
        int[] CsUptoIndex = new int[S.Length];
        int[] GsUptoIndex = new int[S.Length];
        int[] TsUptoIndex = new int[S.Length];

        if (S[0] == 'A') AsUptoIndex[0] = 1;
        else if (S[0] == 'C') CsUptoIndex[0] = 1;
        else if (S[0] == 'G') GsUptoIndex[0] = 1;
        else if (S[0] == 'T') TsUptoIndex[0] = 1;
        else throw new Exception("Char not matched.");

        for (int i=1; i<S.Length; i++)
        {
            char current = S[i];
            if (current == 'A') AsUptoIndex[i] = AsUptoIndex[i-1] + 1;
            else if (current == 'C') CsUptoIndex[i] = CsUptoIndex[i - 1] + 1;
            else if (current == 'G') GsUptoIndex[i] = GsUptoIndex[i - 1] + 1;
            else if (current == 'T') TsUptoIndex[i] = TsUptoIndex[i - 1] + 1;
            else throw new Exception("Char not matched.");

            if (AsUptoIndex[i] == 0) AsUptoIndex[i] = AsUptoIndex[i - 1];
            if (CsUptoIndex[i] == 0) CsUptoIndex[i] = CsUptoIndex[i - 1];
            if (GsUptoIndex[i] == 0) GsUptoIndex[i] = GsUptoIndex[i - 1];
            if (TsUptoIndex[i] == 0) TsUptoIndex[i] = TsUptoIndex[i - 1];

        }

        int[] result = new int[P.Length];
        for (int i=0; i<P.Length; i++)
        {
            int left = P[i] - 1;
            int right = Q[i];
            if (left >= 0)
            {
                if (AsUptoIndex[right] > AsUptoIndex[left]) result[i] = 1;
                else if (CsUptoIndex[right] > CsUptoIndex[left]) result[i] = 2;
                else if (GsUptoIndex[right] > GsUptoIndex[left]) result[i] = 3;
                else if (TsUptoIndex[right] > TsUptoIndex[left]) result[i] = 4;
                else throw new Exception("No chars when there should be atleast one");
            }
            else
            {
                if (AsUptoIndex[right] > 0) result[i] = 1;
                else if (CsUptoIndex[right] > 0) result[i] = 2;
                else if (GsUptoIndex[right] > 0) result[i] = 3;
                else if (TsUptoIndex[right] > 0) result[i] = 4;
                else throw new Exception("No chars when there should be atleast one");
            }
        }

        return result;
    }
}