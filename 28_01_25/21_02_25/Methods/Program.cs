using System;

class ExceptionPropagation
{
    static void Method1()
    {
        Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

      
            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

          
            double result = num1 / num2;
            Console.WriteLine($"Result: {num1} / {num2} = {result}");
        
    }

    static void Method2()
    {
        // Calls Method1
        Method1();
    }

    static void Main(string[] args)
    {
        try
        {
            // Calls Method2, which indirectly calls Method1
            Method2();
        }
        catch (ArithmeticException ex)
        {
            // Handles the exception in Main and displays the custom message
            Console.WriteLine($"Handled exception in Main: {ex.Message}");
        }
        finally
        {
            // Ensures this block executes no matter what
            Console.WriteLine("done");
        }
    }
}
