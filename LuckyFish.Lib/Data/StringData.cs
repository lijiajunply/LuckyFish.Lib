namespace LuckyFish.Lib.Data;

public class StringData
{
    private char[] Data { get; set; }
    public StringData(char[] data) => Data = data;
    public char this[int index] => Data[index];
}