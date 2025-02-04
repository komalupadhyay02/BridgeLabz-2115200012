using System;
class Palindrome{
	static void Main(string[] args){
		Console.WriteLine("Enter the string");
		String input=Console.ReadLine();
		Console.WriteLine($"Is the string {input} Palindrome? {IsPalindrome(input)}");
	}
	static bool IsPalindrome(String input){
		
		int low=0, high=input.Length-1;
		while(low<high){
			if(input[low]==input[high]){
				return true;
			
			}
			low++;
			high--;
		}
		
		return false;
	}
}