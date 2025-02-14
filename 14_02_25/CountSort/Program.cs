using System;

class CountSort
{
    static void Sort(int[] arr, int n)
    {
        int k = arr[0];
        for (int i = 1; i < n; i++)
        {
            k = Math.Max(k, arr[i]);
        }

        int[] count = new int[k + 1];
        for (int i = 0; i < n; i++)
        {
            count[arr[i]]++;
        }

        for (int i = 1; i <= k; i++)
        {
            count[i] += count[i - 1];
        }

        int[] output = new int[n];
        for (int i = n - 1; i >= 0; i--)
        {
            output[--count[arr[i]]] = arr[i];
        }

        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the length of the array:");
        int n;
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out n) && n > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer:");
        }

        int[] arr = new int[n];
        Console.WriteLine("Enter the prices of the books:");
        for (int i = 0; i < n; i++)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out arr[i]) && arr[i] >= 0)
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a non-negative integer:");
            }
        }

        Sort(arr, n);
        Console.WriteLine("Sorted prices: " + string.Join(", ", arr));
    }
}
