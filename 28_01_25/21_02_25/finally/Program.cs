using System;

class DivisionErrorHandler
{
    static void Main(string[] args)
    {
        try
        {
   
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

      
            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

          
            double result = num1 / num2;

            // Display result
            Console.WriteLine($"Result: {num1} / {num2} = {result}");
        }
       catch (DivideByZeroException e)
        {
            Console.WriteLine("DivideByZeroException caught: " + e.Message);
        }

        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter numeric values only.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
        finally{
            Console.WriteLine("Operation Completed!");
        }
    }
}
