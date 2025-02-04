using System;
class Prime{
	static void Main(string[] args){
		Console.WriteLine("Enter the number");
		int number=int.Parse(Console.ReadLine());
		bool IsPrime=CheckPrime(number);
		Console.WriteLine($"Is the Number {number} prime? {IsPrime}");
	}
	static bool CheckPrime(int n){
		if(n<2)
			return false;
		for(int i=2;i<n;i++){
			if(n%i==0)
				return false;
		}
		return true;
	}
}
