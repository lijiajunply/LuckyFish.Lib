namespace LuckyFish.Lib.Data;

public class LinearList<T>
{
    public int Length { get; set; }
    private int InitSize { get; set; } = 20;
    private T[] Data { get; set; }

    public LinearList()
    {
        Data = new T[InitSize];
        Length = 0;
    }

    public void Add(T data)
    {
        Length++;
        if (Length >= Data.Length)
            AddSize();
        Data[Length - 1] = data;
    }

    private void AddSize()
    {
        InitSize += InitSize;
        var newData = new T[InitSize];
        for (int i = 0; i < Length; i++)
            newData[i] = Data[i];
        Data = newData;
    }

    public void Insert(int index, T item)
    {
        if (index >= Length)
            throw new Exception($"LinearList.Insert Error: the index {index} is more than length {Length}");
        if (index < 0)
            throw new Exception($"LinearList.Insert Error: the index {index} is less than 0");
        Length++;
        var a = new T[InitSize >= Length ? InitSize : Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (i < index)
                a[i] = Data[i];
            else if (i == index)
                a[index] = item;
            else if (i > index)
                a[i] = Data[i - 1];
        }

        Data = a;
    }

    public void Remove(int index)
    {
        Length--;
        var a = new T[InitSize >= Length ? InitSize : Length];
        for (int i = 0; i < a.Length; i++)
        {
            if (i < index)
                a[i] = Data[i];
            else if (i > index)
                a[i - 1] = Data[i];
        }

        Data = a;
    }

    public T[] ToArray()
    {
        var a = new T[Length];
        for (int i = 0; i < Length; i++)
            a[i] = Data[i];
        return a;
    }

    public void Clear()
    {
        Length = 0;
        Data = new T[InitSize];
    }

    public List<T> GetList() => Data.TakeWhile(t => t != null).ToList();

    public T this[int index] => Data[index];
}