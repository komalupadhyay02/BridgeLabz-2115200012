using System;

class EarthVolume
{
    static void Main(string[] args)
    {
        // Radius of the Earth in kilometers
        double radiusKm = 6378;

        // Call the method to calculate and display the volume in both km^3 and miles^3
        CalculateAndDisplayVolume(radiusKm);
    }

    // Method to calculate and display the volume of Earth in cubic kilometers and cubic miles
    static void CalculateAndDisplayVolume(double radiusKm)
    {
        // Conversion factor: 1 kilometer = 0.621371 miles
        double kmToMiles = 0.621371;

        // Calculate the volume in cubic kilometers
        double volumeKm3 = (4.0 / 3.0) * Math.PI * Math.Pow(radiusKm, 3);

        // Convert radius to miles and calculate the volume in cubic miles
        double radiusMiles = radiusKm * kmToMiles;
        double volumeMiles3 = (4.0 / 3.0) * Math.PI * Math.Pow(radiusMiles, 3);

        // Display the results
        Console.WriteLine($"The volume of Earth in cubic kilometers is {volumeKm3:F2} and in cubic miles is {volumeMiles3:F2}");
    }
}

