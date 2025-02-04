using System;

class MultiplicationTable
{
    static void Main(string[] args)
    {
       
        Console.WriteLine("Enter a number to generate its multiplication table:");
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }

       
        int[] multiplicationTable = new int[10];

        
        for (int i = 1; i <= 10; i++)
        {
            multiplicationTable[i - 1] = number * i;
        }

       
        Console.WriteLine($"\nMultiplication table for {number}:");
        for (int i = 0; i < multiplicationTable.Length; i++)
        {
            Console.WriteLine($"{number} * {i + 1} = {multiplicationTable[i]}");
        }
    }
}
