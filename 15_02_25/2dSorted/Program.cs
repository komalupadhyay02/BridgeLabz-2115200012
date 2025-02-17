using System;

class SearchIn2DMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows:");
        int rows = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the number of columns:");
        int cols = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Enter the elements of the matrix row by row:");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("Enter the target value to search for:");
        int target = Convert.ToInt32(Console.ReadLine());

        bool found = SearchMatrix(matrix, target);
        if (found)
        {
            Console.WriteLine("Target value found in the matrix.");
        }
        else
        {
            Console.WriteLine("Target value not found in the matrix.");
        }
    }

    static bool SearchMatrix(int[,] matrix, int target)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int low = 0, high = rows * cols - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int midValue = matrix[mid / cols, mid % cols]; // Convert 1D index to 2D

            if (midValue == target)
            {
                return true; // Target found
            }
            else if (midValue < target)
            {
                low = mid + 1; // Search in the right half
            }
            else
            {
                high = mid - 1; // Search in the left half
            }
        }

        return false; // Target not found
    }
}
