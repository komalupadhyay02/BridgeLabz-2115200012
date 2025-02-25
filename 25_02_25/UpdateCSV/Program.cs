using System;
using System.IO;

class Employee
{
    static void Main(string[] args)
    {
        string inputFilePath = "employee.csv";  // Path to the original CSV file
        string outputFilePath = "updated_employees.csv";  // Path to the new CSV file with updated salaries

        try
        {
            // Read the CSV file and update the salaries
            using (var reader = new StreamReader(inputFilePath))
            using (var writer = new StreamWriter(outputFilePath))
            {
                // Read the header row
                string header = reader.ReadLine();
                writer.WriteLine(header);  // Write the header to the new file

                // Read each line and modify the salary for "IT" department
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    
                    // Skip empty lines
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var values = line.Split(',');

                    // Check if the record has the expected number of columns
                    if (values.Length < 4)
                    {
                        Console.WriteLine("Skipping malformed record: " + line);
                        continue;
                    }

                    string department = values[2];  // Assuming the third column is the department
                    double salary;

                    // Ensure salary is a valid number
                    if (double.TryParse(values[3], out salary))
                    {
                        // If department is "IT", increase the salary by 10%
                        if (department.Equals("IT", StringComparison.OrdinalIgnoreCase))
                        {
                            salary *= 1.10;  // Increase salary by 10%
                            values[3] = salary.ToString("F2");  // Update salary with two decimal places
                        }

                        // Write the updated record to the new CSV file
                        writer.WriteLine(string.Join(",", values));
                    }
                    else
                    {
                        Console.WriteLine("Skipping record with invalid salary: " + line);
                    }
                }
            }

            Console.WriteLine("CSV file updated successfully!");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error reading or writing the file: " + ex.Message);
        }
    }
}
