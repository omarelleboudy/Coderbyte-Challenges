using System;
using System.Collections.Generic;
using System.Linq;

/*
Have the function SearchingChallenge(strArr) read in the strArr parameter containing key:value pairs 
where the key is a string and the value is an integer.
Your program should return a string with new key:value pairs separated by a comma
such that each key appears only once with the total values summed up.

For example: if strArr is ["B:-1", "A:1", "B:3", "A:5"] then your program should return the string A:6,B:2.

Your final output string should return the keys in alphabetical order.
Exclude keys that have a value of 0 after being summed up.

Examples
Input: new string[] {"X:-1", "Y:1", "X:-4", "B:3", "X:5"}
Output: B:3,Y:1
Input: new string[] {"Z:0", "A:-1"}
Output: A:-1
*/
class MainClass
{
    public static string SearchingChallenge(string[] strArr)
    {   
        // code goes here 
        Dictionary<string, int> pairs = new Dictionary<string, int>();
        for (int i = 0; i < strArr.Length; i++)
        {
            string[] splitter = strArr[i].Split(':');
            
                if (pairs.ContainsKey(splitter[0]))
                {
                    int newValue = pairs[splitter[0]] + int.Parse(splitter[1]);
                    pairs[splitter[0]] = newValue;
                }
                else pairs.Add(splitter[0], int.Parse(splitter[1]));            
        }
        List<string> output=new List<string>();
        foreach (var item in pairs.OrderBy(item => item.Key).Where(item=>item.Value!=0))
        {
            string x = $"{item.Key}:{item.Value}";
            output.Add(x);
        }
        string result = string.Join(",", output);
        return result;

    }

    static void Main()
    {
        // keep this function call here
        // this line works with their editor, use the inputs in the problem description as input instead.
        Console.WriteLine(SearchingChallenge(Console.ReadLine()));
    }

}