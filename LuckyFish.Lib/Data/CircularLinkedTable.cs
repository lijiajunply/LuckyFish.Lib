namespace LuckyFish.Lib.Data;

public class CircularLinkedTable<T>
{
    private T Data { get; set; }
    private CircularLinkedTable<T> Next { get; set; } = new (){ Next = null }; 

    public CircularLinkedTable(bool isNext = false)
    {
        Next.Next = this;
    }

    public CircularLinkedTable(T data)
    {
        Next.Next = this;
        Data = data;
    }

    public void Add(T data)
    {
        var a = new CircularLinkedTable<T>(data);
        var next = Next;
        Next = a;
        a.Next = next;
    }

    public void RemoveNext()
    {
        if (Next.Next != null)
            Next = Next.Next;
    }
}