namespace CalculatorCLI.Tests;


public class CalculatorTests
{
 
    [Theory]
    [InlineData("1", "+", "2", "n")]
    public void valid_numbers_and_operations__calculate__operation_result(params string[] inputs)
    {
        var calculator = new Calculator(new MockTextTerminal(inputs));
        var actual = calculator.Calculate();

        Assert.Equal(actual, 3);
    }
}
