using System;
using System.Reflection;

// Step 1: Define the BugReport attribute with AllowMultiple = true
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
public class BugReportAttribute : Attribute
{
    public string Description { get; }

    // Constructor to initialize the Description field
    public BugReportAttribute(string description)
    {
        Description = description;
    }
}

class TaskManager
{
    // Step 3: Apply the BugReport attribute twice on the same method
    [BugReport("Bug: Null reference exception in Task1.")]
    [BugReport("Bug: Performance issue when handling large data in Task1.")]
    public void Task1()
    {
        Console.WriteLine("Executing Task 1...");
    }
}

class Program
{
    static void Main()
    {
        // Step 4: Use Reflection to retrieve all BugReport attributes applied to Task1
        TaskManager task = new TaskManager();
        MethodInfo method = typeof(TaskManager).GetMethod("Task1");

        // Retrieve all BugReport attributes applied to Task1
        var attributes = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        // Print the descriptions of all BugReport attributes
        foreach (BugReportAttribute attribute in attributes)
        {
            Console.WriteLine($"Bug Report: {attribute.Description}");
        }
    }
}
