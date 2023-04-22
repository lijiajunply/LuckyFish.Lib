using System.Text;
using System.Text.RegularExpressions;

namespace LuckyFish.Lib.Operation;

public class NumberOperation : NumberExpression
{
    private static string Pattern =>
        @"(.)|([1-9]\d*\.?\d*)|(0\.\d*[1-9])|[+]|[-]|[*]|[/]|[(]|[)]";

    public NumberOperation(string? context)
    {
        Parser(context);
    }

    public NumberOperation()
    {
        
    }

    public NumberOperation(NumberExpression left, NumberExpression right,
        StringSymbol symbol)
    {
        Left = left;
        Right = right;
        Symbol = symbol;
    }

    private NumberExpression Left { get; set; }
    private NumberExpression Right { get; set; }
    private StringSymbol Symbol { get; set; }

    public void Parser(string? context)
    {
        
        if (context == null) return;
        if (Regex.IsMatch(context,@"([1-9]\d*\.?\d*)|(0\.\d*[1-9])"))return;
        List<string> texts = new List<string>();
        foreach (Match match in Regex.Matches(context, Pattern))
            texts.Add(match.Value);
        string left = "";
        string right = "";
        string opera = "";
        StringBuilder postfix = new StringBuilder();
        Stack<string> stack = new Stack<string>();
        /*foreach (var s in texts)
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
                    return;
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
        string[] lexerResult = postfix.ToString().Split(" ");*/
    }

    private static NumberExpression Get(string s)
        => s switch
        {
            "+" => new StringSymbol(s, 1, BasicOperation.Plus),
            "-" => new StringSymbol(s, 1, BasicOperation.Minus),
            "*" => new StringSymbol(s, 2, BasicOperation.Times),
            "/" => new StringSymbol(s, 2, BasicOperation.Divide),
            "^" => new StringSymbol(s, 3, BasicOperation.Power),
            "(" or ")" => new StringSymbol(s, 4, BasicOperation.Minus),
            _ => new Variable(s)
        };
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
    private static bool IsSymbol(string s) => s is "+" or "-" or "*" or "/" or "^";
    public decimal Run(Dictionary<string, decimal>? values = null)
    {
        if (Symbol.Operation == null) throw new Exception("Symbol is null");
        return Symbol.Operation(Left, Right, values);
    }
}