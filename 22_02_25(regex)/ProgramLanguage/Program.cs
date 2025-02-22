using System;
using System.Text.RegularExpressions;

class ProgrammingLanguageExtractor
{
    static void Main(string[] args)
    {
        string text = "I love Java, Python, and JavaScript, but I haven't tried Go yet.";

        // Regex pattern to match programming language names
        string pattern = @"\b(JavaScript|Java|Python|Go|C\+\+|C#|Ruby|PHP|Swift|Kotlin|TypeScript|Perl|R)\b";

        // Find matches in the text
        MatchCollection matches = Regex.Matches(text, pattern);

        Console.WriteLine("Extracted Programming Languages:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}
