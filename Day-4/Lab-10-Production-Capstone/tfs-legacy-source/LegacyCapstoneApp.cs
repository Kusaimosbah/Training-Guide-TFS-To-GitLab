using System;

namespace TfsLegacyCode
{
    /// <summary>
    /// LEGACY CODE FROM TFS SOURCE CONTROL
    /// This represents the old application before migration to GitLab
    /// DO NOT MODIFY - For reference only
    /// 
    /// Original TFS Details:
    /// - Project: $/LegacyApps/CapstoneApi
    /// - Branch: $/Main
    /// - Last Changeset: 12345
    /// - Last Modified: 2023-01-15
    /// </summary>
    class LegacyCalculatorApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("LEGACY TFS APPLICATION");
            Console.WriteLine("=================================");
            Console.WriteLine();
            Console.WriteLine("This was the old monolithic application managed in TFS.");
            Console.WriteLine();
            Console.WriteLine("Issues with TFS workflow:");
            Console.WriteLine("- Check-out/check-in locks");
            Console.WriteLine("- No easy branching strategy");
            Console.WriteLine("- Limited merge capabilities");
            Console.WriteLine("- No built-in CI/CD");
            Console.WriteLine("- Slow shelvesets for code review");
            Console.WriteLine();
            Console.WriteLine("MODERNIZED IN GITLAB:");
            Console.WriteLine("✓ Git-based version control");
            Console.WriteLine("✓ Feature branch workflow");
            Console.WriteLine("✓ Merge Requests for code review");
            Console.WriteLine("✓ Automated CI/CD pipelines");
            Console.WriteLine("✓ Containerized deployment");
            Console.WriteLine("✓ Automated testing");
            Console.WriteLine();
            
            // Old calculator logic (before refactoring)
            int result = OldCalculate(10, 5);
            Console.WriteLine($"Legacy calculation: 10 + 5 = {result}");
            Console.WriteLine();
            Console.WriteLine("Migration to GitLab complete! ✓");
        }

        // Old method signature - kept for historical reference
        static int OldCalculate(int x, int y)
        {
            // Simple calculation - now modernized as RESTful API
            return x + y;
        }
    }
}
