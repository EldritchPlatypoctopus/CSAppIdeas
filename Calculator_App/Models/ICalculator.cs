namespace Calculator_App.Models;

public interface ICalculator<T>
{
    public T Execute(Operator op, T operand);
    public void Clear();
}