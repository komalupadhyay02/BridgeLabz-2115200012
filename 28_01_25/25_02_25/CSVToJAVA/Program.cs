using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Define the Student class
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Marks { get; set; }

        // Constructor
        public Student(int id, string name, int age, double marks)
        {
            Id = id;
            Name = name;
            Age = age;
            Marks = marks;
        }

        // Override ToString to display the student details
        public override string ToString()
        {
            return $"Student{{Id={Id}, Name='{Name}', Age={Age}, Marks={Marks}}}";
        }
    }

    static void Main(string[] args)
    {
        string inputFilePath = "student.csv";  // Path to your CSV file
        List<Student> students = new List<Student>();  // List to store student objects

        try
        {
            // Read the CSV file
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line;
                
                // Read and skip the header row
                reader.ReadLine();

                // Read each line from the CSV
                while ((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split(',');

                    // Assuming the CSV has the following columns: ID, Name, Age, Marks
                    try
                    {
                        int id = int.Parse(values[0]);
                        string name = values[1];
                        int age = int.Parse(values[2]);
                        double marks = double.Parse(values[3]);

                        // Create a Student object and add it to the list
                        Student student = new Student(id, name, age, marks);
                        students.Add(student);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine($"Error parsing data in row: {line}. {e.Message}");
                    }
                }
            }

            // Print the list of students
            Console.WriteLine("List of Students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error reading the file: {e.Message}");
        }
    }
}
