using System;

class NestedTryCatchExample
{
    static void Main(string[] args)
    {
        try
        {
            // Input: Array elements
            Console.WriteLine("Enter the size of  the array:");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];

            Console.WriteLine("Enter the array elements:");
            for (int i = 0; i < size; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            // Input: Index and divisor
            Console.WriteLine("Enter the index of the element to access:");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the divisor:");
            int divisor = Convert.ToInt32(Console.ReadLine());

            try
            {
                // Access the array element
                int element = array[index];
                Console.WriteLine($"Element at index {index}: {element}");

                try
                {
                    // Perform division
                    int result = element / divisor;
                    Console.WriteLine($"Result of division: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Cannot divide by zero!");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid array index!");
            }
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
