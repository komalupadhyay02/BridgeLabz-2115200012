using System;
using System.Collections.Generic;

class LinearAndBinarySearch
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

        Console.WriteLine("Enter the target number to search using Binary Search:");
        int target = Convert.ToInt32(Console.ReadLine());

        // Linear Search: Find the first missing positive integer
        int missingPositive = FindFirstMissingPositive(arr);
        Console.WriteLine($"The first missing positive integer is: {missingPositive}");

        // Binary Search: Find the index of the target number
        Array.Sort(arr); // Sort the array for Binary Search
        int targetIndex = BinarySearch(arr, target);
        if (targetIndex != -1)
        {
            Console.WriteLine($"The target number {target} is at index: {targetIndex}");
        }
        else
        {
            Console.WriteLine($"The target number {target} is not present in the array.");
        }
    }

    static int FindFirstMissingPositive(int[] arr)
    {
        int n = arr.Length;

        // Step 1: Mark values outside the range [1, n] as ignored
        for (int i = 0; i < n; i++)
        {
            if (arr[i] <= 0 || arr[i] > n)
            {
                arr[i] = n + 1;
            }
        }

        // Step 2: Mark each number in the range [1, n] as visited
        for (int i = 0; i < n; i++)
        {
            int num = Math.Abs(arr[i]);
            if (num <= n)
            {
                arr[num - 1] = -Math.Abs(arr[num - 1]); // Mark as visited
            }
        }

        // Step 3: Find the first index with a positive value
        for (int i = 0; i < n; i++)
        {
            if (arr[i] > 0)
            {
                return i + 1; // The missing positive integer
            }
        }

        return n + 1; // If all numbers from 1 to n are present
    }

    static int BinarySearch(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                return mid; // Target found
            }
            else if (arr[mid] < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1; // Target not found
    }
}
