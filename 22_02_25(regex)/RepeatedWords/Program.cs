using System;
using System.Text.RegularExpressions;

class RepeatingWordsFinder
{
    static void Main(string[] args)
    {
        string input = "This is is a repeated repeated word test.";

        // Regex pattern to find repeating words
        string pattern = @"\b(\w+)\b\s+\b\1\b";

        // Find matches in the input
        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.IgnoreCase);

        Console.WriteLine("Repeating Words:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Groups[1].Value);
        }
    }
}
