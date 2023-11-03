namespace CalculatorCLI.Numbers;

internal sealed class NumberReader
{
    const string HeaderMessage = "> Number: ";
    const string ErrorMessage = "Is not a number! Please enter a valid number!\n";

    private readonly ITextTerminal terminal;

    public NumberReader(ITextTerminal terminal)
    {
        this.terminal = terminal;
    }

    public double ReadNumber()
    {
        terminal.WriteText(HeaderMessage);
        var number = ParseNumber(terminal.ReadText());
        if(number.HasValue)
            return number.Value;
        terminal.WriteText(ErrorMessage);
        return ReadNumber();
    }

    double? ParseNumber(string? number) =>
        double.TryParse(number, out double result)? result : null;
}