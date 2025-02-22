using System;

// Custom exception class
class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
    }
}

class Program
{
    // Method to validate age
    static void ValidateAge(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Age must be 18 or above.");
        }
    }

    static void Main(string[] args)
    {
        try
        {
            // Take user input for age
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Validate the age
            ValidateAge(age);

            // If no exception, access is granted
            Console.WriteLine("Access granted!");
        }
        catch (InvalidAgeException ex)
        {
            // Handle custom exception
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            // Handle invalid input
            Console.WriteLine("Invalid input. Please enter a numeric value for age.");
        }
        catch (Exception ex)
        {
            // Handle other unexpected exceptions
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
