namespace CapstoneApi.Services;

public class CalculatorService
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public double Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero");
        
        return (double)a / b;
    }

    public double Power(double baseNumber, double exponent) => Math.Pow(baseNumber, exponent);

    public double SquareRoot(double number)
    {
        if (number < 0)
            throw new ArgumentException("Cannot calculate square root of negative number");
        
        return Math.Sqrt(number);
    }
}
