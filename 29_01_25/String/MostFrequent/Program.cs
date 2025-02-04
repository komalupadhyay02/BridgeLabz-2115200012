using System;
class MostFrequent{
	static void Main(String[]args){
		Console.WriteLine("Enter the String");
		String input=Console.ReadLine();
		char Frequent= FrequentCharacter(input);
		Console.WriteLine($"the most frequent character in a string is: {Frequent}");
	}
	static char FrequentCharacter(String input){
		char mostFreqChar=' ';
		int maxFrequency=0;
		for(int i=0;i<input.Length;i++){
			int frequency=0;
			for (int j = 0; j < input.Length; j++){
			if(input[i]==input[j]){
				frequency++;
			}
			if(frequency>maxFrequency){
			maxFrequency=frequency;
			mostFreqChar=input[i];
			}
		}
}
		
		return mostFreqChar;
	}

}