using System;
<<<<<<< HEAD
class MyProject{
static void Main(String[] Args){
Console.WriteLine("enter the kilometres");
float kilo=float.Parse(Console.ReadLine());
float miles=kilo*0.621371f;
Console.WriteLine($"{kilo} in miles: {miles}");
}
=======

class Total
{
	static void Main(string[]args)
	{
		double total=0.0;
		double userInput;
		Console.WriteLine("Enter the no. to sum (enter 0to stop)");
		while(true)
		{
			Console.WriteLine("Enter the number");
			userInput=Convert.ToDouble(Console.ReadLine());
			if(userInput==0){
				break;
				}
			total+=userInput;
			Console.WriteLine($"The total sum is: {total}");
	}
}
	
	
>>>>>>> origin/feature
}