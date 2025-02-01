using System;

class Calculator
{
    // Main method
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first Number");
        int n1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the second Number");
        int n2 = Convert.ToInt32(Console.ReadLine());

        // Call methods to perform operations and print the results
        Console.WriteLine($"The addition, subtraction, multiplication and division value of {n1} and {n2} is {Sum(n1, n2)}, {Substraction(n1, n2)}, {Multiplication(n1, n2)}, and {Division(n1, n2)}");
    }

    // Method to calculate sum
    static int Sum(int n1, int n2)
    {
        return n1 + n2;
    }

    // Method to calculate subtraction
    static int Substraction(int n1, int n2)
    {
        return n1 - n2;
    }

    // Method to calculate multiplication
    static int Multiplication(int n1, int n2)
    {
        return n1 * n2;
    }

    // Method to calculate division
    static string Division(int n1, int n2)
    {
        if (n2 == 0)
        {
            return "undefined (cannot divide by zero)";
        }
        else
        {
            return (n1 / (double)n2).ToString("F2");  // Returns result as string with two decimal points
        }
    }
}
