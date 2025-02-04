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
        
        for (int i = counter; i > 0; i--) // Loop to count down
        {
            Console.WriteLine(i); 
        }

       
        Console.WriteLine("Launch");
    }
}
