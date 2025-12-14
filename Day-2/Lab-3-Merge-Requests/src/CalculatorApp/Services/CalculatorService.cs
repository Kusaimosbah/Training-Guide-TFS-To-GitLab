// Calculator Service for Lab Day 2
// This service demonstrates unit testing and CI/CD integration

namespace CalculatorApp.Services;

/// <summary>
/// Simple calculator service with basic arithmetic operations
/// </summary>
public class CalculatorService
{
    /// <summary>
    /// Adds two numbers
    /// </summary>
    public int Add(int a, int b)
    {
        return a + b;
    }

    /// <summary>
    /// Subtracts second number from first
    /// </summary>
    public int Subtract(int a, int b)
    {
        return a - b;
    }

    /// <summary>
    /// Multiplies two numbers
    /// </summary>
    public int Multiply(int a, int b)
    {
        return a * b;
    }

    /// <summary>
    /// Divides first number by second
    /// </summary>
    /// <exception cref="DivideByZeroException">Thrown when dividing by zero</exception>
    public double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }
        return (double)a / b;
    }

    /// <summary>
    /// Calculates the power of a number
    /// </summary>
    public double Power(double baseNumber, double exponent)
    {
        return Math.Pow(baseNumber, exponent);
    }

    /// <summary>
    /// Calculates the square root of a number
    /// </summary>
    /// <exception cref="ArgumentException">Thrown when input is negative</exception>
    public double SquareRoot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentException("Cannot calculate square root of negative number");
        }
        return Math.Sqrt(number);
    }

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero", nameof(b));
        }
        return a / b;
    }
}