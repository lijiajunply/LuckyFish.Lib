namespace LuckyFish.Lib.Data;

public class DataGraph
{
    public int Max = Int32.MaxValue;
    private int[,] Data { get; set; }
    public DataGraph(int i) => Data = new int[i, i];

    public int GetData(int a, int b) => Data[a, b];
    public void SetData(int a, int b, int pos) => Data[a, b] = pos;

    public void DFS(int a, int b)
    {
        if (a == Data.Length || b == Data.Length ) return;
        if (Data[a, b] == Max) return;

        if (Data[a, b - 1] + Data[b - 1, b] <= Data[a, b])
        {
            Data[a, b] = Data[a, b - 1] + Data[b - 1, b];
            DFS(a,b+1);
        }
    }
}

     /*
     * eg:
     * 
     *      1 2 3 4
     *    |---------|
     *  1 | 0 1 2 3 |
     *  2 | 1 0 1 1 |
     *  3 | 1 1 0 1 |
     *  4 | 1 1 1 0 |
     *    |---------|
     * 
     *  Data[a,b] => ( a -> b ).pos
     */