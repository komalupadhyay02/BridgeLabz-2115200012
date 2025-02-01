using System;

class Square
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the perimeter of the square:");
        int perimeter = Convert.ToInt32(Console.ReadLine());

        // Calling the method to find the side and display the result
        Console.WriteLine($"The length of the side is {findSide(perimeter)} whose perimeter is {perimeter}");
    }

    // Method to find the side of the square using the perimeter
    static int findSide(int perimeter)
    {
        return perimeter / 4;
    }
}


