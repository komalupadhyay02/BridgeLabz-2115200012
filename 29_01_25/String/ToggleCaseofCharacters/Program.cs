using System;
class Toggle{
	static void Main(String[]args){
		Console.WriteLine("Enter the string");
		String input=Console.ReadLine();
		String toggledString=ToggleCase(input);
		Console.WriteLine($"the toggled string is: {toggledString}");
	}
	static String ToggleCase(string input){
		char []str=input.ToCharArray();
		for(int i=0;i<str.Length;i++){
			if(char.IsUpper(str[i])){
			str[i]=char.ToLower(str[i]);
			}
			else if(char.IsLower(str[i])){
			str[i]=char.ToUpper(str[i]);
			}
		}
		return new string(str);
	}
}