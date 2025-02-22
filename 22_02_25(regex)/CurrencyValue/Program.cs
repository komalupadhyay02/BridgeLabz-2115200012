using System;
using System.Text.RegularExpressions;

class CurrencyExtractor
{
    static void Main(string[] args)
    {
        string text = "The price is $45.99, and the discount is $ 10.50.";

        // Regex pattern to match currency values
        string pattern = @"\$\s?\d+(\.\d{2})?";

        // Find matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Currency Values:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value.Trim());
        }
    }
}
