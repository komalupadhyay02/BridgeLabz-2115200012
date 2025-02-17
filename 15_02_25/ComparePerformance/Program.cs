using System;
using System.Text;
using System.Diagnostics;

class CompareStringBuilderPerformance
{
    static void Main()
    {
        
        int iterations = 100000;
        Console.WriteLine("Enter the string to concatenate:");
        string input = Console.ReadLine();

        // Measure performance with regular string concatenation
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        string resultString = "";
        for (int i = 0; i < iterations; i++)
        {
            resultString += input; // Regular string concatenation
        }
        stopwatch.Stop();
        Console.WriteLine($"String concatenation time: {stopwatch.ElapsedMilliseconds} ms");

        // Measure performance with StringBuilder
        stopwatch.Restart();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            sb.Append(input); // StringBuilder concatenation
        }
        stopwatch.Stop();
        Console.WriteLine($"StringBuilder concatenation time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
