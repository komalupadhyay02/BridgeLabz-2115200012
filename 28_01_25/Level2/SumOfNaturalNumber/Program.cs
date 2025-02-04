using System;
class SumOfNatural{
	static void Main(string[]args){
		Console.WriteLine("Enter the number");
		int n=Convert.ToInt32(Console.ReadLine());
		int SumFormula=CalculateSumFormula(n);
		int SumRecursive=CalculateSumRecursive(n);
		Console.WriteLine($"The Sum Of Natural no. using Formula is: {SumFormula}");
		Console.WriteLine($"The Sum Of Natural no. using Recursive Function is: {SumRecursive}");
		if(SumRecursive==SumFormula)
		Console.WriteLine("both sum are same");
	}
	static int CalculateSumRecursive(int n){
		if(n==1){
			return 1;
		}
		return n+CalculateSumRecursive(n-1);
	}
        static int CalculateSumFormula(int n){
		return n * (n + 1) / 2;
	}
}
