using System;
class SimpleInterest
{
	static void Main(String[]args)
	{
		Console.WriteLine("Enter the principle amount");
		double principle=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the Rate amount");
		double Rate=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the Time amount");
		double Time=Convert.ToDouble(Console.ReadLine());
		double SI=simpleInterest(principle,Rate,Time);
		Console.WriteLine($"The Simple Interest is{SI}for Principal {principle}, Rate of Interest {Rate} and Time {Time}");

	}
	static double simpleInterest(double principle, double Time, double Rate)
	{
		return (principle*Time*Rate)/100;
	}
}