using System;

class GCDLCMCalculator
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        int num2 = int.Parse(Console.ReadLine());

        int gcd = CalculateGCD(num1, num2);
        int lcm = CalculateLCM(num1, num2, gcd);

        Console.WriteLine($"GCD of {num1} and {num2} is: {gcd}");
        Console.WriteLine($"LCM of {num1} and {num2} is: {lcm}");
    }

    static int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static int CalculateLCM(int a, int b, int gcd)
    {
        return (a / gcd) * b;
    }
}
