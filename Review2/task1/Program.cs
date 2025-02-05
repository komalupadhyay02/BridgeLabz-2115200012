using System;

class Character
{
    static void CountCharacters(string input)
    {
        int[] charCount = new int[256]; 

       
        foreach (char ch in input)
        {
            charCount[ch]++;
        }

        
        Console.WriteLine("Character Occurence:");
        for (int i = 0; i < 256; i++)
        {
            if (charCount[i] > 0)
            {
                Console.WriteLine($"'{(char)i}' : {charCount[i]}");
            }
        }
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        CountCharacters(input);
    }
}
