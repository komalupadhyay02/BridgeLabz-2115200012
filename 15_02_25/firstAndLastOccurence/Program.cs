using System;

class FirstAndLastOccurrence
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the array:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the sorted array:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("Enter the target element:");
        int target = Convert.ToInt32(Console.ReadLine());

        int first = FindFirstOccurrence(arr, target);
        int last = FindLastOccurrence(arr, target);

        if (first != -1)
        {
            Console.WriteLine($"The first occurrence of {target} is at index: {first}");
            Console.WriteLine($"The last occurrence of {target} is at index: {last}");
        }
        else
        {
            Console.WriteLine($"The element {target} is not present in the array.");
        }
    }

    static int FindFirstOccurrence(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1, result = -1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                result = mid; // Potential first occurrence
                high = mid - 1; // Look for earlier occurrences in the left half
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

        return result;
    }

    static int FindLastOccurrence(int[] arr, int target)
    {
        int low = 0, high = arr.Length - 1, result = -1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                result = mid; // Potential last occurrence
                low = mid + 1; // Look for later occurrences in the right half
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

        return result;
    }
}
