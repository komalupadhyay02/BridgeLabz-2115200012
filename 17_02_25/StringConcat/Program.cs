using System;
using System.Diagnostics;
using System.Text;

class ConCatCompare
{
    static void Main()
    {
        int[] operationCount = { 10, 1000, 100000 };

        foreach (int n in operationCount)
        {
            Console.WriteLine($"\nOperations Count: {n}");

            // String concatenation
            Stopwatch sw = Stopwatch.StartNew();
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str += "a";
            }
            sw.Stop();
            Console.WriteLine($"String: {sw.Elapsed.TotalMilliseconds} ms");

            // StringBuilder concatenation
            sw.Restart();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append("a");
            }
            sw.Stop();
            Console.WriteLine($"StringBuilder: {sw.Elapsed.TotalMilliseconds} ms");
        }
    }
}
