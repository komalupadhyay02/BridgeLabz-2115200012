using System;
<<<<<<< HEAD
class MyProject{
static void Main(String[] Args){
Console.WriteLine("enter the base");
double baseN=Convert.ToDouble(Console.ReadLine());
Console.WriteLine("enter the exponent");
double exponent=Convert.ToDouble(Console.ReadLine());
double num=Math.Pow(baseN, exponent);
Console.WriteLine($"the number is: {num}");
}
}
=======

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
>>>>>>> origin/feature
