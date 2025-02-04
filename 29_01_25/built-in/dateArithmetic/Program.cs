using System;
class dateArithmetic{
	static void Main(string[] args){
		Console.WriteLine("Enter the date (yyyy-MM-DD): ");
              
		DateTime inputDate=Convert.ToDateTime(Console.ReadLine());
		DateTime newDate = inputDate.AddDays(7).AddMonths(1).AddYears(2);
            newDate = newDate.AddDays(-21);
		Console.WriteLine("Final Date after arithmetic operations: " + newDate.ToString("yyyy-MM-dd"));

	}
}