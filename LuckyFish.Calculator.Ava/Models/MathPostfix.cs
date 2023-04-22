using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LuckyFish.Calculator.Ava.Models;

public static class MathPostfix
{
    public static decimal Postfix(string expression) => EvaluatePostfix(InfixToPostfix(expression));
    
    private static string InfixToPostfix(string expression)
    {
        var stack = new Stack<string>();
        var postfix = new StringBuilder();
        var pattern = @"([0-9]+)|([0-9]+\.[0-9]+)|[+]|[-]|[*]|[/]|[^]|[%]|[(]|[)]";
        List<string> text = new List<string>();
        foreach (Match match in Regex.Matches(expression, pattern))
            text.Add(match.Value);
        foreach (var s in text)
        {
            if (decimal.TryParse(s, out _))
            {
                postfix.Append(s + " ");
                continue;
            }
            if (s == "(")
            {
                stack.Push(s);
                continue;
            }
            if (s == ")")
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
            postfix.Append(stack.Pop()+" ");
        return postfix.ToString();
    }
    
    private static int Precedence(string s)
        => s switch
        {
            "+" => 1,
            "-" => 1,
            "*" => 2,
            "/" => 2,
            "%" => 2,
            "^" => 3,
            _ => -1
        };

    private static decimal EvaluatePostfix(string expression)
    {
        var stack = new Stack<decimal>();
        string[] expr = expression.Split(" ");
        foreach (var s in expr)
        {
            if (s == "") continue;
            if (decimal.TryParse(s, out var value))
                stack.Push(value);
            else
            {
                var right = stack.Pop();
                var left = stack.Pop();
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
                    case "%":
                        stack.Push(left % right);
                        break;
                    case "^":
                        stack.Push(Convert.ToDecimal(Math.Pow(Convert.ToDouble(left),Convert.ToDouble(right))));
                        break;
                }
            }
        }
        return stack.Pop();
    }
}