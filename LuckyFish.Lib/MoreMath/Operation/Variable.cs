namespace LuckyFish.Lib.MoreMath.Operation;

public class Variable : NumberExpression
{
    private string Name { get; set; }
    public Variable(string name) => Name = name;
    public void Parser(string context)
    {
        Name = context;
    }

    public decimal Run(Dictionary<string, decimal>? values = null)
    {
        try
        {
            return values![Name];
        }
        catch (Exception)
        {
            throw new Exception("error : values is null");
        }
    }
}