using System;
class Compare{
	static void Main(string[]args){
		Console.WriteLine("Enter the first string:");
        string str1 = Console.ReadLine();
        
        Console.WriteLine("Enter the second string:");
        string str2 = Console.ReadLine();
        
        int result = CompareTwoString(str1, str2);

        if (result < 0)
            Console.WriteLine($"\"{str1}\" comes before \"{str2}\" in lexicographical order.");
        else if (result > 0)
            Console.WriteLine($"\"{str1}\" comes after \"{str2}\" in lexicographical order.");
        else
            Console.WriteLine($"\"{str1}\" and \"{str2}\" are equal.");
    
	}
	static int CompareTwoString(string s1,string s2){
		int minLength=Math.Min(s1.Length,s2.Length);
		for(int i=0;i<minLength;i++){
			if(s1[i]<s2[i]) return -1;
			if(s1[i]>s2[i]) return 1;
		}
		if(s1.Length<s2.Length) return -1;
		if(s1.Length>s2.Length) return 1;
		return 0;
	}	
}