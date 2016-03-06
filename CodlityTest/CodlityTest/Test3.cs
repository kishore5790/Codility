using System;

class Heavy1
{
    public int solution(int A, int B)
    {
        return countHeavies(A, B);
    }
    
    /// <summary>
    /// Only used in the last phase: when we're done counting from 0-N - N % 10000, we
    /// use this method to count the remaining heavy integers.
    /// </summary>
    /// <param name="A">N - N%10000</param>
    /// <param name="B">N</param>
    /// <returns>The number of heavy integers in the range defined.</returns>
    public int countHeavies(int A, int B)
    {
        int result = 0;
        for(int i = A; i <= B;i++)
        {
            double currentAvg = averageDigits(i);
            result += (currentAvg > 7.0 ? 1 : 0);
        }
        return result;
    }

    /// <summary>
    /// Averages the digits of the given integer.
    /// Only to be used for the last leg.
    /// </summary>
    /// <param name="N">The integer whose digits we want to average</param>
    /// <returns>The average, and 0 if N==0</returns>
    public double averageDigits(int N)
    {
        if (N == 0) return 0;
        double result = 0;
        int numDigits = 0;
        while (N > 0)
        {
            result += (N % 10);
            numDigits += 1;
            N = N / 10;
        }
        return result / numDigits;
    }
}