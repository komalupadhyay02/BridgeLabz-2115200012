using System;
class Chocolate{
	static void Main(String[]args){
		Console.WriteLine("Enter the no. of chocolate");
		int NumberOfChocolate=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the no. of children");
		int NumberOfChildren=int.Parse(Console.ReadLine());
		int TotalChocolate=ChocolateCalculate(NumberOfChildren,NumberOfChocolate);
		int remainingChocolate=NumberOfChocolate%NumberOfChildren;
		Console.WriteLine($"No.of chocolate on each children: {TotalChocolate} and remaining:{remainingChocolate}");
		
	}
	static int ChocolateCalculate(int NumberOfChildren, int NumberOfChocolate){
		return NumberOfChocolate/NumberOfChildren;
		
	}
}