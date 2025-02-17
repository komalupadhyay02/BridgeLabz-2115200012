using System;
using System.Diagnostics;

class SortingComparison
{
    static void Main()
    {
        int[] datasetSizes = { 1000, 10000, 100000 };

        foreach (int n in datasetSizes)
        {
            Console.WriteLine($"\nDataset Size: {n}");

            // Generate random data
            int[] data = GenerateRandomArray(n);

            // Bubble Sort
            int[] bubbleData = (int[])data.Clone();
            Stopwatch stopwatch = Stopwatch.StartNew();
            BubbleSort(bubbleData);
            stopwatch.Stop();
            Console.WriteLine($"Bubble Sort: {stopwatch.Elapsed.TotalMilliseconds} ms");

            // Merge Sort
            int[] mergeData = (int[])data.Clone();
            stopwatch.Restart();
            MergeSort(mergeData, 0, mergeData.Length - 1);
            stopwatch.Stop();
            Console.WriteLine($"Merge Sort: {stopwatch.Elapsed.TotalMilliseconds} ms");

            // Quick Sort
            int[] quickData = (int[])data.Clone();
            stopwatch.Restart();
            QuickSort(quickData, 0, quickData.Length - 1);
            stopwatch.Stop();
            Console.WriteLine($"Quick Sort: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }

    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] data = new int[size];
        for (int i = 0; i < size; i++)
        {
            data[i] = random.Next(1, 1000000); // Random integers between 1 and 1,000,000
        }
        return data;
    }

    static void BubbleSort(int[] data)
    {
        int n = data.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    // Swap data[j] and data[j + 1]
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                }
            }
        }
    }

    static void MergeSort(int[] data, int left, int right)
    {
        if (left < right)
        {
            int mid = left + (right - left) / 2;

            // Recursively sort both halves
            MergeSort(data, left, mid);
            MergeSort(data, mid + 1, right);

            // Merge the sorted halves
            Merge(data, left, mid, right);
        }
    }

    static void Merge(int[] data, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        int[] leftArray = new int[n1];
        int[] rightArray = new int[n2];

        for (int i = 0; i < n1; i++)
            leftArray[i] = data[left + i];
        for (int j = 0; j < n2; j++)
            rightArray[j] = data[mid + 1 + j];

        int k = left, i1 = 0, j1 = 0;
        while (i1 < n1 && j1 < n2)
        {
            if (leftArray[i1] <= rightArray[j1])
                data[k++] = leftArray[i1++];
            else
                data[k++] = rightArray[j1++];
        }

        while (i1 < n1)
            data[k++] = leftArray[i1++];
        while (j1 < n2)
            data[k++] = rightArray[j1++];
    }

    static void QuickSort(int[] data, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(data, low, high);

            // Recursively sort elements before and after partition
            QuickSort(data, low, pi - 1);
            QuickSort(data, pi + 1, high);
        }
    }

    static int Partition(int[] data, int low, int high)
    {
        int pivot = data[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (data[j] <= pivot)
            {
                i++;
                // Swap data[i] and data[j]
                int temp = data[i];
                data[i] = data[j];
                data[j] = temp;
            }
        }

        // Swap data[i + 1] and pivot
        int temp1 = data[i + 1];
        data[i + 1] = data[high];
        data[high] = temp1;

        return i + 1;
    }
}
