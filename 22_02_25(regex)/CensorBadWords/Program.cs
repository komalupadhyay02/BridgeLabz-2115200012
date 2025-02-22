using System;
using System.Text.RegularExpressions;

class CensorBadWords
{
    static void Main(string[] args)
    {
        // List of bad words
        string[] badWords = { "damn", "stupid" };

        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        // Replace bad words with "****"
        string censoredSentence = CensorWords(input, badWords);

        Console.WriteLine("Censored Sentence:");
        Console.WriteLine(censoredSentence);
    }

    static string CensorWords(string input, string[] badWords)
    {
        foreach (string word in badWords)
        {
            string pattern = $@"\b{Regex.Escape(word)}\b"; // Match the whole word
            input = Regex.Replace(input, pattern, "****", RegexOptions.IgnoreCase);
        }
        return input;
    }
}
