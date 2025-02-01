using System;

class ProfitLoss
{
    static void Main(string[] args)
    {
        // Cost price and selling price
        double costPrice = 129;
        double sellingPrice = 191;

        // Calculate profit and profit percentage
        double profit = sellingPrice - costPrice;
        double profitPercentage = (profit / costPrice) * 100;

        // Display the output 
        Console.WriteLine($@"
The Cost Price is INR {costPrice} and Selling Price is INR {sellingPrice}.
The Profit is INR {profit} and the Profit Percentage is {profitPercentage:F2}%");
    }
}