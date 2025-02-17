using System;
using System.IO;

class WordCountInFile
{
    static void Main()
    {
        Console.WriteLine("Enter the file path:");
        string filePath = Console.ReadLine();

        Console.WriteLine("Enter the word to count:");
        string wordToFind = Console.ReadLine();

        try
        {
            int count = CountWordOccurrences(filePath, wordToFind);
            Console.WriteLine($"The word '{wordToFind}' appears {count} times in the file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static int CountWordOccurrences(string filePath, string word)
    {
        int wordCount = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' },
                                            StringSplitOptions.RemoveEmptyEntries);

                foreach (string w in words)
                {
                    if (w.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        wordCount++;
                    }
                }
            }
        }

        return wordCount;
    }
}
