using System;
<<<<<<< HEAD
class MyProject{
static void Main(String[] Args){ Console.WriteLine("enter the principle amount");
double principle=Convert.ToDouble(Console.ReadLine());
Console.WriteLine("enter the Rate");
double rate=Convert.ToDouble(Console.ReadLine());
Console.WriteLine("enter the Time");
double Time=Convert.ToDouble(Console.ReadLine());
double SI=(principle*rate*Time)/100;
Console.WriteLine($"the Simple Interest is: {SI}”);
}
=======
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
>>>>>>> origin/feature
}