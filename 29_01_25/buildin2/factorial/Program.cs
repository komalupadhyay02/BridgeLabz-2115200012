using System;
class Factorial{
	static void Main(string[] args){
		Console.WriteLine("Enter the no.");
		int number=int.Parse(Console.ReadLine());
		Console.WriteLine($"The factorial of {number} is: {FindFactorial(number)}");
	}
	static int FindFactorial(int number){
		if(number==1)
			return 1;

		return number*FindFactorial(number-1);
	}
}