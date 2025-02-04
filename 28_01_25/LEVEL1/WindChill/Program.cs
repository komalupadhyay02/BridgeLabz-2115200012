using System;
class Wind
{
	static void Main(String[]args){
		Console.WriteLine("Enter the temp");
		double temperature=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the WindSpeed");
		double windSpeed=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine($"the windChill is:{CalculateWindChill(temperature, windSpeed)}");
	}
	static double CalculateWindChill(double temperature, double windSpeed){
	double windChill = 35.74 + 0.6215 *temperature + (0.4275*temperature - 35.75) *  Math.Pow(windSpeed, 0.16);
	return windChill;
}

}
