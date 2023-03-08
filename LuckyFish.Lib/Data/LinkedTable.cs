namespace LuckyFish.Lib.Data;

public class LinkedTable<T>
{
    private LinkedTable<T> Next { get; set; } = new ();
    private T Data { get; set; }
    public LinkedTable(){}
    public LinkedTable(T data) => Data = data;
    public void SetNext(T item)
    {
        var a = new LinkedTable<T>(item);
        var next = Next;
        Next = a;
        a.Next = next;
    }

    public T GetData() => Data;
    public void SetData(T data) => Data = data;
    public LinkedTable<T> GetNext() => Next;
    public void DeleteTable() => Next = new LinkedTable<T>();
    public void DeleteNext() => Next = Next.Next;
}