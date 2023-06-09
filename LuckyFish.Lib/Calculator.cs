﻿using LuckyFish.Lib.Operation;

namespace LuckyFish.Lib;

public class Calculator
{
    #region Pror
    private NumberExpression Expression{ get; set; } 
    public string Context { get; set; }
    #endregion
    public Calculator(string context)
    {
        Context = context;
        Expression = new NumberOperation(context);
    }
    public decimal Result(Dictionary<string, decimal>? values = null) => Expression.Run(values);
}