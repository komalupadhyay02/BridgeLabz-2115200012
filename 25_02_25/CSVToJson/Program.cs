using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    // Method to convert JSON to CSV
    public static void JsonToCsv(string jsonFilePath, string csvFilePath)
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        var students = JsonConvert.DeserializeObject<List<Student>>(jsonContent);

        using (var writer = new StreamWriter(csvFilePath))
        {
            writer.WriteLine("StudentID,Name,Age,Grade");

            foreach (var student in students)
            {
                writer.WriteLine($"{student.StudentID},{student.Name},{student.Age},{student.Grade}");
            }
        }

        Console.WriteLine("JSON to CSV conversion completed!");
    }

    // Method to convert CSV to JSON
    public static void CsvToJson(string csvFilePath, string jsonFilePath)
    {
        var students = new List<Student>();

        using (var reader = new StreamReader(csvFilePath))
        {
            string header = reader.ReadLine();  // Read the header line
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var student = new Student
                {
                    StudentID = values[0],
                    Name = values[1],
                    Age = int.Parse(values[2]),
                    Grade = values[3]
                };
                students.Add(student);
            }
        }

        string jsonContent = JsonConvert.SerializeObject(students, Formatting.Indented);
        File.WriteAllText(jsonFilePath, jsonContent);

        Console.WriteLine("CSV to JSON conversion completed!");
    }

    static void Main(string[] args)
    {
        // Paths to the files
        string jsonFilePath = "students.json";
        string csvFilePath = "students.csv";
        string jsonOutputPath = "students_output.json";

        // Convert JSON to CSV
        JsonToCsv(jsonFilePath, csvFilePath);

        // Convert CSV back to JSON
        CsvToJson(csvFilePath, jsonOutputPath);
    }
}

// Student class to map the JSON data
public class Student
{
    public string StudentID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }
}
