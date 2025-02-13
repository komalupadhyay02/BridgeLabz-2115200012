using System;

class Program
{
    static void Main()
    {
        int[] arr = { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
        int n = 3; 

        int nthLargest = FindNthLargest(arr, n);
        Console.WriteLine($"{n}rd largest element is {nthLargest}");
    }

    static int FindNthLargest(int[] arr, int n)
    {
        int size = arr.Length;

        for (int i = 0; i < n; i++) 
        {
            int maxIndex = i;
            for (int j = i + 1; j < size; j++) 
            {
                if (arr[j] > arr[maxIndex])
                {
                    maxIndex = j;
                }
            }

          
            int temp = arr[i];
            arr[i] = arr[maxIndex];
            arr[maxIndex] = temp;
        }

        return arr[n - 1]; 
    }
}
