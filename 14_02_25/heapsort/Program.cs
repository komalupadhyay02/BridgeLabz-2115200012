using System;

public class HeapSort
{
    // Function to perform heap sort
    public static void Sort(int[] arr)
    {
        int n = arr.Length;

        // Build a max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(arr, n, i);
        }

        // Extract elements one by one from the heap
        for (int i = n - 1; i > 0; i--)
        {
            // Swap the root (maximum element) with the last element
            Swap(arr, 0, i);

            // Call heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }

    // Function to maintain the heap property (max heapify)
    private static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;  // Initialize largest as root
        int left = 2 * i + 1;  // Left child
        int right = 2 * i + 2; // Right child

        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
        {
            largest = left;
        }

        // If right child is larger than largest so far
        if (right < n && arr[right] > arr[largest])
        {
            largest = right;
        }

        // If largest is not root
        if (largest != i)
        {
            Swap(arr, i, largest);

            // Recursively heapify the affected subtree
            Heapify(arr, n, largest);
        }
    }

    // Function to swap two elements in the array
    private static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}

public class Program
{
    public static void Main()
    {
        // Example array of job applicants' salary demands
        int[] salaries = { 50000, 70000, 60000, 45000, 80000, 55000 };

        Console.WriteLine("Before sorting:");
        Console.WriteLine(string.Join(", ", salaries));

        // Perform Heap Sort
        HeapSort.Sort(salaries);

        Console.WriteLine("\nAfter sorting:");
        Console.WriteLine(string.Join(", ", salaries));
    }
}
