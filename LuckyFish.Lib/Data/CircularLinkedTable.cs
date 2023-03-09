namespace LuckyFish.Lib.Data;

public class CircularLinkedTable<T>
{
    private T Data { get; set; }
    private CircularLinkedTable<T> Next { get; set; }

    public CircularLinkedTable(T data)
    {
        Next = this;
        Data = data;
    }

    public void Add(T data)
    {
        var a = new CircularLinkedTable<T>(data);
        var next = Next;
        Next = a;
        a.Next = next;
    }

    public void RemoveNext() => Next = Next.Next;
    public CircularLinkedTable<T> GetNext() => Next;
    public override string ToString() => Data.ToString();
}