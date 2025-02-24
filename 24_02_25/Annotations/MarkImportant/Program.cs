using System;
using System.Reflection;

// Step 1: Define the ImportantMethod attribute with an optional Level parameter
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class ImportantMethodAttribute : Attribute
{
    // Property to hold the level of importance
    public string Level { get; }

    // Constructor with an optional parameter (defaults to "HIGH")
    public ImportantMethodAttribute(string level = "HIGH")
    {
        Level = level;
    }
}

class TaskManager
{
    // Step 2: Apply the ImportantMethod attribute to methods
    [ImportantMethod("HIGH")]
    public void Task1()
    {
        Console.WriteLine("Executing Task 1...");
    }

    [ImportantMethod("LOW")]
    public void Task2()
    {
        Console.WriteLine("Executing Task 2...");
    }

    [ImportantMethod]
    public void Task3()
    {
        Console.WriteLine("Executing Task 3...");
    }
}

class Program
{
    static void Main()
    {
        // Step 3: Use Reflection to retrieve methods with the ImportantMethod attribute
        TaskManager taskManager = new TaskManager();
        MethodInfo[] methods = typeof(TaskManager).GetMethods();

        foreach (MethodInfo method in methods)
        {
            // Retrieve the ImportantMethod attribute applied to each method
            var attribute = (ImportantMethodAttribute)Attribute.GetCustomAttribute(method, typeof(ImportantMethodAttribute));

            if (attribute != null)
            {
                // If the attribute is found, print the method's name and its importance level
                Console.WriteLine($"Method: {method.Name}");
                Console.WriteLine($"Importance Level: {attribute.Level}");
                Console.WriteLine();
            }
        }
    }
}
