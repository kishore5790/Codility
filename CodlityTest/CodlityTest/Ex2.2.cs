using System;
using System.Collections.Generic;

class Solution22
{
    // range of integers: 1-1e9
    // size range: 1-1e6
    // algo: build a list of lists such that array.length = 1e3 bins. 
    //    Each bin can contain 1e6 (consequtive) possible integers.
    // add array elems to bins, choose bin with odd number of values. O(n)
    // subtract binoffset from all elems in bin. O(n).
    // create & iterate through an array of length 1e6, foreach elem arr[elem] += 1.
    // find elem such that arr[elem] is odd, return elem + binoffset.

    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)\
        List<List<int>> twoDimList = get2DList(A);
        int binOffset = -1;
        List<int> unpaired = null;

        for (int i = 0; i < twoDimList.Count; i++)
        {
            List<int> current = twoDimList[i];
            if (current.Count % 2 == 1)
            {
                unpaired = current;
                binOffset = 1000000 * i;
            }
        }
        // should never happen
        if (binOffset == -1) throw new Exception("could not find the oddsized list");

        return getUnpaired(unpaired, binOffset);
    }

    public List<List<int>> get2DList(int[] A)
    {
        List<List<int>> twoDimList = new List<List<int>>();

        // Create 1000 bins.
        for (int i = 0; i < 1000; i++)
        {
            twoDimList.Add(new List<int>());
        }

        // Add elems to the bins.
        for (int i = 0; i < A.Length; i++)
        {
            int current = A[i] - 1;
            int binIndex = current / 1000000;
            twoDimList[binIndex].Add(current);
        }

        return twoDimList;
    }

    /// <summary>
    /// Method to return the unpaired number from a list of integers whose values have a range of 1e6.
    /// </summary>
    /// <param name="oddSizeList">The list mentioned above.</param>
    /// <param name="binOffset">The bin offset of the list such that the range of integers is [binoffset:binoffset+1000]</param>
    /// <returns>The unpaired integer, ie the answer we need.</returns>
    public int getUnpaired(List<int> oddSizeList, int binOffset)
    {

        int[] indexedValueArray = new int[1000000];
        foreach (int elem in oddSizeList)
        {
            indexedValueArray[elem - binOffset] += 1;

        }
        for (int i = 0; i < indexedValueArray.Length; i++)
        {
            if (indexedValueArray[i] % 2 == 1) return binOffset + i + 1;
        }

        // should never happen.
        return -1;
    }
}
