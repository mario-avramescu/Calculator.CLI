namespace CalculatorCLI.Results;

internal sealed class ResultWriter
{
    const string ResultOK = "Operation result is 3";
    const string ResultError = "> Calculation Error: ";
    
    private readonly ITextTerminal terminal;

    public ResultWriter(ITextTerminal terminal)
    {
        this.terminal = terminal;
    }

    public void WriteResult((double? OK, Exception? Error) result)
    {
        if(result.OK.HasValue)
            terminal.WriteText(ResultOK + result.OK!.Value + "\n");
        else
            terminal.WriteText(ResultError + result.Error!.Message);
    }

}