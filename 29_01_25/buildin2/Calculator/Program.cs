using System;
class Calculator{
	static void Main(string[] args){
		Console.WriteLine("Enter the first no.");
		double n1=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the second no.");
		double n2=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the operation you want to perform:\n a. Add\n b. Subtraction\n c. Multiplication\n d. Division");

		String choice=Console.ReadLine();
		choice=choice.ToLower();
		if(choice=="a")
			Console.WriteLine($"{n1} + {n2} is : {Add(n1, n2)}");
		if(choice=="b")
			Console.WriteLine($"{n1} - {n2} is : {Subtraction(n1, n2)}");
		if(choice=="c")
			Console.WriteLine($"{n1} * {n2} is : {Multiplication(n1, n2)}");
		if(choice=="d")
			Console.WriteLine($"{n1} / {n2} is : {Division(n1, n2)}");
	}
	static double Add(double a, double b){
		return a+b;
	}
	static double Subtraction(double a, double b){
		return a-b;
	}
	static double Multiplication(double a, double b){
		return a*b;
	}
	static double Division(double a, double b){
		return a/b;
	}
}