using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace LuckyFish.Lib.MoreMath;

public static class Math
{
    public static double E => System.Math.E;
    public static double Pi => System.Math.PI;
    public static double Tau => System.Math.Tau;

    public static double Pow(double x, int n)
    {
        long l = n;
        return l >= 0 ? QuickMul(x, l) : 1.0 / QuickMul(x, -l);
    }

    private static double QuickMul(double x, long N)
    {
        if (N == 0) return 1;
        double y = QuickMul(x, N / 2);
        return N % 2 == 0 ? y * y : y * y * x;
    }

    public static int Abs(int x) => x >= 0 ? x : -x;

    public static int Max(int[] x)
    {
        int max = int.MinValue;
        foreach (var i in x)
            if (max < i)
                max = i;
        return max;
    }

    public static int Min(int[] x)
    {
        int min = int.MaxValue;
        foreach (var i in x)
            if (min > i)
                min = i;
        return min;
    }

    public static double ToRad(double x) => x / 180 * Pi;

    public static double Sin(double x)
    {
        double result = 0;
        for (int i = 0; i < 6; i++)
            result += (i % 2 == 0 ? 1 : -1) * Pow(ToRad(x), 2 * i + 1) / Multiply(2 * i + 1);
        return result;
    }

    public static double Cos(double x)
    {
        double result = 0;
        for (int i = 0; i < 7; i++)
            result += (i % 2 == 0 ? 1 : -1) * Pow(ToRad(x), 2 * i) / Multiply(2 * i);
        return result;
    }

    public static double Tan(double x) => Sin(x) / Cos(x);

    public static int Multiply(int n)
    {
        if (n > 1)
            return n * Multiply(n - 1);
        return 1;
    }

    public static double Round(double x, int y)
    {
        string a = x.ToString(CultureInfo.InvariantCulture).Split(".")[0];
        string z = x.ToString(CultureInfo.InvariantCulture).Split(".")[1];
        string w = z[..(y - 1)];
        if (int.Parse(z[y].ToString()) >= 5)
            w += (int.Parse(z[y - 1].ToString()) + 1).ToString()[0];
        return double.Parse(a + "." + w);
    }

    public static string InfixToPostfix(string expression)
    {
        Stack<string> stack = new Stack<string>();
        StringBuilder postfix = new StringBuilder();
        string pattern = @"([0-9]+)|([0-9]+\\.[0-9]+)|[+]|[-]|[*]|[/]|[^]|[%]|[(]|[)]";
        List<string> text = new List<string>();
        foreach (Match match in Regex.Matches(expression, pattern))
            text.Add(match.Value);
        foreach (var s in text)
        {
            if (decimal.TryParse(s, out _))
                postfix.Append(s + " ");
            else if (s == "(")
                stack.Push(s);
            else if (s == ")")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                    postfix.Append(stack.Pop() + " ");
                if (stack.Count > 0 && stack.Peek() != "(")
                    return "Invalid Expression";
                stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && Precedence(s) <= Precedence(stack.Peek()))
                    postfix.Append(stack.Pop() + " ");
                stack.Push(s);
            }
        }
        while (stack.Count > 0)
            postfix.Append(stack.Pop());
        return postfix.ToString();
    }
    
    private static int Precedence(string s)
    {
        return s switch
        {
            "+" => 1,
            "-" => 1,
            "*" => 2,
            "/" => 2,
            "^" => 3,
            _ => -1
        };
    }

    public static decimal EvaluatePostfix(string expression)
    {
        Stack<decimal> stack = new Stack<decimal>();
        string[] expr = expression.Split(" ");
        foreach (var s in expr)
        {
            if (s == "") break;
            if (decimal.TryParse(s, out var value))
                stack.Push(value);
            else
            {
                decimal right = stack.Pop();
                decimal left = stack.Pop();
                switch (s)
                {
                    case "+":
                        stack.Push(left + right);
                        break;
                    case "-":
                        stack.Push(left - right);
                        break;
                    case "*":
                        stack.Push(left * right);
                        break;
                    case "/":
                        stack.Push(left / right);
                        break;
                    case "^":
                        stack.Push(Convert.ToDecimal(System.Math.Pow(Convert.ToDouble(left),Convert.ToDouble(right))));
                        break;
                }
            }
        }

        return stack.Pop();
    }
    
    public static double Ln(double x, int accuracy = 100)
    {
        double a = x;
        for (int i = 0; i < accuracy; i++)
            a = a - 1.0 + a / Exp(a);
        return a;
    }
    public static double Log(double a, double x) => Ln(x) / Ln(a);
    public static double Exp(double x) => System.Math.Exp(x);
}