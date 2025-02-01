using System;

class Program
{
    static void Main(string[] args)
    {
        // Distance in kilometers
        double distanceInKm = 10.8;

        // Call the method to convert distance
        double distanceInMiles = ConvertKmToMiles(distanceInKm);

        // Output the result
        Console.WriteLine($"The distance {distanceInKm} km in miles is {distanceInMiles:F2}");
    }

    // Method to convert kilometers to miles
    static double ConvertKmToMiles(double kilometers)
    {
        double conversionFactor = 1.6;
        return kilometers / conversionFactor;
    }
}

