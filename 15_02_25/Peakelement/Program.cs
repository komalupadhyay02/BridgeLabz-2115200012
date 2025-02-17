using System;

class PeakElementBinarySearch
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

        int peakIndex = FindPeakElement(arr);
        Console.WriteLine($"A peak element is at index: {peakIndex}, value: {arr[peakIndex]}");
    }

    static int FindPeakElement(int[] arr)
    {
        int low = 0, high = arr.Length - 1;

        while (low < high)
        {
            int mid = low + (high - low) / 2;

            if (arr[mid] > arr[mid + 1])
            {
                // Peak is in the left half (including mid)
                high = mid;
            }
            else
            {
                // Peak is in the right half
                low = mid + 1;
            }
        }

        // Low and high converge to the peak element
        return low;
    }
}
