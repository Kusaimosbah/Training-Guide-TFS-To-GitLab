// Console Application using Calculator Service
// Demonstrates the calculator functionality

using CalculatorApp.Services;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=========================================");
        Console.WriteLine("   Calculator App - Lab Day 2");
        Console.WriteLine("=========================================");
        Console.WriteLine();

        var calculator = new CalculatorService();

        // Demonstrate addition
        int sum = calculator.Add(10, 5);
        Console.WriteLine($"10 + 5 = {sum}");

        // Demonstrate subtraction
        int difference = calculator.Subtract(10, 5);
        Console.WriteLine($"10 - 5 = {difference}");

        // Demonstrate multiplication
        int product = calculator.Multiply(10, 5);
        Console.WriteLine($"10 × 5 = {product}");

        // Demonstrate division
        double quotient = calculator.Divide(10, 5);
        Console.WriteLine($"10 ÷ 5 = {quotient}");

        // Demonstrate power
        double power = calculator.Power(2, 3);
        Console.WriteLine($"2³ = {power}");

        // Demonstrate square root
        double sqrt = calculator.SquareRoot(16);
        Console.WriteLine($"√16 = {sqrt}");

        Console.WriteLine();
        Console.WriteLine("=========================================");
        Console.WriteLine("All operations completed successfully!");
        Console.WriteLine("=========================================");
    }
}
