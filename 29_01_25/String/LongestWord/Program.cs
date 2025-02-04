using System;
class LongestWord{
	static void Main(String[]args){
		Console.WriteLine("Enter the Sentence");
		String input=Console.ReadLine();
		String longWord= FindLongestWord(input);
		Console.WriteLine($"the longest word in the sentence is: {longWord}");
	}
	static String FindLongestWord(String input){
		String longestWord="";
		int maxLength=0;
		String[]words=input.Split(" ");
		foreach(string word in words){
			if(word.Length>maxLength){
				maxLength=word.Length;
				longestWord=word;
			}
		}
		return longestWord;
	}
}