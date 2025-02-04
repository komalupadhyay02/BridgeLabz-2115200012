using System;
class UnitConverter{
	static void Main(string[]args){
		Console.WriteLine("Enter the temperature in celsius");
		double celcius=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the fehranheit");
		double fahrenheit=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the pounds");
		double pounds=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the kilograms");
		double kilograms=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the gallons");
		double gallons=Convert.ToDouble(Console.ReadLine());
		
		Console.WriteLine("Enter the later");
		double liter=Convert.ToDouble(Console.ReadLine());
		
		
		Console.WriteLine($"celcius{FahrenheitToCelsius(fahrenheit)}");
		Console.WriteLine($"fahrenheit{ConvertCelsiusToFahrenheit (celcius)}");
		Console.WriteLine($"{ConvertPoundsToKilograms(pounds)}");
		Console.WriteLine($"{ConvertKilogramsToPounds(kilograms )}");
		Console.WriteLine($"{ConvertGallonsToLiters(gallons)}");
		Console.WriteLine($"{ConvertLitersToGallons(liter)}");
	}
	//method to ConvertFahrenheitToCelsius
	
	public static double FahrenheitToCelsius(double fahrenheit){
		
			return (fahrenheit-32)*5/9;
		}
	public static double ConvertCelsiusToFahrenheit (double celcius){
		
			return (celcius*9/5)+32;
		}
	public static double ConvertPoundsToKilograms(double pounds){
	
			return pounds*0.453592;
		}
	public static double ConvertKilogramsToPounds(double kilograms ){
		
			return kilograms*2.20462;
		}
	public static double ConvertGallonsToLiters(double gallons){
		
			return gallons*3.78541;
}
public static double ConvertLitersToGallons(double liter){
		
			return liter*0.264172; ;
}
	
		
}