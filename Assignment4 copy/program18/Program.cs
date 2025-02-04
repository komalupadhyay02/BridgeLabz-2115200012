using System;

class Sum
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number:");
        int number = int.Parse(Console.ReadLine());
        CalculateSum(number); // Correct method call
    }

    static void CalculateSum(int n)
    {
        if (n <= 0) // Validate natural number (positive integer)
        {
            Console.WriteLine("The number is not a Natural Number");
            return; // Exit the method for invalid input
        }

        // Calculate the sum using the formula
        double formulaSum = n * (n + 1) / 2;

        // Calculate the sum using a loop
        int loopSum = 0;
        int i = 1;
        while (i <= n)
        {
            loopSum += i;
            i++;
        }

        // Display the results
        Console.WriteLine($"The sum of natural numbers using the formula is: {formulaSum}");
        Console.WriteLine($"The sum of natural numbers using the loop is: {loopSum}");

        // Compare the results
        if (formulaSum == loopSum)
        {
            Console.WriteLine("No difference between formulaSum and loopSum");
        }
        else
        {
            Console.WriteLine("Sum is different");
        }
    }
}
