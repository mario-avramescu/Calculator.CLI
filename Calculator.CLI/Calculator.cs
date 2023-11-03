namespace CalculatorCLI;

public class Calculator
{
    private readonly CalculatorEngine engine;
    private readonly CalculatorTerminal terminal; 
    private readonly CalculatorRunner runner;

    public Calculator(ITextTerminal terminal)
    {
        this.terminal = new CalculatorTerminal(terminal);
        this.engine = new CalculatorEngine();
        this.runner = new CalculatorRunner();
    }

    public double? Calculate()
    {
        double? lastResult = null;
        runner.RunCalculation(() => {
            var operation = terminal.ReadOperation(lastResult);
            var result = engine.CalculateResult(operation);
            terminal.WriteResult(result);
            var option = terminal.ReadOption();
            lastResult = GetResultByOption(option, result.Ok);
            return option;
        });
        return lastResult;
    }

    private double? GetResultByOption(OptionTypes option, double? result) =>
        option == OptionTypes.Reset? null : result;
}