using System;

class ThreeDigit
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of an array");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        
        Console.WriteLine("Enter the values in the array:");
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

       
        CheckNumbers(arr);
    }

    static void CheckNumbers(int[] arr)
    {
        foreach (int num in arr)
        {
            if (num > 99 && num < 1000) 
            {
                int firstDigit = num / 100; 
                int lastDigit = num % 10;  
                int middleDigit = GetMiddleDigit(num); 

                if (firstDigit + lastDigit == middleDigit)
                {
                    Console.WriteLine($"Number {num} has the sum of first and last digits equal to the middle digit.");
                }
            }
        }
    }

    static int GetMiddleDigit(int num)
    {
        
        return (num / 10) % 10;
    }
}
