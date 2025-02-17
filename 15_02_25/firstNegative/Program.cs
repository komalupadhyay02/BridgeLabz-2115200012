using System;

class LinearSearchFirstNegative
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the array:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int firstNegative = FindFirstNegative(arr);
        if (firstNegative != int.MaxValue)
        {
            Console.WriteLine($"The first negative number in the array is: {firstNegative}");
        }
        else
        {
            Console.WriteLine("No negative numbers found in the array.");
        }
    }

    static int FindFirstNegative(int[] arr)
    {
        foreach (int num in arr)
        {
            if (num < 0)
            {
                return num; // Return the first negative number found
            }
        }
        return int.MaxValue; // Return a sentinel value if no negative number is found
    }
}
