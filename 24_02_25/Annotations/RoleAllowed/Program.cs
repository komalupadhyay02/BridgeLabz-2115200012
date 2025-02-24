using System;
using System.Reflection;

// Step 1: Define the RoleAllowed attribute
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class RoleAllowedAttribute : Attribute
{
    public string Role { get; }

    // Constructor to initialize the role
    public RoleAllowedAttribute(string role)
    {
        Role = role;
    }
}

class User
{
    public string Role { get; set; }
    
    public User(string role)
    {
        Role = role;
    }
}

class AdminPanel
{
    // Step 2: Apply RoleAllowed attribute to restrict method access based on roles
    [RoleAllowed("ADMIN")]
    public void AdminMethod()
    {
        Console.WriteLine("Executing Admin Method...");
    }

    [RoleAllowed("USER")]
    public void UserMethod()
    {
        Console.WriteLine("Executing User Method...");
    }

    // Method without RoleAllowed attribute (public access)
    public void PublicMethod()
    {
        Console.WriteLine("Executing Public Method...");
    }
}

class Program
{
    static void Main()
    {
        // Simulating a user with the role "USER"
        User currentUser = new User("USER");

        AdminPanel adminPanel = new AdminPanel();

        // Step 3: Use reflection to check roles before executing methods
        InvokeMethodIfAllowed(adminPanel, currentUser, "AdminMethod"); // Should print Access Denied
        InvokeMethodIfAllowed(adminPanel, currentUser, "UserMethod");  // Should allow
        InvokeMethodIfAllowed(adminPanel, currentUser, "PublicMethod"); // Should allow
    }

    static void InvokeMethodIfAllowed(AdminPanel adminPanel, User user, string methodName)
    {
        // Get method information using reflection
        MethodInfo method = typeof(AdminPanel).GetMethod(methodName);
        if (method != null)
        {
            // Check if the RoleAllowed attribute is applied
            var roleAllowedAttribute = (RoleAllowedAttribute)Attribute.GetCustomAttribute(method, typeof(RoleAllowedAttribute));

            if (roleAllowedAttribute != null)
            {
                // If the method is restricted, compare the current user's role with the allowed role
                if (roleAllowedAttribute.Role != user.Role)
                {
                    Console.WriteLine($"Access Denied! You need {roleAllowedAttribute.Role} role to access this method.");
                    return; // Deny access if roles do not match
                }
            }

            // If the user has the right role or if the method is not restricted, invoke the method
            method.Invoke(adminPanel, null);
        }
    }
}
