using System;
using System.Diagnostics;
using System.Reflection;

// Step 1: Define the LogExecutionTime attribute
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class LogExecutionTimeAttribute : Attribute
{
    // This attribute does not need any fields or properties, just serves as a marker for reflection
}

class TaskManager
{
    // Step 2: Apply LogExecutionTime to methods

    [LogExecutionTime]
    public void Task1()
    {
        Console.WriteLine("Executing Task 1...");
        // Simulate some work with a delay
        System.Threading.Thread.Sleep(1000);
    }

    [LogExecutionTime]
    public void Task2()
    {
        Console.WriteLine("Executing Task 2...");
        // Simulate some work with a delay
        System.Threading.Thread.Sleep(500);
    }

    [LogExecutionTime]
    public void Task3()
    {
        Console.WriteLine("Executing Task 3...");
        // Simulate some work with a delay
        System.Threading.Thread.Sleep(2000);
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
            // Retrieve the LogExecutionTime attribute applied to the method
            var attribute = (LogExecutionTimeAttribute)Attribute.GetCustomAttribute(method, typeof(LogExecutionTimeAttribute));

            if (attribute != null)
            {
                // If the LogExecutionTime attribute is found, measure execution time
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // Invoke the method dynamically
                method.Invoke(taskManager, null);

                stopwatch.Stop();
                Console.WriteLine($"Execution Time for {method.Name}: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine();
            }
        }
    }
}
