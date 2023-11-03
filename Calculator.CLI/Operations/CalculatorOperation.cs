namespace CalculatorCLI.Operations;

internal readonly ref struct CalculatorOperation
{
    public double Number1 { get; init; }
    public double Number2 { get; init; }
    public OperatorTypes Operator { get; init; }
}

