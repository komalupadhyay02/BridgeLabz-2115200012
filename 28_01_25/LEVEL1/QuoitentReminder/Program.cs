using System;

class QuotientRemainderCalculator
{
    static void Main(string[] args)
    {
        // enter the two numbers
        Console.Write("Enter the first number: ");
        int n1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int n2 = Convert.ToInt32(Console.ReadLine());

        // Calling the method to calculate and display the quotient and remainder
        QuotientAndRemainder(n1, n2);
    }

    // Method to calculate and display the quotient and remainder
    static void QuotientAndRemainder(int n1, int n2)
    {
        if (n2 == 0)
        {
            Console.WriteLine("Division by zero is not allowed.");
            return;
        }

        int quotient = n1 / n2;   // Calculate the quotient
        int remainder = n1 % n2; // Calculate the remainder

        // results
        Console.WriteLine($"The Quotient is {quotient} and Remainder is {remainder} of two numbers {n1} and {n2}");
    }
}