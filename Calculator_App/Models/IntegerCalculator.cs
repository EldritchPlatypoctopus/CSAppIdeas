namespace Calculator_App.Models;

public class IntegerCalculator: ICalculator<double>
{
    private double _value = 0;
    public double Execute(Operator op, double operand)
    {
        switch (op)
        {
            case Operator.Add:
                _value += operand;
                break;
            case Operator.Subtract:
                _value -= operand;
                break;
            case Operator.Multiply:
                _value *= operand;
                break;
            case Operator.Divide:
                if (operand != 0)
                {
                    _value = (int)_value / operand;
                }
                break;
        }
        return _value;
    }

    public void Clear()
    {
        _value = 0;
    }
}