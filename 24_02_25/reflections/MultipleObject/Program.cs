using System;
using System.Reflection;

class MathsOperations
{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public int Division(int a, int b) => a / b;
}

class Program
{
    static void Main()
    {
        MathsOperations mathoperation = new MathsOperations();
        Console.WriteLine("Enter first number:");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Choose an operation to perform:\n 1. Addition\n 2. Subtraction\n 3. Multiplication\n 4. Division");
        int choice = Convert.ToInt32(Console.ReadLine());

        string operation = "";
        switch (choice)
        {
            case 1:
                operation = "Add";
                break;
            case 2:
                operation = "Subtract";
                break;
            case 3:
                operation = "Multiply";
                break;
            case 4:
                operation = "Division";
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        // Using Reflection to invoke method
        MethodInfo method = typeof(MathsOperations).GetMethod(operation, BindingFlags.Public | BindingFlags.Instance);
        if (method != null)
        {
            object result = method.Invoke(mathoperation, new object[] { a, b });
            Console.WriteLine($"Result of {operation} operation: {result}");
        }
        else
        {
            Console.WriteLine("Invalid operation entered.");
        }
    }
}
