using System;

class RemoveDuplicate
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the String:");
        string input = Console.ReadLine();
        
        string result = new string(input.Distinct().ToArray());
        Console.WriteLine($"String after removing duplicates: {result}");
    }

   
}
