using System;
class UnitConverter{
	static void Main(string[]args){
		Console.WriteLine("Enter the yards");
		double yards=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the feet");
		double feet=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the meter");
		double meter=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Enter the inches");
		double inches=Convert.ToDouble(Console.ReadLine());
		
		Console.WriteLine($"yards{yards} : {ConvertYardsToFeet(yards)} Feet");
		Console.WriteLine($"feet{feet} : {ConvertFeetToYards(feet)}Yards");
		Console.WriteLine($"meter{meter} : {ConvertMeterToInches(meter)} Inches");
		Console.WriteLine($"Inches{inches} : {ConvertInchesToMeter(inches)} meter");
		Console.WriteLine($"Inches{inches} : {ConvertInchesToCentimeter(inches)} Centimeter");
	}
	//method to convert km to mile
	
	public static double ConvertYardsToFeet(double yards){
		
			return yards*3;
		}
	public static double ConvertFeetToYards(double feet){
		
			return feet*0.333333;
		}
	public static double ConvertMeterToInches(double meter){
	
			return meter*39.3701;
		}
	public static double ConvertInchesToMeter(double inches){
		
			return inches*0.0254;
		}
	public static double ConvertInchesToCentimeter(double inches){
		
			return inches*2.54;
}
	
		
}