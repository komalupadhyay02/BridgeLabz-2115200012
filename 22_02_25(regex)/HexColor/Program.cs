using System;
using System.Text.RegularExpressions;

class ValidateHexColor
{
    static bool IsValidHexColor(string color)
    {
        // Define the regular expression for a valid hex color code
        string pattern = @"^#[0-9A-Fa-f]{6}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(color);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a hex color code to validate:");
        string input = Console.ReadLine();

        if (IsValidHexColor(input))
        {
            Console.WriteLine("✅ Valid hex color code");
        }
        else
        {
            Console.WriteLine("❌ Invalid hex color code");
        }
    }
}
