using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string department, double salary)
    {
        ID = id;
        Name = name;
        Department = department;
        Salary = salary;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "employee.csv";  // Path to the original CSV file

        try
        {
            List<Employee> employees = new List<Employee>();

            // Read the CSV file and load the employee data
            using (var reader = new StreamReader(inputFilePath))
            {
                // Skip the header row
                reader.ReadLine();

                // Read each line and create an Employee object
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length < 4)
                        continue;

                    int id = int.Parse(values[0]);
                    string name = values[1];
                    string department = values[2];
                    double salary = double.Parse(values[3]);

                    // Create Employee object and add to the list
                    employees.Add(new Employee(id, name, department, salary));
                }
            }

            // Sort the employees list by salary in descending order
            var topEmployees = employees.OrderByDescending(e => e.Salary).Take(5);

            // Print the top 5 highest-paid employees
            Console.WriteLine("Top 5 Highest Paid Employees:");
            foreach (var employee in topEmployees)
            {
                Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, Department: {employee.Department}, Salary: {employee.Salary:F2}");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
        }
    }
}
