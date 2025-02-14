using System;
class Sort {
    public static void InsertionSort(int[] arr,int n) {
     for(int i=1;i<n;i++){
        int current=arr[i];
        int prev=i-1;
        while(prev>=0 && arr[prev]>current){
            arr[prev+1]=arr[prev];
            prev--;
        }
        arr[prev+1]=current;
     }          
    }
    static void Main(string[]args){
        Console.WriteLine("Enter the length of an array");
        int n=Convert.ToInt32(Console.ReadLine());
        int[]arr=new int[n];
        Console.WriteLine("Enter id's of Employees:--");
        for(int i=0;i<n;i++){
            arr[i]=Convert.ToInt32(Console.ReadLine());
        }
       InsertionSort(arr,n);
        Console.WriteLine(string.Join(", ", arr));

    }
}   