using System;
class QuickSort {
    public static void Sort(int[] arr, int low, int high) {
        if (low < high) {
            int pi = Partition(arr, low, high);
            Sort(arr, low, pi - 1);
            Sort(arr, pi + 1, high);
        }
    }

    private static int Partition(int[] arr, int low, int high) {
        int pivot = arr[high], i = low - 1;
        for (int j = low; j < high; j++) {
            if (arr[j] < pivot) {
                i++;
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
        }
        (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
        return i + 1;
    }
 static void Main(string[]args){
        Console.WriteLine("Enter the length of an array");
        int n=Convert.ToInt32(Console.ReadLine());
        int[]arr=new int[n];
        Console.WriteLine("Enter price of products:--");
        for(int i=0;i<n;i++){
            arr[i]=Convert.ToInt32(Console.ReadLine());
        }
     Sort(arr, 0, arr.Length - 1);
        Console.WriteLine(string.Join(", ", arr));

    }
}   