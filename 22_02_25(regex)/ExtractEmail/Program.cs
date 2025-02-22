using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the text:");
        string input = Console.ReadLine();

        // Define the regex pattern for email addresses
        string pattern = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}";

        // Use Regex.Matches to find all matches in the input text
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Email Addresses:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("No email addresses found.");
        }
    }
}
