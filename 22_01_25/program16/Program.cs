using System;

class HandshakeCalculator
{
    static void Main(string[] args)
    {
        //the number of students
        Console.Write("Enter the number of students: ");
        int numberOfStudents = Convert.ToInt32(Console.ReadLine());

        // Calling the method to calculate and display the number of possible handshakes
        CalculateHandshakes(numberOfStudents);
    }

    // Method to calculate and display the number of handshakes
    static void CalculateHandshakes(int numberOfStudents)
    {
        // Calculate the maximum number of handshakes using the formula: (n * (n - 1)) / 2
        int handshakes = (numberOfStudents * (numberOfStudents - 1)) / 2;

        // Display the result
        Console.WriteLine($"The maximum number of handshakes among {numberOfStudents} students is {handshakes}");
    }
}