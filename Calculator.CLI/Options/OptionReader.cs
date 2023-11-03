namespace CalculatorCLI.Options;

internal sealed class OptionReader
{
    const string HeaderMessage = "> Options (y/n/reset): ";
    const string ErrorMessage = "Is not a valid option! Please enter a valid option!\n";

    private readonly ITextTerminal terminal;

    public OptionReader(ITextTerminal terminal)
    {
        this.terminal = terminal;
    }

    public OptionTypes ReadOption()
    {
        terminal.WriteText(HeaderMessage);
        var option = ParseOption(terminal.ReadText());
        if(option.HasValue)
            return option.Value;
        terminal.WriteText(ErrorMessage);
        return ReadOption();
    }

    OptionTypes? ParseOption(string? option) 
    {
        switch(option?.ToLower())
        {
            case "y": return OptionTypes.Continue;
            case "n": return OptionTypes.Stop;
            case "reset": return OptionTypes.Reset;
            default: return null;
        }
    }
        

}