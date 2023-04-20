namespace LuckyFish.Lib.Date;

public class DateNow : DateBasic
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Second { get; set; }
    public DateNow()
    {
        Day = DateTime.Now.Day;
        Mouth = DateTime.Now.Month;
        Year = DateTime.Now.Year;
        Hour = DateTime.Now.Hour;
        Minute = DateTime.Now.Minute;
        Second = DateTime.Now.Second;
        UtcTime = DateTime.UtcNow.ToFileTimeUtc();
    }
}