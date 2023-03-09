namespace LuckyFish.Lib.Data;

public class StackList<T>
{
    private LinearList<T> Data { get; set; } = new LinearList<T>();
    public void Add(T data) => Data.Add(data);
    public void RemoveLast() => Data.Remove(Data.Length - 1);
    public T[] GetArray() => Data.ToArray();
    public LinearList<T> GetList() => Data;
    public void Add(LinearList<T> data)
    {
        foreach (var t in data.GetList())
            Data.Add(t);
    }
    public T this[int index] => Data[index];
    public T Last() => Data[^1];

    public static int ReversePolishNotation(string Polist)
    {
        var stack = new StackList<int>();
        foreach (var c in Polist)
        {
            switch (c)
            {
                case '+':
                {
                    int result = stack.Data[^1] + stack.Data[^2];
                    stack.RemoveLast();
                    stack.RemoveLast();
                    stack.Add(result);
                    continue;
                }
                case '-':
                {
                    int result = stack.Data[^1] + stack.Data[^2];
                    stack.RemoveLast();
                    stack.RemoveLast();
                    stack.Add(result);
                    continue;
                }
                case '*':
                {
                    int result = stack.Data[^1] + stack.Data[^2];
                    stack.RemoveLast();
                    stack.RemoveLast();
                    stack.Add(result);
                    continue;
                }
                case '/':
                {
                    int result = stack.Data[^1] + stack.Data[^2];
                    stack.RemoveLast();
                    stack.RemoveLast();
                    stack.Add(result);
                    continue;
                }
                default:
                    stack.Add(int.Parse(c.ToString()));
                    break;
            }
        }
        return stack.Last();
    }
}