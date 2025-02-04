using System;

class Trigonometry
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an angle in degrees:");
        double angle = Convert.ToDouble(Console.ReadLine());

        double[] trigValues = CalculateTrigonometricFunctions(angle);

        Console.WriteLine($"Sine of {angle} degrees: {trigValues[0]}");
        Console.WriteLine($"Cosine of {angle} degrees: {trigValues[1]}");
        Console.WriteLine($"Tangent of {angle} degrees: {trigValues[2]}");
    }

    static double[] CalculateTrigonometricFunctions(double angle)
    {
        // Convert the angle from degrees to radians
        double radians = (Math.PI * angle) / 180.0;

        // Calculate trigonometric values
        double sine = Math.Sin(radians);
        double cosine = Math.Cos(radians);
        double tangent = Math.Tan(radians);

        // Return the values in an array
        return new double[] { sine, cosine, tangent };
    }
}
