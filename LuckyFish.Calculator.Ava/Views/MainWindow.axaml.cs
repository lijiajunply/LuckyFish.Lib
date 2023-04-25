using Avalonia.Controls;
using Avalonia.Interactivity;
using LuckyFish.Calculator.Ava.ViewModels;
using LuckyFish.Lib.MoreMath;

namespace LuckyFish.Calculator.Ava.Views;

public partial class MainWindow : Window
{
    private string[,] Pos => new string[6,4]
    {
        {"%","CE","C","Delete"},
        {"^(-1)","^2","^0.5","/"},
        {"7","8","9","*"},
        {"4","5","6","-"},
        {"1","2","3","+"},
        {"+/-","0",".","="}
    };
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MathClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainWindowViewModel data) return;
        int row = Grid.GetRow(sender as Control);
        int column = Grid.GetColumn(sender as Control);
        string a = Pos[row,column];
        switch (a)
        {
            case "=":
                data.History = data.MathExpression;
                data.MathExpression = Math.Postfix(data.MathExpression).ToString();
                return;
            case "C":
                data.MathExpression = "0";
                return;
            case "+/-":
                data.History = $"-({data.MathExpression})";
                data.MathExpression = Math.Postfix($"0-({data.MathExpression})").ToString();
                return;
            case "CE":
                return;
            case "Delete":
                data.MathExpression = DeleteString(data.MathExpression);
                return;
            default:
                if (data.MathExpression == "0")
                    data.MathExpression = a;
                else 
                    data.MathExpression += a;
                return;
        }
    }

    private string DeleteString(string s)
        => s.Length <= 1 ? "0" : s[..^1];

    private void HistoryTapped(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainWindowViewModel data) return;
        data.MathExpression = data.History;
    }
}

