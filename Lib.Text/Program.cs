﻿// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;
using LuckyFish.Lib.Data;
using LuckyFish.Lib.MoreMath.Operation;
using Math = LuckyFish.Lib.MoreMath.Math;

//Console.WriteLine(Math.Round(20.12346,4));
Console.WriteLine(Math.EvaluatePostfix(Math.InfixToPostfix("((10+1)*2)*8")));
//Console.WriteLine(new NumberOperation(new Number(1),new Number(2),OperationSymbol.Plus).Run());