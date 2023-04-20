namespace LuckyFish.Lib.Operation;

public interface NumberExpression
{
    public decimal Run(Dictionary<string,decimal>? values = null);
}