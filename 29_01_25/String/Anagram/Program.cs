using System;
class Anagram{
	static void Main(string[]args){
		Console.WriteLine("enter first string");
		String s1=Console.ReadLine().ToLower();
		Console.WriteLine("enter second String");
		String s2=Console.ReadLine().ToLower();
		bool IsAnagram=CheckAnagram(s1,s2);
		Console.WriteLine($"Is the two  strings {s1} and {s2} Anagram? {IsAnagram}");
	}
	static bool CheckAnagram(String s1, String s2){
		if(s1.Length!=s2.Length)
			return false;
		char[]ch1=s1.ToCharArray();
		char[]ch2=s2.ToCharArray();
		Array.Sort(ch1);
		Array.Sort(ch2);
		for(int i=0;i<ch1.Length;i++){
			if(ch1[i]==ch2[i])
				return true;
		}
		return false;
	}
}