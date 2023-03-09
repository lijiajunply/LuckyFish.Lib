namespace LuckyFish.Lib.Data;

public class TreeStructure<T>
{
    public LinearList<TreeStructure<T>> Children { get; set; } = new LinearList<TreeStructure<T>>();
    public T Data { get; set; }
    public TreeStructure(T data) => Data = data;

    public void AddChildren(T data)
    {
        TreeStructure<T> child = new TreeStructure<T>(data);
        Children.Add(child);
    }
}