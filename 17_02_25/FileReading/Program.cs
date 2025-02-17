using System;
using System.Diagnostics;
using System.IO;

class FileReadEfficiency
{
    static void Main()
    {
        string filePath = "abc.txt"; // Path to the large file

        // Measure time using StreamReader
        Stopwatch stopwatch = Stopwatch.StartNew();
        using (StreamReader sr = new StreamReader(filePath))
        {
            while (sr.Read() != -1) { }
        }
        stopwatch.Stop();
        Console.WriteLine($"StreamReader Time: {stopwatch.Elapsed.TotalSeconds} seconds");

        // Measure time using FileStream
        stopwatch.Restart();
        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[1024];
            while (fs.Read(buffer, 0, buffer.Length) > 0) { }
        }
        stopwatch.Stop();
        Console.WriteLine($"FileStream Time: {stopwatch.Elapsed.TotalSeconds} seconds");
    }
}
