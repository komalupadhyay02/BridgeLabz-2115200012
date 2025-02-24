using System;
using System.Collections.Generic;
using System.Reflection;

// Step 1: Define the CacheResult attribute
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public class CacheResultAttribute : Attribute
{
    // This attribute doesn't need properties for now
}

// Step 2: Create a custom caching mechanism
class CacheSystem
{
    private static readonly Dictionary<string, object> cache = new Dictionary<string, object>();

    // Method to check and return from the cache
    public static object GetCachedResult(string key)
    {
        if (cache.ContainsKey(key))
        {
            Console.WriteLine("Returning from cache...");
            return cache[key];
        }
        return null;
    }

    // Method to store the result in cache
    public static void StoreInCache(string key, object result)
    {
        cache[key] = result;
    }

    // Generate a unique key for method parameters to use in the cache
    public static string GenerateCacheKey(object[] parameters)
    {
        return string.Join("_", parameters);
    }
}

// Step 3: Define a class with a computationally expensive method
class ExpensiveComputation
{
    // Apply CacheResult attribute to the method to enable caching
    [CacheResult]
    public int ComputeExpensiveOperation(int num)
    {
        // Step 4: Handle caching within the method
        var cacheKey = CacheSystem.GenerateCacheKey(new object[] { num });
        var cachedResult = CacheSystem.GetCachedResult(cacheKey);

        if (cachedResult != null)
        {
            return (int)cachedResult;
        }

        // Simulate a time-consuming computation (e.g., a heavy mathematical operation)
        Console.WriteLine("Performing expensive computation...");
        int result = num * num; // Example: square of the number

        // Store the result in cache
        CacheSystem.StoreInCache(cacheKey, result);
        
        return result;
    }
}

class Program
{
    static void Main()
    {
        var computation = new ExpensiveComputation();

        // First call with number 5 (will compute and store in cache)
        Console.WriteLine($"Result: {computation.ComputeExpensiveOperation(5)}");

        // Second call with number 5 (will return from cache)
        Console.WriteLine($"Result: {computation.ComputeExpensiveOperation(5)}");

        // Call with a different number 10 (will compute and store in cache)
        Console.WriteLine($"Result: {computation.ComputeExpensiveOperation(10)}");

        // Call with number 5 again (will return from cache)
        Console.WriteLine($"Result: {computation.ComputeExpensiveOperation(5)}");
    }
}
