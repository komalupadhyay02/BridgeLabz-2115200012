using System;
using System.Reflection;

// Step 1: Define the MaxLength attribute with support for properties
[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class MaxLengthAttribute : Attribute
{
    public int MaxLength { get; }

    // Constructor to initialize the maximum length value
    public MaxLengthAttribute(int maxLength)
    {
        MaxLength = maxLength;
    }
}

class User
{
    // Step 2: Apply MaxLength attribute to the Username property
    [MaxLength(10)]
    public string Username { get; }

    // Constructor validates the length of the Username property
    public User(string username)
    {
        // Step 3: Validate property length based on MaxLength attribute
        var propertyInfo = typeof(User).GetProperty("Username");

        var maxLengthAttribute = (MaxLengthAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(MaxLengthAttribute));

        if (maxLengthAttribute != null && username.Length > maxLengthAttribute.MaxLength)
        {
            throw new ArgumentException($"Username cannot be longer than {maxLengthAttribute.MaxLength} characters.");
        }

        Username = username;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Creating a User object with a valid username
            User user1 = new User("ShortUser");
            Console.WriteLine($"User created: {user1.Username}");

            // Creating a User object with an invalid username that exceeds the max length
            User user2 = new User("ThisUsernameIsWayTooLong");
            Console.WriteLine($"User created: {user2.Username}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message); // Catch and print the validation error
        }
    }
}
