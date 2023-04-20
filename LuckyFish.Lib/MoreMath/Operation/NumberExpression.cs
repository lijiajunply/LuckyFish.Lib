namespace LuckyFish.Lib.MoreMath.Operation;

public interface NumberExpression
{
    public void Parser(string context);
    public decimal Run(Dictionary<string,decimal>? values = null);
}