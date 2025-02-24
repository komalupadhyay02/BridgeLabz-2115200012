using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// Define the Inject Attribute
[AttributeUsage(AttributeTargets.Parameter)]
public class InjectAttribute : Attribute
{
}

// DI Container Implementation
public class DIContainer
{
    private readonly Dictionary<Type, Type> _serviceRegistrations = new Dictionary<Type, Type>();

    // Register a service with its implementation
    public void Register<TService, TImplementation>()
        where TImplementation : TService
    {
        _serviceRegistrations[typeof(TService)] = typeof(TImplementation);
    }

    // Resolve an instance of a service
    public object Resolve(Type serviceType)
    {
        // Check if the service type is registered
        if (_serviceRegistrations.ContainsKey(serviceType))
        {
            var implementationType = _serviceRegistrations[serviceType];
            return CreateInstance(implementationType);
        }

        throw new InvalidOperationException($"Service of type {serviceType.Name} not registered.");
    }

    // Create an instance of a class using reflection and inject dependencies
    private object CreateInstance(Type implementationType)
    {
        // Get the constructor of the class
        var constructor = implementationType.GetConstructors().First();

        // Get all the parameters of the constructor
        var parameters = constructor.GetParameters();

        // Prepare a list to hold the resolved arguments
        var parameterInstances = new List<object>();

        foreach (var parameter in parameters)
        {
            // Check if the parameter has the [Inject] attribute
            if (parameter.GetCustomAttribute<InjectAttribute>() != null)
            {
                // Resolve the dependency for this parameter
                var parameterInstance = Resolve(parameter.ParameterType);
                parameterInstances.Add(parameterInstance);
            }
            else
            {
                // If no [Inject] attribute, use default constructor (or create as needed)
                parameterInstances.Add(null); // Or handle default creation
            }
        }

        // Create an instance of the class and inject the dependencies
        return constructor.Invoke(parameterInstances.ToArray());
    }
}

// Example service interfaces and implementations

public interface IServiceA
{
    void Execute();
}

public class ServiceA : IServiceA
{
    public void Execute()
    {
        Console.WriteLine("ServiceA executed.");
    }
}

public interface IServiceB
{
    void Run();
}

public class ServiceB : IServiceB
{
    private readonly IServiceA _serviceA;

    // Constructor with injection
    public ServiceB([Inject] IServiceA serviceA)
    {
        _serviceA = serviceA;
    }

    public void Run()
    {
        Console.WriteLine("ServiceB running.");
        _serviceA.Execute();
    }
}

public class Client
{
    private readonly IServiceB _serviceB;

    // Constructor with injection
    public Client([Inject] IServiceB serviceB)
    {
        _serviceB = serviceB;
    }

    public void Start()
    {
        Console.WriteLine("Client starting...");
        _serviceB.Run();
    }
}

// Main Program to test DI
class Program
{
    static void Main()
    {
        // Create and set up DI container
        var container = new DIContainer();

        // Register services
        container.Register<IServiceA, ServiceA>();
        container.Register<IServiceB, ServiceB>();

        // Resolve the client (which depends on IServiceB)
        var client = (Client)container.Resolve(typeof(Client));

        // Start the client, which will invoke the DI system to resolve all dependencies
        client.Start();
    }
}
