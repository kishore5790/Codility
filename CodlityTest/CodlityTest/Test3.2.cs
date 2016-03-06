using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Heavy2
{
    /// <summary>
    /// Returns the number of heavy integers from A to B (inclusive).
    /// </summary>
    public int solution(int A, int B)
    {
        List<int> smallDigitList = getDigits(A);
        List<int> bigDigitList = getDigits(B + 1);
        int maxExponent = bigDigitList.Count - 1;

        int[][] cache = getCache(maxExponent);
        int numHeavies = getNumHeavies(bigDigitList, cache);
        
        numHeavies -= getNumHeavies(smallDigitList, cache);
        return numHeavies;
    }

    /// <summary>
    /// Builds up an array of frequency arrays such that
    /// result[i] = The frequency array for numbers from 0:(10^i)-1, and
    /// result.Length = maxExponent + 1.
    /// Converts all subarrays into suffix sums.
    /// </summary>
    /// <param name="maxExponent">The maximim exponent.</param>
    /// <returns>The frequency cache.</returns>
    public int[][] getCache(int maxExponent)
    {
        int[][] result = new int[maxExponent + 1][];
        int[] zeroth = { 1 };
        result[0] = zeroth;
        if (maxExponent == 0) return result;
        
        // Builds up the cache.
        for (int i = 1; i <= maxExponent; i++)
        {
            int[] oldFreqArray = result[i - 1];
            result[i] = getNextFreqArray(oldFreqArray);
        }

        // Converts cache into suffix sums.
        for (int i = 0; i <= maxExponent; i++)
        {
            int[] current = result[i];
            int[] suffixSums = new int[current.Length];
            int runningSum = 0;
            for (int j = current.Length - 1; j >= 0; j--)
            {
                runningSum += current[j];
                suffixSums[j] = runningSum;
            }
            result[i] = suffixSums;
        }
        return result;
    }

    /// <summary>
    /// Given a frequency array for 0:(10^n)-1,
    /// returns a frequency array for 0:(10^n+1)-1
    /// </summary>
    /// <param name="smallFreqArray">The smaller frequency array</param>
    /// <returns>The bigger frequency array.</returns>
    public int[] getNextFreqArray(int[] smallFreqArray)
    {
        int oldLength = smallFreqArray.Length;
        int newLength = oldLength + 9;
        int[] bigFreqArray = new int[newLength];

        // Computes prefix sums in the usual way,
        // and pads the extra length with repetitions of the total sum.
        int[] prefixSums = new int[newLength];
        int runningSum = 0;
        for (int i = 0; i < oldLength; i++)
        {
            runningSum += smallFreqArray[i];
            prefixSums[i] = runningSum;
        }
        for (int i = oldLength; i < newLength; i++)
        {
            prefixSums[i] = runningSum;
        }

        Array.Copy(prefixSums, bigFreqArray, 10);

        for (int i = 10; i < newLength; i++)
        {
            bigFreqArray[i] = prefixSums[i] - prefixSums[i - 10];
        }
        return bigFreqArray;
    }

    /// <summary>
    /// Counts the number of heavy integers in 0 to 
    /// the number represented by the given list (exclusive),
    /// using the given cache.
    /// </summary>
    /// <param name="digits">The digits of the given number.</param>
    /// <param name="cache">The frequency cache.</param>
    /// <returns>The number of heavy integers.</returns>
    public int getNumHeavies(List<int> digits, int[][] cache)
    {
        int numHeavies = 0;
        if (digits.Count == 0) return numHeavies;
        // Count the number of heavy integers from 0 to 10^maxExponent
        for (int i = 1; i < digits.Count; i++)
        {
            int desiredSum = 7 * i + 1;
            int[] currFreqArray = cache[i];
            int[] prevFreqArray = cache[i - 1];
            numHeavies += currFreqArray[desiredSum];
            if (desiredSum < prevFreqArray.Length) numHeavies -= prevFreqArray[desiredSum];
        }

        int prefixSum = 0;
        int heavyThreshold = digits.Count * 7 + 1;
        // Handling an edge case
        int[] maxExponentArray = cache[digits.Count - 1];
        if (heavyThreshold < maxExponentArray.Length) numHeavies -= maxExponentArray[heavyThreshold];

        // For each digit from the left
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            int currentDigit = digits[i];
            int[] freqArray = cache[i];
            for (int j = 0; j < currentDigit; j++)
            {
                int currentSum = prefixSum + j;
                int desiredSum = heavyThreshold - currentSum;
                if (desiredSum < 0) desiredSum = 0;
                if (desiredSum < freqArray.Length) numHeavies += freqArray[desiredSum];
            }
            prefixSum += currentDigit;
        }
        return numHeavies;
    }

    /// <summary>
    /// Returns the digits of the given number.
    /// </summary>
    /// <param name="N">The given number.</param>
    /// <returns>A list of digits, in reversed order.</returns>
    public List<int> getDigits(int N)
    {
        List<int> result = new List<int>();
        while (N > 0)
        {
            result.Add(N % 10);
            N /= 10;
        }
        return result;
    }
}
