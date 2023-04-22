using LuckyFish.Lib;
using LuckyFish.Lib.Data;
using Math = LuckyFish.Lib.MoreMath.Math;

//Console.WriteLine(Math.Round(20.12346,4));
Console.WriteLine(Math.InfixToPostfix("((10+1)*2)*8"));
var a = new Calculator("((10+1)*2)*8");
//Console.WriteLine(new NumberOperation(new Number(1),new Number(2),OperationSymbol.Plus).Run());