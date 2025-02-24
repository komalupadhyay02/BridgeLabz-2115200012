using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class JsonConverter
{
    // Method to convert an object to a JSON-like string using Reflection
    public static string ToJson(object obj)
    {
        // Use a StringBuilder to build the JSON-like string
        StringBuilder jsonString = new StringBuilder();

        // Begin the JSON object
        jsonString.Append("{");

        // Get all fields of the object, including private ones
        FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        // Loop through all the fields to build the JSON string
        foreach (var field in fields)
        {
            // Get the field's value
            object value = field.GetValue(obj);

            // Append the field name and value in JSON format
            jsonString.Append($"\"{field.Name}\": \"{value}\", ");
        }

        // Remove the last comma and space
        if (jsonString.Length > 1)
        {
            jsonString.Length -= 2; // Remove the trailing comma and space
        }

        // End the JSON object
        jsonString.Append("}");

        return jsonString.ToString();
    }
}

public class Person
{
    // Fields in the Person class
    public string Name;
    public int Age;
    private string Address;

    // Constructor
    public Person(string name, int age, string address)
    {
        Name = name;
        Age = age;
        Address = address;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a new Person object
        Person person = new Person("John Doe", 30, "123 Main Street");

        // Convert the Person object to a JSON-like string
        string jsonString = JsonConverter.ToJson(person);

        // Print the JSON-like string
        Console.WriteLine(jsonString);
    }
}
