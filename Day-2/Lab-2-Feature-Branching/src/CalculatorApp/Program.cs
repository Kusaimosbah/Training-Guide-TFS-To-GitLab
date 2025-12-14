// Console Application using Calculator Service
// Demonstrates the calculator functionality
// NOTE: Methods will be added during feature branch exercises

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
        
        Console.WriteLine("Calculator service initialized.");
        Console.WriteLine("Operations will be added in feature branches during the lab.");

        // NOTE: Methods will be called here as you add them in feature branches
        // After completing the lab, this will demonstrate:
        // - Addition
        // - Subtraction  
        // - Multiplication
        // - Division

        Console.WriteLine();
        Console.WriteLine("=========================================");
        Console.WriteLine("Ready for feature development!");
        Console.WriteLine("=========================================");
    }
}
