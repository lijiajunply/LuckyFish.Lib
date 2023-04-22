using System.Collections.ObjectModel;

namespace LuckyFish.Calculator.Ava.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<string> _histories = new ObservableCollection<string>();

    public ObservableCollection<string> Histories
    {
        get => _histories;
        set => SetField(ref _histories, value);
    }
    private string _history = "";
    public string History
    {
        get => _history;
        set => SetField(ref _history, value);
    }
    private string _mathExpression = "123+1*100%3";
    public string MathExpression
    {
        get => _mathExpression;
        set => SetField(ref _mathExpression, value);
    }
}