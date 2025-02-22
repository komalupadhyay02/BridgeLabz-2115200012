using System;
using System.Text.RegularExpressions;

class ReplaceMultipleSpaces
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence with multiple spaces:");
        string input = Console.ReadLine();

        // Replace multiple spaces with a single space
        string result = Regex.Replace(input, @"\s+", " ");

        Console.WriteLine("Output with single spaces:");
        Console.WriteLine(result);
    }
}
