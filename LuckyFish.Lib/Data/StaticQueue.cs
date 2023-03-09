namespace LuckyFish.Lib.Data;

public class StaticQueue<T>
{
    private LinearList<T> Data { get; set; }
    private int Head { get; set; }
    public void Remove() => Head++;
    public void Add(T data) => Data.Add(data);
    public void Insert(int index,T data) => Data.Insert(index + Head,data);

    public void RemoveAt(int index)
    {
        if (index == Head)
            Remove();
        else
            Data.Remove(index + Head);
    }

    public T Last() => Data[^1];
}