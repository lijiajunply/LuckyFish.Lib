// See https://aka.ms/new-console-template for more information

using LuckyFish.Lib.Data;


// fib use StackList
var a = new StackList<int>();
a.Add(1);
a.Add(1);
Console.WriteLine(a.Last());
for (int b = 0; b < 21; b++)
{
    Console.WriteLine(a.Last());
    a.Add(a[b]+a[b+1]);
}