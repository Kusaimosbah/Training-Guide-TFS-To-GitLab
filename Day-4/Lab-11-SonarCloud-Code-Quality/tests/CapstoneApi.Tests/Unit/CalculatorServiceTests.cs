using CapstoneApi.Services;
using Xunit;

namespace CapstoneApi.Tests.Unit;

public class CalculatorServiceTests
{
    private readonly CalculatorService _calculator;

    public CalculatorServiceTests()
    {
        _calculator = new CalculatorService();
    }

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange
        int a = 5, b = 3;

        // Act
        var result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        // Arrange
        int a = 10, b = 3;

        // Act
        var result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(7, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // Arrange
        int a = 4, b = 5;

        // Act
        var result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void Divide_ValidNumbers_ReturnsQuotient()
    {
        // Arrange
        int a = 10, b = 2;

        // Act
        var result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        // Arrange
        int a = 10, b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Theory]
    [InlineData(2, 3, 8)]
    [InlineData(5, 2, 25)]
    [InlineData(3, 4, 81)]
    public void Power_ValidInputs_ReturnsCorrectResult(double baseNum, double exp, double expected)
    {
        // Act
        var result = _calculator.Power(baseNum, exp);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SquareRoot_PositiveNumber_ReturnsRoot()
    {
        // Arrange
        double number = 16;

        // Act
        var result = _calculator.SquareRoot(number);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsException()
    {
        // Arrange
        double number = -4;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(number));
    }
}
