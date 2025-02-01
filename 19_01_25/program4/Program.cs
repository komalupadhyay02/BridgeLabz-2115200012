using System;
<<<<<<< HEAD
class CircleArea
{
static void Main(string[] args)
{
Console.Write("Enter the radius of the circle: ");
double radius = double.Parse(Console.ReadLine());
double area = Math.PI * Math.Pow(radius, 2);
Console.WriteLine($"The area of the circle with radius {radius} is: {area}");
}
=======
class NaturalNumber
{
	static void Main(string[] args)
	{
		Console.WriteLine("Enter the Number");
		int Number=int.Parse(Console.ReadLine());
		bool NaturalNumber=IsNaturalNumber(Number);
		int sum=SumOfNaturalNumber(Number);
		if(NaturalNumber){
			Console.WriteLine($"The sum of {Number} natural numbers is {sum}");
		}
		else{
			Console.WriteLine($"The number {Number} is not a natural number.");
		}
	}
	static bool IsNaturalNumber(int Number)
	{
		return Number>=1;	
	}
 	static int SumOfNaturalNumber(int n)
	{
		return n * (n+1) / 2;
	}
>>>>>>> origin/feature
}