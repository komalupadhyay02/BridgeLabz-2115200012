using System;

class Fibonacci
{
    static void Main()
    {
        Console.Write("Enter the number of Fibonacci terms: ");
        int n = int.Parse(Console.ReadLine());

      
        Console.WriteLine($"Last Fibonacci number: {GenerateFibonacci(n-1)}");
    }

    static int GenerateFibonacci(int n)
    {
        if (n <= 1)
            return n;
        return GenerateFibonacci(n - 1) + GenerateFibonacci(n - 2);
    }
}
