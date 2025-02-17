using System;
using System.Text;

class Duplicate{
    static void Main(){
        StringBuilder sb=new StringBuilder(Console.ReadLine());
        sb=new StringBuilder(RemoveDuplicate(sb.ToString()));
        Console.WriteLine($"After removing duplicates:{sb}");
    }
    static string RemoveDuplicate(string str){
     var seen= new HashSet<char>();
     var result=new StringBuilder();
        foreach(char c in str){
            if(!seen.Contains(c)){
                seen.Add(c);
                result.Append(c);
            }
        }
         return result.ToString();
    }
}