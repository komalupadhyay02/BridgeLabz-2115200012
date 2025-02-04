using System;
 class ReverseString{
	static void Main(String[]args){
	  Console.WriteLine("Enter the String");
	  String input=Console.ReadLine();
	String reverse="";
		for(int i=input.Length-1;i>=0;i--){
			reverse+=input[i];
		}
	Console.WriteLine($"the reversed string is: {reverse}");
}
}