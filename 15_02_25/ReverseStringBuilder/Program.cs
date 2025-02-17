using System;
using System.Text;
class Reverse{
    static void Main(){
        StringBuilder sb=new StringBuilder(Console.ReadLine());
        sb=new StringBuilder(ReverseString(sb.ToString()));
        Console.WriteLine($"REVERSED STRING:-{sb}");
    }
    static string ReverseString(string str){
        char[]arr=str.ToCharArray();
        int index=0;
        for(int i=arr.Length-1;i>=0;i--){
            arr[index++]=str[i];
        }
       return new string(arr);
    }
}