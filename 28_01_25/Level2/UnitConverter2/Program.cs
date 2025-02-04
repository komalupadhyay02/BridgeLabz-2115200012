using System;
class UnitConverter{
	static void Main(string[]args){
		Console.WriteLine("Enter the km");
		double km=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the miles");
		double miles=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the meter");
		double meter=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the feet");
		double feet=Convert.ToDouble(Console.ReadLine());
		
		Console.WriteLine($"km{km} : {ConvertKmToMiles(km)} miles");
		Console.WriteLine($"miles{miles} : {ConvertMilesToKm(miles)} km");
		Console.WriteLine($"meter{meter} : {ConvertMeterToFeet(meter)} feet");
		Console.WriteLine($"feet{feet} : {ConvertFeetToMeter(feet)} meter");
	}
	//method to convert km to mile
	
	public static double ConvertKmToMiles(double km){
		
			return km*0.621371;
		}
	public static double ConvertMilesToKm(double miles){
		
			return miles*1.60934;
		}
	public static double ConvertMeterToFeet(double meter){
		
			return meter*3.28084;
		}
	public static double ConvertFeetToMeter(double feet){
		
			return feet*0.3048;
		}
		
}