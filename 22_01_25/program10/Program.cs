using System;

class Height
{
    static void Main(string[] args)
    {
        // variable to store the height in centimeters
        double heightCm;

        // user input for the height in centimeters
        Console.Write("Enter your height in centimeters: ");
        heightCm = Convert.ToDouble(Console.ReadLine());

        // Call the method to convert and display the height in feet and inches
        heightInFeet(heightCm);
    }

    // Method to convert height in feet and inches
    static void heightInFeet(double heightCm)
    {
        // 1 inch = 2.54 cm, 1 foot = 12 inches
        double heightInches = heightCm / 2.54;  // Convert height to inches
        int feet = (int)(heightInches / 12);    // Get feet by dividing by 12
        double inches = heightInches % 12;     // Get remaining inches

        //results
        Console.WriteLine($"Your height in cm is {heightCm} while in feet is {feet} and inches is {inches:F2}");
    }
}