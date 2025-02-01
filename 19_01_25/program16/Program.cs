using System;
class EvenOdd{
	static void Main(string[]args)
	{
		Console.WriteLine("Enter the Number");
		int Number=int.Parse(Console.ReadLine());
		EvenOrOdd(Number);
	}
	static void EvenOrOdd(int Number){
		for(int i=1;i<=Number;i++){
			if(i%2==0){
				Console.WriteLine($"{i} is even");
		}
		else{
			Console.WriteLine($"{i} is odd");

		}

	}

}
}