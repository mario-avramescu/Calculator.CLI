namespace CalculatorCLI.Components;

internal sealed class CalculatorTerminal
{
    private readonly NumberReader numberReader;
    private readonly OperatorReader operatorReader;
    private readonly OptionReader optionReader;
    private readonly ResultWriter resultWriter;

    public CalculatorTerminal(ITextTerminal terminal)
    {
        this.numberReader = new NumberReader(terminal);
        this.operatorReader = new OperatorReader(terminal);
        this.optionReader = new OptionReader(terminal);
        this.resultWriter = new ResultWriter(terminal);
    }

    public CalculatorOperation ReadOperation(double? number1) => 
        new() { 
            Number1 = number1.HasValue? number1.Value : numberReader.ReadNumber(),
            Operator = operatorReader.ReadOperator(),
            Number2 = numberReader.ReadNumber()
        };
    
    public void WriteResult((double? OK, Exception? Error) result)
    {
        resultWriter.WriteResult(result);
    }

    public OptionTypes ReadOption() =>
        optionReader.ReadOption();
}