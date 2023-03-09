namespace LuckyFish.Lib.Data;

public class QueueList<T>
{
    private LinearList<T> Data { get; set; } = new ();
    public void Remove() => Data.Remove(0);
    public void Add(T data) => Data.Add(data);
    public void Insert(int index, T data) => Data.Insert(index, data);
    public T this[int index] => Data[index];
    public void RemoveAt(int index) => Data.Remove(index);
}