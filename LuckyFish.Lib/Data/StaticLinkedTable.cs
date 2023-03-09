namespace LuckyFish.Lib.Data;

public class StaticLinkedTable<T> where T : class
{
    private LinearList<T> Data { get; set; } = new LinearList<T>();
    private int Head { get; set; } = 0;
    public void Add(T data) => Data.Add(data);
    public void HeadDone() => Head++;
    public T? GetValue(int index) => index >= Head ? Data[index] : null;
    public void Insert(int index, T data)
    {
        if (index >= Head) 
            Data.Insert(index,data);
    }

    public void Remove(int index)
    {
        if (index >= Head)
            Data.Remove(index);
    }
}