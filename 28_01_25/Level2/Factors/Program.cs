using System;

class FindFactor
{
    static void Main(string[] Args)
    {
        Console.WriteLine("Enter the number");
        int number = int.Parse(Console.ReadLine());

        // Find factors and store them in an array
        int[] factors = FindFactors(number);

        // Display results
        Console.WriteLine($"The Factors of the number are: {string.Join(", ", factors)}");
        Console.WriteLine($"The Sum of all Factors is: {CalculateSum(factors)}");
        Console.WriteLine($"The Product of all Factors is: {CalculateProduct(factors)}");
        Console.WriteLine($"The Sum of Squares of all Factors is: {CalculateSumOfSquare(factors)}");
    }

    // Renamed method to 'FindFactors'
    static int[] FindFactors(int num)
    {
        int count = 0;

        // Count the number of factors
        for (int i = 1; i <= num; i++) // Start from 1 (not 0) and go up to num
        {
            if (num % i == 0)
            {
                count++;
            }
        }

        int[] factors = new int[count];
        int index = 0;

        // Store the factors in the array
        for (int i = 1; i <= num; i++) // Same loop range as above
        {
            if (num % i == 0)
            {
                factors[index++] = i;
            }
        }

        return factors;
    }

    // Method to calculate the sum of factors
    static int CalculateSum(int[] factors)
    {
        int sum = 0;
        foreach (int factor in factors)
        {
            sum += factor;
        }
        return sum;
    }

    // Method to calculate the product of factors
    static long CalculateProduct(int[] factors)
    {
        long product = 1; // Changed from int to long to avoid overflow
        foreach (int factor in factors)
        {
            product *= factor;
        }
        return product;
    }

    // Method to calculate the sum of squares of factors
    static double CalculateSumOfSquare(int[] factors)
    {
        double sumOfSquare = 0; // Changed type to double to match Math.Pow return type
        foreach (int factor in factors)
        {
            sumOfSquare += Math.Pow(factor, 2);
        }
        return sumOfSquare;
    }
}
