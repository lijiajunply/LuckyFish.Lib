namespace LuckyFish.Lib.Data;

public class StringData
{
    private char[] Data { get; set; }
    public StringData(char[] data) => Data = data;
    public char this[int index] => Data[index];

    public StringData[] Spilt(char[] chars)
    {
        StringData charsData = new StringData(chars);
        LinearList<StringData> data = new LinearList<StringData>();
        for (int i = 0; i < Data.Length; i++)
            if (Data[i] == charsData[i])
                if (Slice(i,chars.Length).Equals(charsData))
                    data.Add(Slice(0,i));
        return data.ToArray();
    }

    public StringData Slice(int start, int over)
    {
        LinearList<char> chars = new LinearList<char>();
        for (int i = start; i < over; i++)
            chars.Add(Data[i]);
        return new StringData(chars.ToArray());
    }

    public void Replace(StringData old, StringData newData)
    {
        var item = Spilt(old.Data);
        LinearList<char> result = new LinearList<char>();
        for (int i = 0; i < item.Length; i++)
        {
            foreach (var c in item[i].Data)
                result.Add(c);
            if (i != item.Length - 1)
                foreach (var c in newData.Data)
                    result.Add(c);
        }
        Data = result.ToArray();
    }

    public override bool Equals(object? obj)
    {
        StringData a = obj as StringData;
        return !Data.Where((t, i) => a[i] != t).Any();
    }

    public static bool operator ==(StringData left, StringData right) => left.Equals(right);
    public static bool operator !=(StringData left, StringData right) => !(left == right);

    public static StringData operator +(StringData left, StringData right)
    {
        LinearList<char> a = new LinearList<char>();
        foreach (var c in left.Data)
            a.Add(c);
        foreach (var c in right.Data)
            a.Add(c);
        return new StringData(a.ToArray());
    }

    public static StringData operator *(StringData left, int num)
    {
        LinearList<char> a = new LinearList<char>();
        for (int i = 0; i < num; i++)
            foreach (var c in left.Data)
                a.Add(c);
        return new StringData(a.ToArray());
    }
    
    public static StringData operator *(int num,StringData right)
    {
        LinearList<char> a = new LinearList<char>();
        for (int i = 0; i < num; i++)
            foreach (var c in right.Data)
                a.Add(c);
        return new StringData(a.ToArray());
    }
    public override string ToString() => Data.Aggregate("", (current, c) => current + c);
}