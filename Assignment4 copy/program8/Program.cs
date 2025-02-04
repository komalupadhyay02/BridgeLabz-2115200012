using System;

class Counter
{
    static void Main(string[] args)
    {
        // User Input
        Console.WriteLine("Enter the Number:");
        int counter = int.Parse(Console.ReadLine());

        // Call the CountDown method
        CountDown(counter);
    }

    // Method for countdown
    static void CountDown(int counter)
    {
        while (counter >= 0)
        {
            Console.WriteLine(counter); // Proper syntax
            counter--; // Decrement the counter
        }
    }
}
