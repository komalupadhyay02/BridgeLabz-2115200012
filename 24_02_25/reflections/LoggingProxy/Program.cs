using System;
using System.Reflection;

// Define the interface
public interface IGreeting
{
    void SayHello(string name);
}

// Implement the dynamic proxy class
public class LoggingProxy<T> : DispatchProxy
{
    private T _target;

    // Method to create the proxy and set the target object
    public static T Create(T target)
    {
        object proxy = Create<T, LoggingProxy<T>>();
        ((LoggingProxy<T>)proxy)._target = target;
        return (T)proxy;
    }

    // Intercept method calls on the proxy and log method name
    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        // Log the method name
        Console.WriteLine($"Method {targetMethod.Name} is being called.");

        // Call the actual method on the target object
        return targetMethod.Invoke(_target, args);
    }
}

// Implementation of the IGreeting interface
public class GreetingService : IGreeting
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a real object of IGreeting
        IGreeting greetingService = new GreetingService();

        // Create a proxy for IGreeting that logs method calls
        IGreeting proxy = LoggingProxy<IGreeting>.Create(greetingService);

        // Call the method on the proxy (logging will happen before actual execution)
        proxy.SayHello("Alice");
    }
}
