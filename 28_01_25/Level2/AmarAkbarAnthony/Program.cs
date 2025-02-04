using System;
class Amar{
	static void Main(string[]args){
		int[]Ages=new int[3];
		int[]heights=new int[3];
		
		for(int i=0;i<3;i++){
		Console.WriteLine($"Enter the Age of {i} friends");
			Ages[i]=int.Parse(Console.ReadLine());
		Console.WriteLine($"Enter the height of {i} friends");
			heights[i]=int.Parse(Console.ReadLine());

		}
		Console.WriteLine($"The youngest friend among 3 is: {YoungestFriend(Ages)}");
		Console.WriteLine($"The tallest friend among 3 is: {tallest(heights)}");
		
	}
	static int YoungestFriend(int[]ages){
		int youngest=0;
		for(int i=0;i<3;i++){
		if(ages[i]<ages[youngest])
			youngest=i;
		}
		return youngest;
		
	}
	static int tallest(int[]heights){
		int tall=0;
		for(int i=0;i<3;i++){
		if(heights[i]<heights[tall])
			tall=i;
		}
		return tall;
		
		
	}
}