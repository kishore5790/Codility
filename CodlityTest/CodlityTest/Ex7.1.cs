using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution71
{
    public int solution(string S)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)

        Stack<char> stack = new Stack<char>();
        foreach(char c in S)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == ']' || c == '}')
            {
                if (stack.Count == 0) return 0;
                char popped = stack.Pop();
                if (!isMatch(popped, c)) return 0;
            }
            else throw new Exception("Unexpected input.");
        }
        if (stack.Count > 0) return 0;
        return 1;
    }

    public bool isMatch(char a, char b)
    {
        if (a == '(' && b == ')') return true;
        else if (a == '[' && b == ']') return true;
        else if (a == '{' && b == '}') return true;
        return false;
    }
}