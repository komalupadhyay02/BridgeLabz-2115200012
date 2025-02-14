using System;
class BubbleSort {
    public static void Sort(int[] arr,int n) {
        int temp;
        for(int i=0;i<n;i++){
            bool swapped=false;
            for(int j=0;j<n-i-1;j++){
                if(arr[j]>arr[j+1]){
                temp=arr[j];
                arr[j]=arr[j+1];
                arr[j+1]=temp;
                swapped=true;
                }
            }
            if(!swapped)break;
        }
       
               
    }
    static void Main(string[]args){
        Console.WriteLine("Enter the length of an array");
        int n=Convert.ToInt32(Console.ReadLine());
        int[]arr=new int[n];
        Console.WriteLine("Enter marks of students");
        for(int i=0;i<n;i++){
            arr[i]=Convert.ToInt32(Console.ReadLine());
        }
       Sort(arr,n);
        Console.WriteLine(string.Join(", ", arr));

    }
}   