namespace LuckyFish.Lib.MoreMath.Operation;

public class StringSymbol
{
    public StringSymbol(string symbol,int precedence,Func<NumberExpression, NumberExpression, 
        Dictionary<string,decimal>? ,decimal>? operation = null)
    {
        Symbol = symbol;
        Precedence = precedence;
        Operation = operation;
    }
    public Func<NumberExpression, NumberExpression, 
        Dictionary<string,decimal>? ,decimal>? Operation { get; set; }
    public string? Symbol { get; set; }
    public int Precedence { get; set; }
}

public static class BasicOperation
{
    public static Func<NumberExpression, NumberExpression,
        Dictionary<string, decimal>?, decimal>? Plus => 
        (left, right, values) => 
            left.Run(values) + right.Run(values);
    
    public static Func<NumberExpression, NumberExpression,
        Dictionary<string, decimal>?, decimal>? Minus => 
        (left, right, values) => 
            left.Run(values) - right.Run(values);
    
    public static Func<NumberExpression, NumberExpression,
        Dictionary<string, decimal>?, decimal>? Times => 
        (left, right, values) => 
            left.Run(values) * right.Run(values);
    
    public static Func<NumberExpression, NumberExpression,
        Dictionary<string, decimal>?, decimal>? Divide => 
        (left, right, values) => 
            left.Run(values) / right.Run(values);
    
    public static Func<NumberExpression, NumberExpression,
        Dictionary<string, decimal>?, decimal>? Power => 
        (left, right, values) => 
            Convert.ToDecimal(System.Math.Pow(Convert.ToDouble(left.Run(values)),Convert.ToDouble(right.Run(values))));
}