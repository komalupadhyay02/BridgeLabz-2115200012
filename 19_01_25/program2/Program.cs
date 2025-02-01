using System;
<<<<<<< HEAD
class AddTwoNumbers
{
static void Main(string[] args)
{
Console.Write("Enter the first number: ");
int num1 = int.Parse(Console.ReadLine());
Console.Write("Enter the second number: ");
int num2 = int.Parse(Console.ReadLine());
int sum = num1 + num2;
Console.WriteLine($"The sum of {num1} and {num2} is: {sum}");
}
=======
class Compare
{
	static void Main(String[] Args)
	{
		Console.WriteLine("Enter the value of a");
		int a=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the value of b");
		int b=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the value of c");
		int c=int.Parse(Console.ReadLine());
		String result=IsSmallest(a,b,c)?"Yes":"No";
		Console.WriteLine($" Is the first number the smallest?{result}");
	}
	static bool IsSmallest(int a, int b, int c)
	{
		return a < b && a < c;
	}
>>>>>>> origin/feature
}