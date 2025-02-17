using System;
using System.Diagnostics;
class FibonacciCompare{
    static void Main(){
        int[] testCases = { 10, 20, 30, 35, 40 };
        foreach(int n in testCases){
            Console.WriteLine($"\nFibonacci for n = {n}");
            Stopwatch sw=Stopwatch.StartNew();
            int recursiveFibo=FiboRecursive(n);
            sw.Stop();
            Console.WriteLine($"Fibonacci recursive:{recursiveFibo}in {sw.Elapsed.TotalMilliseconds}ms");
            sw.Restart();
            int iterativefibo=FibonacciIterative(n);
            sw.Stop();
            Console.WriteLine($"Fibonacci recursive:{iterativefibo}in {sw.Elapsed.TotalMilliseconds}ms");
        }
    }
    static int FiboRecursive(int n){
         if (n <= 1) return n;
         return FiboRecursive(n-1)+FiboRecursive(n-2);
    }
    public static int FibonacciIterative(int n) {
    int a = 0, b = 1, sum;
    for (int i = 2; i <= n; i++) {
        sum = a + b;
        a = b;
        b = sum;
    }
    return b;
}

}