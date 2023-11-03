using CalculatorCLI;
using CalculatorCLI.Terminal;

namespace CalculatorCLI.Tests;

public class MockTextTerminal : ITextTerminal
{
    byte readCounter = 0;
    
    public IList<string> ReadableInputs {get;}
    public IList<string> WrittenOutputs {get;}

    public MockTextTerminal(IList<string> readableInputs) 
    {
        this.ReadableInputs = readableInputs;
        this.WrittenOutputs = new List<string>();
    }

    public string? ReadText() => ReadableInputs[readCounter++];

    public void WriteText(string text) { 
        Console.WriteLine(text);
        WrittenOutputs.Add(text);
    }
}