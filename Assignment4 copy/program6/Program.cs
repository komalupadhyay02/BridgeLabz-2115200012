using System;
class Check
{
	static void Main(string[]args)
	{
		//user Input
		Console.WriteLine("Enter the Number");
		int Number=int.Parse(Console.ReadLine());
		String result=CheckNumber(Number);
		Console.WriteLine($"The Number is {result}");
		
	}
	//method to check weather the no. is negative, positive or zero.
	static String CheckNumber(int Number)
	{
		if(Number>0){
			return ("Positive");
		}
		else if(Number<0){
			return ("Negative");
		}
		else{
			return ("Zero");
		}
	}
}