using System;
using System.Reflection;

public class Configuration
{
    // Private static field
    private static string API_KEY = "Initial_API_KEY_Value";

    // Method to display the API_KEY value
    public static void DisplayAPIKey()
    {
        Console.WriteLine($"API Key: {API_KEY}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Display the initial API_KEY value using the method
        Console.WriteLine("Before using Reflection:");
        Configuration.DisplayAPIKey();
        
        // Use Reflection to access and modify the private static field API_KEY
        FieldInfo fieldInfo = typeof(Configuration).GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        if (fieldInfo != null)
        {
            // Modify the value of the private static field
            fieldInfo.SetValue(null, "New_API_KEY_Value");

            // Display the updated API_KEY value using the method
            Console.WriteLine("\nAfter using Reflection:");
            Configuration.DisplayAPIKey();
        }
        else
        {
            Console.WriteLine("Field 'API_KEY' not found.");
        }
    }
}
