using System;
using System.Text.RegularExpressions;

class ExtractCapitalizedWords
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        // Define the regex pattern for capitalized words
        string pattern = @"\b[A-Z][a-z]*\b";

        // Use Regex.Matches to find all matches in the input sentence
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Capitalized Words:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("No capitalized words found.");
        }
    }
}
