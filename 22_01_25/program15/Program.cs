using System;

class TotalPriceCalculator
{
    static void Main(string[] args)
    {
        //the unit price and quantity
        Console.Write("Enter the unit price of the item (in INR): ");
        double unitPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the quantity to be bought: ");
        int quantity = Convert.ToInt32(Console.ReadLine());

        // Calling the method to calculate and display the total price
        CalculateTotalPrice(unitPrice, quantity);
    }

    // Method to calculate and display the total price
    static void CalculateTotalPrice(double unitPrice, int quantity)
    {
        double totalPrice = unitPrice * quantity; // Calculate the total price

        // Display the total price
        Console.WriteLine($"The total purchase price is INR {totalPrice:F2} if the quantity is {quantity} and unit price is INR {unitPrice:F2}");
    }
}