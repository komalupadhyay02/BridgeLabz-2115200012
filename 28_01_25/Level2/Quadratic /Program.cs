using System;

class QuadraticEquation
{
    static void Main(string[] args)
    {
        // Step 1: Take inputs for a, b, and c
        Console.WriteLine("Enter the coefficients of the quadratic equation (ax^2 + bx + c):");
        Console.Write("a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("c: ");
        double c = double.Parse(Console.ReadLine());

        // Step 2: Calculate the roots using the FindRoots method
        double[] roots = FindRoots(a, b, c);

        // Step 3: Display the results
        if (roots.Length == 0)
        {
            Console.WriteLine("The equation has no real roots.");
        }
        else if (roots.Length == 1)
        {
            Console.WriteLine($"The equation has one root: x = {roots[0]:F2}");
        }
        else
        {
            Console.WriteLine($"The equation has two roots: x1 = {roots[0]:F2}, x2 = {roots[1]:F2}");
        }
    }

    // Method to find the roots of a quadratic equation
    public static double[] FindRoots(double a, double b, double c)
    {
        // Calculate the discriminant (delta)
        double delta = Math.Pow(b, 2) - (4 * a * c);

        if (delta > 0) // Two distinct real roots
        {
            double root1 = (-b + Math.Sqrt(delta)) / (2 * a);
            double root2 = (-b - Math.Sqrt(delta)) / (2 * a);
            return new double[] { root1, root2 };
        }
        else if (delta == 0) // One real root
        {
            double root = -b / (2 * a);
            return new double[] { root };
        }
        else // No real roots
        {
            return new double[] { }; // Return an empty array
        }
    }
}
