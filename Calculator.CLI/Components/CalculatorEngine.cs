namespace CalculatorCLI.Components;

internal sealed class CalculatorEngine
{
    public (double? Ok, Exception? Error) CalculateResult(CalculatorOperation operation)
    {
        var number1 = operation.Number1;
        var number2 = operation.Number2;
        switch (operation.Operator)
        {
            case OperatorTypes.Plus: return (Sum(number1, number2), null);
            case OperatorTypes.Minus: return (Diff(number1, number2), null);
            case OperatorTypes.Star: return (Multiply(number1, number2), null);
            case OperatorTypes.Slash: return Divide(number1, number2);
            case OperatorTypes.Radical: return Sqrt(number2);
            default: return new() { Error = new NotImplementedException() };
        }
    }

    double Sum(double arg1, double arg2) => arg1 + arg2;
    double Diff(double arg1, double arg2) => arg1 - arg2;
    double Multiply(double arg1, double arg2) => arg1 * arg2;
    (double? OK, Exception? Error) Divide(double arg1, double arg2) => arg2 != 0? (arg1 / arg2, null): (null, new ArgumentException("You cannot divide by zero\n"));
    (double? Ok, Exception? Error) Sqrt(double arg) => arg >= 0 ? (Math.Sqrt(arg), null): (null, new ArgumentException("You cannot extrect square root from negative numbers"));
    
}
