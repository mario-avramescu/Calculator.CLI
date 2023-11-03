namespace CalculatorCLI.Operators;

internal sealed class OperatorReader
{
    const string HeaderMessage = "> Operator [+,-,*,/]: ";
    const string ErrorMessage = "Is not an operator! Please enter a valid operator!\n";
    const string RadicalChar = "\u221A";

    private readonly ITextTerminal terminal;

    public OperatorReader(ITextTerminal terminal)
    {
        this.terminal = terminal;
    }

    public OperatorTypes ReadOperator()
    {
        terminal.WriteText(HeaderMessage);
        var @operator = ParseOperator(terminal.ReadText());
        if(@operator.HasValue)
            return @operator.Value;
        terminal.WriteText(ErrorMessage);
        return ReadOperator();
    }

    OperatorTypes? ParseOperator(string? @operator) 
    {
        switch(@operator)
        {
            case "+": return OperatorTypes.Plus;
            case "-": return OperatorTypes.Minus;
            case "*": return OperatorTypes.Star;
            case "/": return OperatorTypes.Slash;
            case RadicalChar: return OperatorTypes.Radical;
            default: return null;
        }
    }
}