using System;
class Bonus{
	static void Main(string[]args){
		Console.WriteLine("enter your Salary");
		double Salary=Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("enter your Year of Working");
		int Year=int.Parse(Console.ReadLine());
		double bonus=CalculateBonus(Salary,Year);
		if(bonus>0){
			Console.WriteLine($"the employee has the bonus of {bonus}");
		}
		else{
			Console.WriteLine("The employee is not eligible for Bonus");
		}
		}
		static double CalculateBonus(double Salary, int Year)
		{
			if(Year>5){
				return Salary*0.05;
			}
			else{
				return 0;
			}
		}

}