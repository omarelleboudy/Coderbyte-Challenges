using System;
using System.Collections.Generic;

class MainClass
{
    /*
    Array Challenge
    Have the function ArrayChallenge(strArr) read the array of strings stored in strArr, 
    which will contain 2 elements: the first element will be a sequence of characters, 
    and the second element will be a long string of comma-separated words,
    in alphabetical order, that represents a dictionary of some arbitrary length.
    For example: strArr can be: ["hellocat", "apple,bat,cat,goodbye,hello,yellow,why"].
    Your goal is to determine if the first element in the input can be split into two words,
    where both words exist in the dictionary that is provided in the second input.
    In this example, the first element can be split into two words:
    hello and cat because both of those words are in the dictionary.

    Your program should return the two words that exist in the dictionary separated by a comma.
    So for the example above, your program should return hello,cat.
    There will only be one correct way to split the first element of characters into two words.
    If there is no way to split string into two words that exist in the dictionary,
    return the string not possible. The first element itself will never exist in the dictionary as a real word.
    
    
    Examples
    Input: new string[] {"baseball", "a,all,b,ball,bas,base,cat,code,d,e,quit,z"}
    Output: base,ball
    Input: new string[] {"abcgefd", "a,ab,abc,abcg,b,c,dog,e,efd,zzzz"}
    Output: abcg,efd*/

    public static string ArrayChallenge(string[] strArr)
    {
        // code goes here  
        string word = strArr[0];
        HashSet<string> dict = new HashSet<string>(strArr[1].Split(","));     
        return Process(word, dict);

    }
    public static string Process(string word, HashSet<string> dict)
    {
        string part1, part2;
        for (int i = 0; i < word.Length; i++)
        {
            if (dict.Contains(word.Substring(0, i)))
            {
                part1 = word.Substring(0, i);
                if(dict.Contains(word.Substring(i)))
                {
                    part2 = word.Substring(i);
                    return $"{part1},{part2}";
                }
            }
        }       
        return "not possible";
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(ArrayChallenge(new string[] { "hellocat", "apple,bat,cat,goodbye,hello,yellow,why"}));
    }

}