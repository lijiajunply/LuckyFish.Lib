namespace LuckyFish.Lib.Data;

public static class Sorts
{
    public static void QuickSort(ref int[] data, int left, int right)
    {
        if (left > right || left < 0 || right >= data.Length) return;
        int flag = data[left];
        int i = left;
        int j = right;
        while (i != j)
        {
            while (data[j]>=flag && i<j)
                j--;
            while (data[i]<=flag && i<j)
                i++;
            if (i < j)
                (data[i], data[j]) = (data[j], data[i]);
        }
        data[left] = data[i];
        data[i] = flag;
        QuickSort(ref data,left, i - 1);
        QuickSort(ref data, i + 1, right);
    }

    public static void BubbleSort(ref int[] data)
    {
        for (int i = 0; i < data.Length; i++)
        for (int j = 0; j < data.Length-i; j++)
                if (data[j] < data[j+1])
                    (data[j], data[j + 1]) = (data[j + 1],data[j]);
    }
}