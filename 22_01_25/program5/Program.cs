using System;
class Pens
{
	static void Main(string[] args)
	{
		//total no. of pens and students.
		int totalPens=14;
		int totalStudents=3;
		// Call the method to calculate and display the result
        	CalculateAndDisplay(totalPens, totalStudents);
	}
	
	//method to calculate and display pens per student and remaining pens.
	static void CalculateAndDisplay(int totalPens, int totalStudents)
	{
		int pensPerStudent=totalPens/totalStudents;//calculating pens per Student.
		int remainingPens=totalPens%totalStudents;//calculating remaining pens.
		//display pen per student and remaining pens.
		Console.WriteLine($"The Pen Per Student is {pensPerStudent} and the remaining pen not distributed is {remainingPens}");
	}
}