using System;
using System.Reflection;

// Define the Todo attribute
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
class Todo : Attribute
{
    public string Task { get; }
    public string AssignedTo { get; }
    public string Priority { get; }

    public Todo(string task, string assignedTo, string priority = "Medium")
    {
        Task = task;
        AssignedTo = assignedTo;
        Priority = priority;
    }
}

class TaskManager
{
    // Apply the Todo attribute to methods
    [Todo("Login page", "Komal", "High")]
    public void Task1()
    {
        Console.WriteLine("Executing task 1...");
    }

    [Todo("Users data", "N", "Medium")]
    public void Task2()
    {
        Console.WriteLine("Executing task 2...");
    }

    [Todo("Refactor code", "K", "Low")]
    public void Task3()
    {
        Console.WriteLine("Executing task 3...");
    }
}

class Program
{
    static void Main()
    {
        TaskManager taskManager = new TaskManager();
        MethodInfo[] methods = typeof(TaskManager).GetMethods();

        foreach (MethodInfo method in methods)
        {
            // Retrieve the Todo attribute applied to the method
            var attribute = (Todo)Attribute.GetCustomAttribute(method, typeof(Todo));

            if (attribute != null)
            {
                // If the Todo attribute is found, print the task details
                Console.WriteLine($"Method: {method.Name}");
                Console.WriteLine($"Task: {attribute.Task}");
                Console.WriteLine($"Assigned To: {attribute.AssignedTo}");
                Console.WriteLine($"Priority: {attribute.Priority}");
                Console.WriteLine();
            }
        }
    }
}
