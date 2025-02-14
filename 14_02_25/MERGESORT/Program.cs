using System;
class MergeSort {
    public static void Sort(int[] arr, int left, int right) {
        if (left < right) {
            int mid = left + (right - left) / 2;
            Sort(arr, left, mid);
            Sort(arr, mid + 1, right);
            Merge(arr, left, mid, right);
        }
    }

    private static void Merge(int[] arr, int left, int mid, int right) {
        int[] leftArr = arr[left..(mid + 1)];
        int[] rightArr = arr[(mid + 1)..(right + 1)];
        int i = 0, j = 0, k = left;
        while (i < leftArr.Length && j < rightArr.Length) {
            arr[k++] = leftArr[i] <= rightArr[j] ? leftArr[i++] : rightArr[j++];
        }
        while (i < leftArr.Length) arr[k++] = leftArr[i++];
        while (j < rightArr.Length) arr[k++] = rightArr[j++];
    }

   static void Main(string[]args){
        Console.WriteLine("Enter the length of an array");
        int n=Convert.ToInt32(Console.ReadLine());
        int[]arr=new int[n];
        Console.WriteLine("Enter books price");
        for(int i=0;i<n;i++){
            arr[i]=Convert.ToInt32(Console.ReadLine());
        }
       Sort(arr, 0, arr.Length - 1);
        Console.WriteLine(string.Join(", ", arr));


    }
}
