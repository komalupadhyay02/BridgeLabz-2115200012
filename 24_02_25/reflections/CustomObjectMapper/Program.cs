using System;
using System.Collections.Generic;
using System.Reflection;

public class CustomObjectMapper
{
    // The ToObject method that maps properties from a dictionary to an object of type T
    public static T ToObject<T>(Dictionary<string, object> properties) where T : new()
    {
        // Create an instance of the target type T
        T obj = new T();

        // Get all fields of the type T
        FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        foreach (var field in fields)
        {
            // Check if the dictionary contains a key matching the field name
            if (properties.ContainsKey(field.Name))
            {
                // Get the value from the dictionary and set it to the field
                field.SetValue(obj, properties[field.Name]);
            }
        }

        return obj;
    }
}

public class Person
{
    // Some fields in the Person class
    public string Name;
    public int Age;
    private string Address;

    // Method to display the values of the fields
    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Address: {Address}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Dictionary with properties to map
        var properties = new Dictionary<string, object>
        {
            { "Name", "John Doe" },
            { "Age", 30 },
            { "Address", "123 Main Street" }
        };

        // Use the ToObject method to map properties to a Person object
        Person person = CustomObjectMapper.ToObject<Person>(properties);

        // Display the mapped object values
        person.Display();
    }
}
