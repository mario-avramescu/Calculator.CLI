namespace CalculatorCLI.Components;

internal sealed class CalculatorRunner
{
    public void RunCalculation(Func<OptionTypes> calculateFunc)
    {
        while(true)
        {
            var option = calculateFunc();
            if(option == OptionTypes.Stop)
                return;
        }
    }
}