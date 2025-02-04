using System;

class RemoveCharacter
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the String:");
        string input = Console.ReadLine();

        Console.WriteLine("Enter the Character to Remove:");
        char charToRemove = Console.ReadKey().KeyChar; // Read a single character input
        Console.WriteLine(); // Move to the next line

        string result = RemoveChar(input, charToRemove);
        Console.WriteLine($"Modified String: {result}");
    }

    static string RemoveChar(string input, char charToRemove)
    {
        string result = "";
        foreach (char c in input)
        {
            if (c != charToRemove)
            {
                result += c;
            }
        }
        return result;
    }
}
