using System;
using System.Text;

class Concatination{
    static void Main(){
        int n=Convert.ToInt32(Console.ReadLine());
        string[]arr=new string[n];
        for(int i=0;i<n;i++){
            arr[i]=Console.ReadLine();
        }
       string result=Concat(arr);
        Console.WriteLine($"after concatination:-->{result}");
    }
    static string  Concat(string[] input){
     StringBuilder sb=new StringBuilder();
     foreach(string str in input){
        sb.Append(str);
     }
     return sb.ToString();
    }
}