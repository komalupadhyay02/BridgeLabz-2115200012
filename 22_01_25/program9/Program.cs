using System;

class StudentFee
{
    static void Main(string[] args)
    {
        // Create a variable to store the fee and discount percentage
        double fee, discountPercent;

        // Take user input for the fee and discount percentage
        Console.Write("Enter the fee for the course (in INR): ");
        fee = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the discount percentage: ");
        discountPercent = Convert.ToDouble(Console.ReadLine());

        // Call the method to calculate and display the discount and final fee
        CalculateAndDisplayDiscount(fee, discountPercent);
    }

    // Method to calculate and display the discount amount and final fee
    static void CalculateAndDisplayDiscount(double fee, double discountPercent)
    {
        // Calculate the discount amount
        double discount = (fee * discountPercent) / 100;

        // Calculate the final fee after discount
        double finalFee = fee - discount;

        // Display the results
        Console.WriteLine($"The discount amount is INR {discount:F2} and the final discounted fee is INR {finalFee:F2}");
    }
}