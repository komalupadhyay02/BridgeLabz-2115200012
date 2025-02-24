using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;

public class MethodExecutionTimer
{
    // Method to measure the execution time of each method in a given class dynamically
    public static void MeasureMethodExecutionTime(Type targetType)
    {
        // Get all methods in the target class (including non-public)
        var methods = targetType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var method in methods)
        {
            // Skip static methods, we'll focus on instance methods
            if (method.IsStatic)
                continue;

            // Display method name
            Console.WriteLine($"Measuring execution time for method: {method.Name}");

            // Create an instance of the target class (using the parameterless constructor)
            var instance = Activator.CreateInstance(targetType);

            // Start the stopwatch to measure execution time
            var stopwatch = Stopwatch.StartNew();

            try
            {
                // Invoke the method dynamically without parameters (if any)
                method.Invoke(instance, null);
            }
            catch (Exception ex)
            {
                // Catch any exceptions that might occur during method invocation
                Console.WriteLine($"Error executing method {method.Name}: {ex.Message}");
            }
            finally
            {
                // Stop the stopwatch after method execution
                stopwatch.Stop();
                Console.WriteLine($"Execution time for {method.Name}: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
    }
}

// Example Class to demonstrate method timing
public class SampleClass
{
    public void Method1()
    {
        // Simulate some work
        System.Threading.Thread.Sleep(100);
        Console.WriteLine("Method1 executed.");
    }

    public void Method2()
    {
        // Simulate more work
        System.Threading.Thread.Sleep(200);
        Console.WriteLine("Method2 executed.");
    }

    private void Method3()
    {
        // Simulate even more work
        System.Threading.Thread.Sleep(50);
        Console.WriteLine("Private Method3 executed.");
    }
}

// Main Program to demonstrate the functionality
class Program
{
    static void Main(string[] args)
    {
        // Call the MethodExecutionTimer to measure execution times for methods in SampleClass
        MethodExecutionTimer.MeasureMethodExecutionTime(typeof(SampleClass));
    }
}
