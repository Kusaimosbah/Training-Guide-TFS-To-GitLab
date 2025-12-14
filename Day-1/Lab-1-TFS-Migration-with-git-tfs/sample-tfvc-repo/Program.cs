using LegacyApp;

var calc = new Calculator();

Console.WriteLine("=== Legacy Application Calculator ===");
Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}");
Console.WriteLine($"6 * 7 = {calc.Multiply(6, 7)}");
Console.WriteLine($"20 / 5 = {calc.Divide(20, 5)}");
