using System;

class FibonacciGenerator
{
    static void Main()
    {
        Console.Write("Enter the number of Fibonacci terms: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Fibonacci Series:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"{Fibonacci(i)} ");
        }
    }

    static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
