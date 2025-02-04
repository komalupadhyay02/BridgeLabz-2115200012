using System;
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
}
}