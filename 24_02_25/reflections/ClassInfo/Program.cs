using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        // Step 1: Accept class name as input
        Console.Write("Enter the class name: ");
        string className = Console.ReadLine();

        try
        {
            // Step 2: Use Reflection to load the class by its name
            Type type = Type.GetType(className);

            // Check if the class exists
            if (type == null)
            {
                Console.WriteLine("Class not found.");
                return;
            }

            // Step 3: Display class information

            // Display class name
            Console.WriteLine($"Class Name: {type.FullName}");

            // Display methods of the class
            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"- {method.Name}");
            }

            // Display fields of the class
            Console.WriteLine("\nFields:");
            FieldInfo[] fields = type.GetFields();
            foreach (var field in fields)
            {
                Console.WriteLine($"- {field.Name}");
            }

            // Display constructors of the class
            Console.WriteLine("\nConstructors:");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (var constructor in constructors)
            {
                Console.WriteLine($"- {constructor.Name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
