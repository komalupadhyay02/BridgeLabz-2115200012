using System;

class DistanceConverter
{
    static void Main(string[] args)
    {
        // enter the distance in feet
        Console.Write("Enter the distance in feet: ");
        double distanceInFeet = Convert.ToDouble(Console.ReadLine());

        // Calling the method to calculate and display the results
        ConvertDistance(distanceInFeet);
    }

    // Method to convert distance to yards and miles
    static void ConvertDistance(double distanceInFeet)
    {
        // Conversion factors
        double feetPerYard = 3.0; // 1 yard = 3 feet
        double yardsPerMile = 1760.0; // 1 mile = 1760 yards

        // Calculate the distance in yards and miles
        double distanceInYards = distanceInFeet / feetPerYard;
        double distanceInMiles = distanceInYards / yardsPerMile;

        // Display the results
        Console.WriteLine($"The distance in feet is {distanceInFeet}.");
        Console.WriteLine($"The equivalent distance is {distanceInYards:F2} yards and {distanceInMiles:F4} miles.");
    }
}