using System;
using System.Text.RegularExpressions;

class ExtractLinks
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the text containing URLs:");
        string input = Console.ReadLine();

        // Define the regex pattern to match URLs
        string pattern = @"https?://[^\s]+";

        // Use Regex.Matches to find all URL matches in the input text
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Links:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("No links found in the input text.");
        }
    }
}
