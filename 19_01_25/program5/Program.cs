using System;
<<<<<<< HEAD
class CylinderVolume
{
static void Main(string[] args)
{
Console.Write("Enter the radius of the cylinder: ");
double radius = double.Parse(Console.ReadLine());
Console.Write("Enter the height of the cylinder: ");
double height = double.Parse(Console.ReadLine());
double volume = Math.PI * Math.Pow(radius, 2) * height;
Console.WriteLine($"The volume of the cylinder is: {volume}");
=======
class Vote
{
	static void Main(String[]args)
	{
		//user input
		Console.WriteLine("Enter your Age");
		int age=int.Parse(Console.ReadLine());
		bool result=PersonCanVote(age);
		if(result){

		Console.WriteLine($"The person's age is {age} and can vote");
		}
		else{

		Console.WriteLine($"The person's age is {age} and cannot vote");
		}
	}
	//method to check weather person can vote or not.
	static bool PersonCanVote(int age)
	{
		return age>=18;
>>>>>>> origin/feature
}
}