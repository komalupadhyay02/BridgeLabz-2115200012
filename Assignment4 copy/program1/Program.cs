using System;

class Division
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the Number:");
        int number = int.Parse(Console.ReadLine());
        
        // Checking divisibility and assign result
        string result = DivisibleOf5(number) ? "Yes" : "No";
        
        // Display the result
        Console.WriteLine($"Is the number {number} divisible by 5? {result}");
    }

    // Method to check if the number is divisible by 5
    static bool DivisibleOf5(int number)
    {
        return number % 5 == 0;
    }
}
