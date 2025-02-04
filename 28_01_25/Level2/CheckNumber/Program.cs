using System;

class CheckNumber
{
    static void Main(string[] args)
    {
        int[] number = new int[5];
        Console.WriteLine("Enter 5 numbers:");

        for (int i = 0; i < 5; i++)
        {
            number[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < 5; i++)
        {
            string positive = PositiveNegative(number[i]);
            string even = EvenOdd(number[i]);
            Console.WriteLine($"Number {number[i]} is {positive} and {even}");
        }
	Console.WriteLine($"The first and last no. of array is:{Compare(number[0],number[4])}");
    }

    static string PositiveNegative(int number)
    {
        if (number > 0)
            return "Positive";
        else
            return "Negative";
    }

    static string EvenOdd(int number)
    {
        if (number % 2 == 0)
            return "Even";
        else
            return "Odd";
    }

    static int Compare(int n1, int n2)
    {
        if (n1 > n2)
            return 1;
        if (n1 < n2)
            return -1;
        else
            return 0;
    }
}
