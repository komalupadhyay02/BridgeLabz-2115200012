using System;
using System.Text.RegularExpressions;

class ValidateIPAddress
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an IP address:");
        string ipAddress = Console.ReadLine();

        if (IsValidIPAddress(ipAddress))
        {
            Console.WriteLine("Valid IPv4 address.");
        }
        else
        {
            Console.WriteLine("Invalid IPv4 address.");
        }
    }

    static bool IsValidIPAddress(string ipAddress)
    {
        // Regular expression for IPv4 validation
        string pattern = @"^((25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.){3}(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$";
        return Regex.IsMatch(ipAddress, pattern);
    }
}
