namespace LuckyFish.Lib.MoreMath.Operation;

public class Number : NumberExpression
{
    private decimal Value { get; set; }
    public Number(decimal value) => Value = value;
    public void Parser(string context)
    {
        if (decimal.TryParse(context,out var value)) 
            Value = value;
    }

    public decimal Run(Dictionary<string,decimal>? values = null) => Value;
}