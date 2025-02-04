using System;
class Occurences
{
	public static void Main(String[] args)
	{
		Console.Write("Enter the Sentence: ");
		String s= Convert.ToString(Console.ReadLine());
		Console.Write("Enter the string to check the occurences of: ");
		String substr=Convert.ToString(Console.ReadLine());
		// Checking for empty strings
		if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(substr))
			Console.WriteLine("Invalid Input");
		int count=0;
		// checking for occurences of substring and increasing the count
		int index = s.IndexOf(substr);
		while(index != -1)
		{
			count++;
			index=s.IndexOf(substr, index+substr.Length);
		}
		Console.WriteLine("Number of Occurences of Substring in the sentence: "+count);
	}
}