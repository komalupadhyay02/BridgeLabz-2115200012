using System;

class BinarySearchExample
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

        Console.WriteLine("Enter the target number to search:");
        int target = Convert.ToInt32(Console.ReadLine());

        Array.Sort(arr); // Sort the array for Binary Search
        Console.WriteLine("Sorted Array: " + string.Join(", ", arr));

        int index = BinarySearch(arr, target);

        if (index != -1)
        {
            Console.WriteLine($"The target number {target} is at index: {index}");
        }
        else
        {
            Console.WriteLine($"The target number {target} is not present in the array.");
        }
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
                low = mid + 1; // Search in the right half
            }
            else
            {
                high = mid - 1; // Search in the left half
            }
        }

        return -1; // Target not found
    }
}
