using System;
class BubbleSort {
    public static void SlectionSort(int[] arr,int n) {
        int temp;
        for(int i=0;i<n-1;i++){
            int SmallestIndex=i;
            for(int j=i+1;j<n;j++){
                if(arr[j]<arr[SmallestIndex]){
                    SmallestIndex=j;
                }
            }
            temp=arr[i];
                arr[i]=arr[SmallestIndex];
                arr[SmallestIndex]=temp;
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
       SelectionSort(arr,n);
        Console.WriteLine(string.Join(", ", arr));

    }
}   