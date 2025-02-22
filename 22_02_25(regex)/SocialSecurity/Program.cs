using System;
using System.Text.RegularExpressions;

class SSNValidator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a Social Security Number (SSN):");
        string input = Console.ReadLine();

        // Regex pattern to validate SSN
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        if (Regex.IsMatch(input, pattern))
        {
            Console.WriteLine($"✅ \"{input}\" is valid");
        }
        else
        {
            Console.WriteLine($"❌ \"{input}\" is invalid");
        }
    }
}
