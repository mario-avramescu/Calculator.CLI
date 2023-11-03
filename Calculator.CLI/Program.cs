namespace CalculatorCLI;

class MainCalculator 
{
    static void Main()
    {
        new Calculator(new TextTerminal()).Calculate();
    }
}