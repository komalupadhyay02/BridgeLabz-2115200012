using System;
class Max{
	static void Main(string[] args){
		Console.WriteLine("Enter the first no.");
		int a=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the second no.");
		int b=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the third no.");
		int c=int.Parse(Console.ReadLine());
		int max=MaxThree(a, b, c);
		Console.WriteLine($"the Max of three is:{max}");
	}
	static int MaxThree(int a, int b, int c){
		return Math.Max(a,Math.Max(b,c));

	}
}
