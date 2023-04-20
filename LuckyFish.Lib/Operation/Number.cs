namespace LuckyFish.Lib.Operation;

public class Number : NumberExpression
{
    private decimal Value { get; set; }
    public Number(decimal value) => Value = value;
    public decimal Run(Dictionary<string,decimal>? values = null) => Value;
}