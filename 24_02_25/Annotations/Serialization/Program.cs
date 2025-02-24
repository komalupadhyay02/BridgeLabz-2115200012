using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

// Step 1: Define the JsonField attribute to support both fields and properties
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
public class JsonFieldAttribute : Attribute
{
    public string Name { get; }

    // Constructor to initialize the custom JSON field name
    public JsonFieldAttribute(string name)
    {
        Name = name;
    }
}

class User
{
    // Step 2: Apply the JsonField attribute to properties with custom JSON names
    [JsonField("user_name")]
    public string Username { get; set; }

    [JsonField("user_age")]
    public int Age { get; set; }

    [JsonField("user_email")]
    public string Email { get; set; }

    // Constructor for easier object initialization
    public User(string username, int age, string email)
    {
        Username = username;
        Age = age;
        Email = email;
    }
}

class JsonSerializer
{
    // Step 3: Serialize an object to a JSON string using the JsonField attribute
    public static string Serialize(object obj)
    {
        StringBuilder jsonBuilder = new StringBuilder();
        jsonBuilder.Append("{");

        // Get all properties from the object's type
        PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

        List<string> jsonElements = new List<string>();

        foreach (var property in properties)
        {
            // Get the JsonField attribute applied to the property
            var jsonFieldAttr = (JsonFieldAttribute)Attribute.GetCustomAttribute(property, typeof(JsonFieldAttribute));

            if (jsonFieldAttr != null)
            {
                // Get the value of the property
                var fieldValue = property.GetValue(obj);
                string jsonElement = $"\"{jsonFieldAttr.Name}\": \"{fieldValue}\"";
                jsonElements.Add(jsonElement);
            }
        }

        // Join all JSON elements and construct the JSON string
        jsonBuilder.Append(string.Join(", ", jsonElements));
        jsonBuilder.Append("}");

        return jsonBuilder.ToString();
    }
}

class Program
{
    static void Main()
    {
        // Create a User object
        User user = new User("komal", 28, "komal@example.com");

        // Serialize the user object to a JSON string
        string json = JsonSerializer.Serialize(user);

        // Print the serialized JSON
        Console.WriteLine(json);
    }
}
