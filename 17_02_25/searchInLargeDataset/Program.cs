using System;
using System.Diagnostics;
class Compare{
    static void Main(){
        int[]datasetSizes={10,1000,10000};
        foreach(int n in datasetSizes){
            Console.WriteLine($"\nDataset Size: {n}");
            int []data=new int [n];
            for(int i=0;i<n;i++){
                data[i]=i+1;
            }
            int target =n;
            Stopwatch sw=Stopwatch.StartNew();
            int linearIndex=LinearSearch(data,target);
            sw.Stop();
              Console.WriteLine($"Linear Search: Found target at index {linearIndex} in {sw.Elapsed.TotalMilliseconds} ms");
            Array.Sort(data);
            sw.Restart();
            int binaryIndex=BinarySearch(data,target);
            sw.Stop();
             Console.WriteLine($"Binary Search: Found target at index {binaryIndex} in {sw.Elapsed.TotalMilliseconds} ms");
        }
        }
        static int LinearSearch(int[]data,int target){
            for(int i=0;i<data.Length;i++){
                if(target==data[i]){
                    return i;
                }
                
            }
            return -1;
        }
        static int BinarySearch(int[]data,int target){
            int low=0,high=data.Length-1;
            while(low<=high){
                int mid=low+(high-low)/2;
                if(data[mid]==target){
                    return mid;
                }
                else if(data[mid]<target){
                    low=mid+1;
                }
                else{
                    high=mid-1;
                }
            }
            return -1;
        }
        
    }

