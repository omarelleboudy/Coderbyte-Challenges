using System;

/*
 Math Challenge
Have the function MathChallenge(str) take the str parameter being passed
and determine if there is some substring K that can be repeated N > 1 times
to produce the input string exactly as it appears.
Your program should return the longest substring K, and if there is none it should return the string -1.*/

/*
For example: if str is "abcababcababcab",
then your program should return abcab because that is the longest substring
that is repeated 3 times to create the final string. Another example: if str is "abababababab",
then your program should return ababab because it is the longest substring.
If the input string contains only a single character, your program should return the string -1.*/
class MainClass
{
    public static string bestSolution = "-1";
    public static string MathChallenge(string str)
    {
        int length = str.Length;
        for (int i = 1; i < length; i++)
        {
            GetLongestSubString(str.Substring(0, i), str);
        }
        return bestSolution;
    }
    public static void GetLongestSubString(string s1, string s2)
    {
        string temp = s1;
        int counter = 0;
        while (s2.Length > s1.Length)
        {
            s1 = s1 + temp;
            counter++;
        }
        if (s1 == s2)
        {
            bestSolution = temp;
        }
    }
  
    static void Main()
    {
        // keep this function call here
        Console.WriteLine(MathChallenge(Console.ReadLine()));
    }

}