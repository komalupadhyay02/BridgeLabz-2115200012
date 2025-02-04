
using System;

class AthleteRun
{
    static void Main(string[] args)
    {
        // user input for the three sides of the triangle
        Console.Write("Enter the first side of the triangle in meters: ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the second side of the triangle in meters: ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the third side of the triangle in meters: ");
        double side3 = Convert.ToDouble(Console.ReadLine());

        // Calculating the perimeter of the triangle
        double perimeter = CalculatePerimeter(side1, side2, side3);

        // Converting 5 km to meters (5000 meters)
        double totalDistance = 5000;

        // Calculating the number of rounds required to cover 5 km
        double rounds = totalDistance / perimeter;

        // number of rounds
        Console.WriteLine($"The total number of rounds the athlete will run to complete 5 km is {rounds:F2}");
    }

    // Method to calculate the perimeter of the triangle
    static double CalculatePerimeter(double side1, double side2, double side3)
    {
        return side1 + side2 + side3;
    }
}

