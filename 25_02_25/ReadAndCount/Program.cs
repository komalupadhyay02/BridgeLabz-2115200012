using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "student.csv"; // Path to your CSV file
        int rowCount=0;
        
        // Read the CSV file and print the data
        using (var reader = new StreamReader(filePath))
        {
            // Skip the header line
            if(!reader.EndOfStream)
            reader.ReadLine();
            
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                rowCount++;
            }
        }
         Console.WriteLine($"Number of records (excluding header): {rowCount}");
    }
}
