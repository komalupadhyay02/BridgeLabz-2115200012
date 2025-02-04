using System;

class FootBall
{
    static void Main(string[] args)
    {
        double[] heights = new double[11];
        Console.WriteLine("Enter the height of the players in the range of 150 cm to 250 cm:");

        for (int i = 0; i < 11; i++)
        {
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        double arraySum = SumOfArray(heights);
        double mean = MeanHeight(heights);
        double shortHeight = ShortestHeight(heights);
        double tallHeight = TallestHeight(heights);

        Console.WriteLine($"The Sum of Array is: {arraySum:F2}");
        Console.WriteLine($"The Mean Height is: {mean:F2}");
        Console.WriteLine($"The Shortest Height is: {shortHeight:F2}");
        Console.WriteLine($"The Tallest Height is: {tallHeight:F2}");
    }

    // Method to calculate the sum of the array
    static double SumOfArray(double[] heights)
    {
        double sum = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            sum += heights[i];
        }
        return sum;
    }

    // Method to calculate the mean height
    static double MeanHeight(double[] heights)
    {
        double totalSum = SumOfArray(heights);
        return totalSum / heights.Length; // Use the length of the array
    }

    // Method to find the shortest height
    static double ShortestHeight(double[] heights)
    {
        double shortest = heights[0];
        foreach (double height in heights)
        {
            if (height < shortest)
                shortest = height;
        }
        return shortest;
    }

    // Method to find the tallest height
    static double TallestHeight(double[] heights)
    {
        double tallest = heights[0];
        foreach (double height in heights)
        {
            if (height > tallest)
                tallest = height;
        }
        return tallest;
    }
}
