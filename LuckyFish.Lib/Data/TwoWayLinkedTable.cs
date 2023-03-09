namespace LuckyFish.Lib.Data;

public class TwoWayLinkedTable<T>
{
    private T Data { get; set; }
    private TwoWayLinkedTable<T> Last { get; set; }
    private TwoWayLinkedTable<T> Next { get; set; }
    public TwoWayLinkedTable(T data) => Data = data;
    public TwoWayLinkedTable<T> GetLast() => Last;
    public TwoWayLinkedTable<T> GetNest() => Next;
    public void SetLast(T data)
    {
        var a = new TwoWayLinkedTable<T>(data);
        var last = Last;
        last.Next = a;
        Last = a;
        a.Last = last;
    }

    public void SetNext(T data)
    {
        var a = new TwoWayLinkedTable<T>(data);
        var next = Next;
        Next = a;
        next.Last = a;
        a.Next = next;
    }
}