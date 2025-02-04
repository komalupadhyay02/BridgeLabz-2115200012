using System;
class Leap{
	static void Main(string[]args){
		Console.WriteLine("Enter the Year");
		int year=Convert.ToInt32(Console.ReadLine());
		
		Console.WriteLine($"The year {year} is a {LeapYear(year)}");
	}
	//method to find leap year or not
	
	static String LeapYear(int year){
		if(year<=1582)
			Console.WriteLine("Give the year greater than 1582");
		if(year%4==0 && year%100!=0 || year%400==0){
			return "Leap Year";
		}
		else
			return "Not a leap year";
	}
}