using System;

class MultipleException
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the range of array:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];

            Console.WriteLine("Enter the values:");
            for (int i = 0; i < n; i++) // Correct loop condition
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Enter the index you want to retrieve:");
            int index = Convert.ToInt32(Console.ReadLine());

            // Fixed the array name to match the declaration
            Console.WriteLine($"Value at index {index}: {arr[index]}");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid index!");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Array is not initialized!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter numeric values.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
