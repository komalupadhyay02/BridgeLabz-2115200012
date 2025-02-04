using System;

class SmallestAndLargest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        int number1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        int number2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the third number:");
        int number3 = Convert.ToInt32(Console.ReadLine());

        // Call the method to find the smallest and largest numbers
        int[] results = FindSmallestAndLargest(number1, number2, number3);

        Console.WriteLine($"The smallest number is: {results[0]}");
        Console.WriteLine($"The largest number is: {results[1]}");
    }

    public static int[] FindSmallestAndLargest(int number1, int number2, int number3)
    {
        // Find the smallest number
        int smallest = Math.Min(number1, Math.Min(number2, number3));

        // Find the largest number
        int largest = Math.Max(number1, Math.Max(number2, number3));

        // Return the smallest and largest numbers in an array
        return new int[] { smallest, largest };
    }
}
