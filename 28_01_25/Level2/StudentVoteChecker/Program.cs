using System;

public class StudentVoteChecker
{
    // Method to check voting eligibility
    public bool CanStudentVote(int age)
    {
        if (age < 0)
        {
            Console.WriteLine("Age cannot be negative.");
            return false; // Invalid age
        }

        if (age >= 18)
        {
            return true; // Eligible to vote
        }
        else
        {
            return false; // Not eligible to vote
        }
    }

    public static void Main(string[] args)
    {
        int[] ages = new int[10];
        StudentVoteChecker checker = new StudentVoteChecker();

        Console.WriteLine("Enter the age of 10 students:");

        for (int i = 0; i < ages.Length; i++)
        {
            Console.Write($"Enter age for student {i + 1}: ");
            ages[i] = int.Parse(Console.ReadLine());

            // Check if the student can vote
            bool canVote = checker.CanStudentVote(ages[i]);

            // Display the result
            if (canVote)
            {
                Console.WriteLine($"Student {i + 1} is eligible to vote.");
            }
            else
            {
                Console.WriteLine($"Student {i + 1} is not eligible to vote.");
            }
        }
    }
}
