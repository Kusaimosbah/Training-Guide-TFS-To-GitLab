// Unit tests for Calculator Service using xUnit
// These tests will run in the GitLab CI/CD pipeline

using CalculatorApp.Services;
using Xunit;

namespace CalculatorApp.Tests;

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
        int a = 5;
        int b = 3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_TwoNegativeNumbers_ReturnsSum()
    {
        // Arrange
        int a = -5;
        int b = -3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(-8, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        // Arrange
        int a = 10;
        int b = 4;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // Arrange
        int a = 4;
        int b = 5;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(20, result);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        // Arrange
        int a = 10;
        int b = 2;

        // Act
        double result = _calculator.Divide(a, b);

        // Assert
        Assert.Equal(5.0, result);
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }

    [Fact]
    public void Power_BaseAndExponent_ReturnsResult()
    {
        // Arrange
        double baseNumber = 2;
        double exponent = 3;

        // Act
        double result = _calculator.Power(baseNumber, exponent);

        // Assert
        Assert.Equal(8.0, result);
    }

    [Fact]
    public void SquareRoot_PositiveNumber_ReturnsRoot()
    {
        // Arrange
        double number = 16;

        // Act
        double result = _calculator.SquareRoot(number);

        // Assert
        Assert.Equal(4.0, result);
    }

    [Fact]
    public void SquareRoot_NegativeNumber_ThrowsException()
    {
        // Arrange
        double number = -16;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(number));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 2)]
    [InlineData(100, 50, 150)]
    [InlineData(-10, 10, 0)]
    public void Add_VariousInputs_ReturnsExpectedSum(int a, int b, int expected)
    {
        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    // ========================================
    // 📍 STEP 6: ADD PARAMETERIZED TESTS HERE
    // ========================================
    // Add comprehensive [Theory] tests with [InlineData] below this comment
    // These tests should cover Add, Subtract, and Divide operations
    // Example pattern:
    //
[Theory]
[InlineData(10, 5, 15)]
[InlineData(0, 0, 0)]
[InlineData(-5, -3, -8)]
[InlineData(100, 200, 300)]
public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
{
    var calculator = new CalculatorService();
    int result = calculator.Add(a, b);
    Assert.Equal(expected, result);
}

[Theory]
[InlineData(10, 5, 5)]
[InlineData(0, 5, -5)]
[InlineData(-10, -5, -5)]
public void Subtract_VariousInputs_ReturnsCorrectDifference(int a, int b, int expected)
{
    var calculator = new CalculatorService();
    int result = calculator.Subtract(a, b);
    Assert.Equal(expected, result);
}

[Theory]
[InlineData(10, 2, 5.0)]
[InlineData(100, 4, 25.0)]
[InlineData(9, 3, 3.0)]
public void Divide_ValidInputs_ReturnsQuotient(int a, int b, double expected)
{
    var calculator = new CalculatorService();
    double result = calculator.Divide(a, b);
    Assert.Equal(expected, result, precision: 10);
}

[Fact]
public void Divide_ByZero_ThrowsDivideByZeroException()
{
    var calculator = new CalculatorService();
    Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
}

} // ← Closing brace of CalculatorServiceTests class
