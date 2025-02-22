using System;
using System.Text.RegularExpressions;

class ValidateLicensePlate
{
    static bool IsValidLicensePlate(string plate)
    {
        // Define the regular expression for a valid license plate
        string pattern = @"^[A-Z]{2}\d{4}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(plate);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a license plate to validate:");
        string input = Console.ReadLine();

        if (IsValidLicensePlate(input))
        {
            Console.WriteLine("✅ Valid license plate");
        }
        else
        {
            Console.WriteLine("❌ Invalid license plate");
        }
    }
}

