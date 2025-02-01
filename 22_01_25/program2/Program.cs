using System;

class Program
{
    static void Main(string[] args)
    {
        // Marks in each subject
        int maths = 94;
        int physics = 95;
        int chemistry = 96;

        // Call the method to calculate average
        double average = CalculateAverage(maths, physics, chemistry);

        // Output the result
        Console.WriteLine($"Sam's average mark in PCM is {average}%");
    }

    // Method to calculate average marks
    static double CalculateAverage(int maths, int physics, int chemistry)
    {
        int totalSubjects = 3;
        int totalMarks = maths + physics + chemistry;
        return (double)totalMarks / totalSubjects;
    }
}

