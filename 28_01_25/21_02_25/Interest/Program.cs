using System;

class InterestCalculator
{
    static double CalculateInterest(double amount, double rate, int years)
    {
        // Check for invalid inputs
        if (amount < 0 || rate < 0)
        {
            throw new ArgumentException("Amount and rate must be positive.");
        }

        // Simple interest formula: Interest = Principal * Rate * Time
        return amount * rate * years / 100;
    }

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the principal amount:");
            double amount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the annual interest rate (in %):");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the time period in years:");
            int years = Convert.ToInt32(Console.ReadLine());

            double interest = CalculateInterest(amount, rate, years);
            Console.WriteLine($"Calculated Interest: {interest:C}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Invalid input: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input: Please enter numeric values.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
