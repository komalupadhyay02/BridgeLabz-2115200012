using System;
<<<<<<< HEAD
class MyProject{
static void Main(String[] Args){ Console.WriteLine("enter the first no.
");
int a=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter the second no.
");
int b=Convert.ToInt32(Console.ReadLine());
Console.WriteLine("enter the third no.
");
int c=Convert.ToInt32(Console.ReadLine());
int avg=(a+b+c)/3;
Console.WriteLine($"the average of three numbers is: {avg}”);
}
}
=======

class Counter
{
    static void Main(string[] args)
    {
        // User Input
        Console.WriteLine("Enter the Number:");
        int counter = int.Parse(Console.ReadLine());

        // Call the CountDown method
        CountDown(counter);
    }

    // Method for countdown
    static void CountDown(int counter)
    {
        
        for (int i = counter; i > 0; i--) // Loop to count down
        {
            Console.WriteLine(i); 
        }

       
        Console.WriteLine("Launch");
    }
}
>>>>>>> origin/feature
