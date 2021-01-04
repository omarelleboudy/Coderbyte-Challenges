using System;

class MainClass
{
    /*
     Missing Digit
    Have the function MissingDigit(str) take the str parameter,
    which will be a simple mathematical formula with three numbers,
    a single operator (+, -, *, or /)
    and an equal sign (=) and return the digit that completes the equation.
    In one of the numbers in the equation, there will be an x character,
    and your program should determine what digit is missing.
    For example, if str is "3x + 12 = 46" then your program should output 4.
    The x character can appear in any of the three numbers
    and all three numbers will be greater than or equal to 0 and less than or equal to 1000000.
*/
    // code goes here  
    public static bool operationFlip = false;
    public static bool secondPosition = false;
    public static int missingNumber = 0;
    public static string missingDigit = "";
    public static string MathChallenge(string str)
    {
        string[] equation = str.Split(" ");
        if (equation[0].Contains("x"))
        {
            operationFlip = true;
            Process(equation[1], int.Parse(equation[2]), int.Parse(equation[4]));
            GetMissingDigit(missingNumber, equation[0].ToCharArray());
        }
        else if (equation[2].Contains("x"))
        {
            secondPosition = true;
            Process(equation[1], int.Parse(equation[0]), int.Parse(equation[4]));
            GetMissingDigit(missingNumber, equation[2].ToCharArray());

        }
        else if (equation[4].Contains("x"))
        {
            Process(equation[1], int.Parse(equation[0]), int.Parse(equation[2]));
            GetMissingDigit(missingNumber, equation[4].ToCharArray());
        }
        return missingDigit;

    }
    public static void GetMissingDigit(int value, char[] valueWithMissingDigit)
    {
        char[] valueAsString = value.ToString().ToCharArray();
        if (valueWithMissingDigit.Length == 1)
        {
            missingDigit = valueAsString[0].ToString();
            
        }
        else
        {
            for (int i = 0; i < valueAsString.Length; i++)
            {
                if (valueWithMissingDigit[i] == 'x') missingDigit = valueAsString[i].ToString();
            }
        }
    }

    public static void Process(string oper, int value1, int value2)
    {
        if (operationFlip == true)
        {
            if (oper == "+") missingNumber = value2 - value1;
            else if (oper == "-") missingNumber = value2 + value1;
            else if (oper == "/") missingNumber = value2 * value1;
            else if (oper == "*") missingNumber = value2 / value1;

        }
        else if (secondPosition == true)
        {
            if (oper == "-")
            {
                var max = Math.Max(value1, value2);
                var min = Math.Min(value1, value2);
                missingNumber = max - min;
            }
            else if (oper == "+") missingNumber = value2 + value1;
            else if (oper == "*") missingNumber = value2 * value1;
            else if (oper == "/")
            {
                var max = Math.Max(value1, value2);
                var min = Math.Min(value1, value2);
                missingNumber = max * min;
            }
        }
        else
        {
            if (oper == "+") missingNumber = value1 + value2;
            else if (oper == "-") missingNumber = value1 - value2;
            else if (oper == "/") missingNumber = value1 / value2;
            else if (oper == "*") missingNumber = value1 * value2;

        }
    }

    static void Main()
    {
        // keep this function call here
        Console.WriteLine(MathChallenge(Console.ReadLine()));
    }

}