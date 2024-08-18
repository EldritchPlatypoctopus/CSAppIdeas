using System;

namespace Calculator_App.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private int _shownValue = 0;
    public int ShownValue { get; }

    public void Exit()
    {
        Environment.Exit(0);
    }
}