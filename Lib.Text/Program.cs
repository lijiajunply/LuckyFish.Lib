using LuckyFish.Lib;
using Math = LuckyFish.Lib.MoreMath.Math;

/*int left = 3;
int top = 2;
Console.SetCursorPosition(left,top);
Console.ReadKey();*/
while (true)
{
    var key = Console.ReadKey().Key;
    if (key == ConsoleKey.Escape) return;
    Console.WriteLine(key);
}