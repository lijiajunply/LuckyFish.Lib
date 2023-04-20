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
    
    public NumberOperation(){}

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
        if (context == null)return;
        List<string> text = new List<string>();
        foreach (Match match in Regex.Matches(context, Pattern))
            text.Add(match.Value);
    }

    public decimal Run(Dictionary<string, decimal>? values = null)
    {
        if (Symbol.Operation == null) throw new Exception("Symbol is null");
        return Symbol.Operation(Left, Right, values);
    }
}