using System;

class Program
{
    static void Main()
    {
	        Console.Write("Enter first date (yyyy-MM-dd): ");
		DateTime firstDate=Convert.ToDateTime(Console.ReadLine());
	Console.Write("Enter secondDate date (yyyy-MM-dd): ");

		DateTime secondDate=Convert.ToDateTime(Console.ReadLine());
        
            
                int result = DateTime.Compare(firstDate, secondDate);
                if (result < 0)
                    Console.WriteLine("The first date is before the second date.");
                else if (result > 0)
                    Console.WriteLine("The first date is after the second date.");
                else
                    Console.WriteLine("Both dates are the same.");
           }
}

        
        
      
        
