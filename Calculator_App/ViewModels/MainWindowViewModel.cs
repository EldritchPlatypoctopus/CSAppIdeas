using System;
using System.Reactive;
using Calculator_App.Models;
using ReactiveUI;

namespace Calculator_App.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IntegerCalculator _integerCalculator;
    private double _displayValue = 0;
    private bool _overwrite = false;
    private Operator _operator;

    public double DisplayValue
    {
        get => _displayValue;
        set => this.RaiseAndSetIfChanged(ref _displayValue, value);
    }


    public ReactiveCommand<int, Unit> AddNumberCommand { get; }
    public ReactiveCommand<Unit, Unit> RemoveNumberCommand { get; }
    public ReactiveCommand<Unit, Unit> ClearCommand { get; }
    public ReactiveCommand<Operator, Unit> OperatorCommand { get; }
    public ReactiveCommand<Unit, Unit> CalculateCommand { get; }

    public MainWindowViewModel()
    {
        _integerCalculator = new IntegerCalculator();
        AddNumberCommand = ReactiveCommand.Create<int>(AddNumber);
        RemoveNumberCommand = ReactiveCommand.Create(RemoveNumber);
        ClearCommand = ReactiveCommand.Create(Clear);
        OperatorCommand = ReactiveCommand.Create<Operator>(Operate);
        CalculateCommand = ReactiveCommand.Create(Calculate);
        RxApp.DefaultExceptionHandler = Observer.Create<Exception>(
            ex => Console.Write("next"),
            ex => Console.Write("Unhandled rxui error"));
    }

    private void Clear()
    {
        DisplayValue = 0;
    }

    private void AddNumber(int value)
    {
        if (_overwrite)
        {
            DisplayValue = 0;
            _overwrite = false;
        }
        DisplayValue = DisplayValue * 10 + value;
    }

    private void RemoveNumber()
    {
        DisplayValue = (int)DisplayValue / 10;
    }

    private void Operate(Operator op)
    {
        _operator = op;
        _overwrite = true;
    }

    private void Calculate()
    {
        DisplayValue = _integerCalculator.Execute(_operator, DisplayValue);
    }

    public void Exit()
    {
        Environment.Exit(0);
    }
}