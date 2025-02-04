using System;
class Largest
{
	static void Main(String[] args)
	{
		Console.WriteLine("Enter the value of a");
		int a=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the value of b");
		int b=int.Parse(Console.ReadLine());
		Console.WriteLine("Enter the value of c");
		int c=int.Parse(Console.ReadLine());
		String IsFirstLargest=IsLargest(a,b,c)?"Yes":"No";
		String IsSecondLargest=IsLargest(b,a,c)?"Yes":"No";
		String IsThirdLargest=IsLargest(c,a,b)?"Yes":"No";
		Console.WriteLine($"Is the first number the largest? {IsFirstLargest}");
		Console.WriteLine($"Is the Second number the largest? {IsSecondLargest}");
		Console.WriteLine($"Is the Third number the largest? {IsThirdLargest}");


	}
	static bool IsLargest(int a, int b, int c)
	{
		return a>b && a>c;
	}
}