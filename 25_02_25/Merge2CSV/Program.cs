using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    // Define the Student class with all fields
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Marks { get; set; }
        public string Grade { get; set; }

        // Constructor to initialize the student object
        public Student(int id, string name, int age, double marks, string grade)
        {
            Id = id;
            Name = name;
            Age = age;
            Marks = marks;
            Grade = grade;
        }

        // Override ToString() to display the student details in CSV format
        public override string ToString()
        {
            return $"{Id},{Name},{Age},{Marks},{Grade}";
        }
    }

    static void Main(string[] args)
    {
        string students1FilePath = "students1.csv";  // Path to the first CSV file
        string students2FilePath = "students2.csv";  // Path to the second CSV file
        string outputFilePath = "merged_students.csv";  // Path to the new CSV file with merged data

        // Dictionary to store data from the first CSV (ID, Name, Age)
        Dictionary<int, Tuple<string, int>> students1 = new Dictionary<int, Tuple<string, int>>();

        // Read the first CSV (students1.csv)
        try
        {
            using (StreamReader reader = new StreamReader(students1FilePath))
            {
                string line;
                reader.ReadLine();  // Skip header row

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    int id = int.Parse(values[0]);
                    string name = values[1];
                    int age = int.Parse(values[2]);

                    // Add data from students1 to the dictionary
                    students1[id] = new Tuple<string, int>(name, age);
                }
            }

            // List to store the merged student objects
            List<Student> mergedStudents = new List<Student>();

            // Read the second CSV (students2.csv)
            using (StreamReader reader = new StreamReader(students2FilePath))
            {
                string line;
                reader.ReadLine();  // Skip header row

                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    int id = int.Parse(values[0]);
                    double marks = double.Parse(values[1]);
                    string grade = values[2];

                    // Check if the ID exists in students1 (the first file)
                    if (students1.ContainsKey(id))
                    {
                        var student1 = students1[id];
                        string name = student1.Item1;
                        int age = student1.Item2;

                        // Create a new merged student object
                        Student mergedStudent = new Student(id, name, age, marks, grade);
                        mergedStudents.Add(mergedStudent);
                    }
                }
            }

            // Write the merged data to a new CSV file (merged_students.csv)
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                // Write the header
                writer.WriteLine("ID,Name,Age,Marks,Grade");

                // Write each merged student record
                foreach (var student in mergedStudents)
                {
                    writer.WriteLine(student);
                }
            }

            Console.WriteLine("CSV files merged successfully!");

        }
        catch (IOException e)
        {
            Console.WriteLine("Error reading or writing files: " + e.Message);
        }
    }
}
