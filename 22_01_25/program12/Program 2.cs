using System;

class TriangleArea
{
    static void Main(string[] args)
    {
        // Take user input for base and height in inches
        Console.Write("Enter the base of the triangle (in inches): ");
        double baseInInches = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the height of the triangle (in inches): ");
        double heightInInches = Convert.ToDouble(Console.ReadLine());

        // Calling the method to calculate and display the area
        CalculateAndDisplayArea(baseInInches, heightInInches);
    }

    // Method to calculate and display the area of the triangle
    static void CalculateAndDisplayArea(double baseInInches, double heightInInches)
    {
        // Calculating the area in square inches
        double areaInInches = 0.5 * baseInInches * heightInInches;

        // Convert area to square centimeters (1 inch = 2.54 cm, so 1 square inch = 6.4516 cm²)
        double areaInCm = areaInInches * 6.4516;

        //results
        Console.WriteLine($"The area of the triangle is {areaInInches:F2} square inches and {areaInCm:F2} square centimeters.");
    }
}