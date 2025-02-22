using System;
using System.Text.RegularExpressions;

class ExtractDates
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the text containing dates:");
        string input = Console.ReadLine();

        // Define the regex pattern for dates in dd/mm/yyyy format
        string pattern = @"\b(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}\b";

        // Use Regex.Matches to find all date matches in the input text
        MatchCollection matches = Regex.Matches(input, pattern);

        if (matches.Count > 0)
        {
            Console.WriteLine("Extracted Dates:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
        else
        {
            Console.WriteLine("No dates found in the input text.");
        }
    }
}
