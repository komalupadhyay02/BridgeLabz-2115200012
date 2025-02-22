using System;
using System.Text.RegularExpressions;

class ValidateUsername
{
    static bool IsValidUsername(string username)
    {
        // Define the regular expression for a valid username
        string pattern = @"^[a-zA-Z][a-zA-Z0-9_]{4,14}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(username);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter a username to validate:");
        string input = Console.ReadLine();

        if (IsValidUsername(input))
        {
            Console.WriteLine("✅ Valid username");
        }
        else
        {
            Console.WriteLine("❌ Invalid username");
        }
    }
}
