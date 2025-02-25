using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "student.csv"; // Path to your CSV file
        
        // Read the CSV file and print the data
        using (var reader = new StreamReader(filePath))
        {
            // Skip the header line
            reader.ReadLine();
            
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                int id = int.Parse(values[0]);
                string name = values[1];
                int age = int.Parse(values[2]);
                double marks = double.Parse(values[3]);

                // Print the student's data in structured format
                Console.WriteLine($"ID: {id}, Name: {name}, Age: {age}, Marks: {marks}");
            }
        }
    }
}
