using System;

class RotationPointBinarySearch
{
    static void Main()
    {
        Console.WriteLine("Enter the size of the array:");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        Console.WriteLine("Enter the elements of the rotated sorted array:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int rotationPoint = FindRotationPoint(arr);
        Console.WriteLine($"The smallest element is at index: {rotationPoint}");
    }

    static int FindRotationPoint(int[] arr)
    {
        int low = 0, high = arr.Length - 1;

        while (low < high)
        {
            int mid = low + (high - low) / 2;

            // Check if mid is the rotation point
            if (arr[mid] > arr[high])
            {
                // Rotation point is in the right half
                low = mid + 1;
            }
            else
            {
                // Rotation point is in the left half or is mid
                high = mid;
            }
        }

        // Low and high will converge to the rotation point
        return low;
    }
}
