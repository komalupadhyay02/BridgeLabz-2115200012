using System;

class LinearSearchForWord
{
    static void Main()
    {
        Console.WriteLine("Enter the number of sentences:");
        int n = Convert.ToInt32(Console.ReadLine());

        string[] sentences = new string[n];
        Console.WriteLine("Enter the sentences:");
        for (int i = 0; i < n; i++)
        {
            sentences[i] = Console.ReadLine();
        }

        Console.WriteLine("Enter the word to search for:");
        string wordToFind = Console.ReadLine();

        string result = FindSentenceWithWord(sentences, wordToFind);
        if (!string.IsNullOrEmpty(result))
        {
            Console.WriteLine($"The first sentence containing the word '{wordToFind}' is:\n{result}");
        }
        else
        {
            Console.WriteLine($"The word '{wordToFind}' was not found in any sentence.");
        }
    }

    static string FindSentenceWithWord(string[] sentences, string word)
    {
        foreach (string sentence in sentences)
        {
            if (sentence.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                return sentence; // Return the first sentence containing the word
            }
        }
        return null; // Return null if no sentence contains the word
    }
}
